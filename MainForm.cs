/*
GPG Desktop is a graphical frontend for GnuPG, the GNU Privacy Guard.
http://www.adammil.net/
Copyright (C) 2008 Adam Milazzo

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AdamMil.Security.PGP;
using AdamMil.Security.UI;

namespace GPGDesktop
{

partial class MainForm : Form
{
  public MainForm()
  {
    InitializeComponent();
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    base.OnKeyDown(e);

    if(!e.Handled && e.Modifiers == Keys.None)
    {
      if(e.KeyCode == Keys.F1) tabs.SelectedTab = homeTab;
      else if(e.KeyCode == Keys.F2) tabs.SelectedTab = keysTab;
      else if(e.KeyCode == Keys.F3) tabs.SelectedTab = padTab;
      else if(e.KeyCode == Keys.F5 && tabs.SelectedTab == keysTab) InvalidateKeyList();
      else return;

      e.Handled = true;
    }
  }

  protected override void OnShown(EventArgs e)
  {
    base.OnShown(e);

    AdamMil.Security.PGP.GPG.ExeGPG gpg = null;

    string gpgPath = GPGDesktop.Properties.Settings.Default.GPGPath;
    if(!string.IsNullOrEmpty(gpgPath))
    {
      try { gpg = new AdamMil.Security.PGP.GPG.ExeGPG(gpgPath); }
      catch { }
    }

    if(gpg == null)
    {
      Configure();
      if(this.pgp == null) Close();
    }
    else
    {
      InitializePGP(gpg);
    }
  }

  void About()
  {
    new AboutBox().ShowDialog();
  }

  void ActivateIcon()
  {
    if(homeList.SelectedIndices.Count != 0)
    {
      switch(homeList.SelectedIndices[0])
      {
        case 0: EncryptSignData(); break;
        case 1: DecryptVerifyData(); break;
        case 2: GenerateKeyPair(); break;
        case 3: Configure(); break;
        case 4: About(); break;
      }
    }
  }

  void ApplyKeyFilter()
  {
    string trimmed = txtSearch.Text.Trim();
    keyList.FilterItems(trimmed.Length == 0 ?
                          null : trimmed.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
  }

  void Configure()
  {
    if(new OptionsForm().ShowDialog() == DialogResult.OK)
    {
      InitializePGP(new AdamMil.Security.PGP.GPG.ExeGPG(GPGDesktop.Properties.Settings.Default.GPGPath));
      InvalidateKeyList();
    }
  }

  void DecryptVerifyData()
  {
    new DecryptVerifyWizard(pgp).ShowDialog();
  }

  void EncryptPad(EncryptionOptions options)
  {
    try
    {
      options.AlwaysTrustRecipients = true;
      MemoryStream dest = new MemoryStream();
      pgp.Encrypt(GetPadStream(), dest, options, new OutputOptions(OutputFormat.ASCII));
      SetPadText(dest);
    }
    catch(OperationCanceledException) { }
    catch(Exception ex)
    {
      MessageBox.Show("Encryption failed. The error was: " + ex.Message, "Encryption failed",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  void EncryptSignData()
  {
    new EncryptSignWizard(pgp).ShowDialog();
  }

  void GenerateKeyPair()
  {
    GenerateKeyForm form = new GenerateKeyForm(pgp);
    form.KeyGenerated += delegate { InvalidateKeyList(); };
    form.ShowDialog();
  }

  Stream GetPadStream()
  {
    return new MemoryStream(Encoding.UTF8.GetBytes(txtPad.Text), false);
  }

  void InitializePGP(AdamMil.Security.PGP.GPG.ExeGPG gpg)
  {
    gpg.DecryptionPasswordNeeded += Program.GetDecryptionPassword;
    gpg.KeyPasswordNeeded        += Program.GetKeyPassword;
    gpg.KeyPasswordInvalid       += Program.OnPasswordInvalid;
    #if DEBUG
    gpg.LineLogged += delegate(string line) { System.Diagnostics.Debugger.Log(0, "GPG", line+"\n"); };
    #endif

    this.pgp = gpg;
    InvalidateKeyList();
  }

  void InvalidateKeyList()
  {
    if(tabs.SelectedTab == keysTab)
    {
      RefreshKeyList();
    }
    else
    {
      keyListInvalidated = true;
    }
  }

  void PadSignAndEncrypt(bool encrypt)
  {
    PrimaryKey[] keys = null;
    try { keys = pgp.GetKeys(ListOptions.RetrieveOnlySecretKeys | ListOptions.IgnoreUnusableKeys); }
    catch(Exception ex)
    {
      MessageBox.Show("Unable to retrieve a list of signing keys. The error was: " + ex.Message,
                      "Key retrieval failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    keys = Array.FindAll(keys, delegate(PrimaryKey key) { return key.HasCapabilities(KeyCapabilities.Sign); });
    if(keys.Length == 0)
    {
      MessageBox.Show("You don't have any signing keys. If you don't have a key pair, create one. Otherwise, add a "+
                      "signing subkey to your key pair.", "No signing key",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    KeyForm form = new KeyForm("Select the signing key to use.", keys);
    if(form.ShowDialog() == DialogResult.OK)
    {
      EncryptionOptions encryptOptions = null;
      if(encrypt)
      {
        RecipientSearchForm recipForm = new RecipientSearchForm(pgp);
        if(recipForm.ShowDialog() == DialogResult.Cancel) return;
        encryptOptions = new EncryptionOptions(recipForm.GetSelectedRecipients());
        encryptOptions.AlwaysTrustRecipients = true;
      }

      try
      {
        MemoryStream dest = new MemoryStream();
        SignatureType sigType = encryptOptions == null ? SignatureType.ClearSignedText : SignatureType.Embedded;
        pgp.SignAndEncrypt(GetPadStream(), dest, new SigningOptions(sigType, form.SelectedKey), encryptOptions,
                           new OutputOptions(OutputFormat.ASCII));
        SetPadText(dest);
      }
      catch(OperationCanceledException) { }
      catch(Exception ex)
      {
        MessageBox.Show("Signing failed. The error was: " + ex.Message, "Signing failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }

  void RefreshKeyList()
  {
    keyList.PGP = pgp;
    keyList.ShowKeyring(null);
    ApplyKeyFilter();
    keyListInvalidated = false;
  }

  void SetPadText(MemoryStream data)
  {
    txtPad.Text = Encoding.UTF8.GetString(data.ToArray());
  }

  void ShowSignatures(Signature[] sigs)
  {
    new SignaturesForm(sigs).ShowDialog();
  }

  void homeList_KeyDown(object sender, KeyEventArgs e)
  {
    if(!e.Handled && e.KeyCode == Keys.Enter && e.Modifiers == Keys.None) ActivateIcon();
  }

  void homeList_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    if(e.Button == MouseButtons.Left) ActivateIcon();
  }

  void encryptMenuItem_Click(object sender, EventArgs e)
  {
    EncryptSignData();
  }

  void decryptMenuItem_Click(object sender, EventArgs e)
  {
    DecryptVerifyData();
  }

  void generateMenuItem_Click(object sender, EventArgs e)
  {
    GenerateKeyPair();
  }

  void optionsMenuItem_Click(object sender, EventArgs e)
  {
    Configure();
  }

  void aboutMenuItem_Click(object sender, EventArgs e)
  {
    About();
  }

  void exitMenuItem_Click(object sender, EventArgs e)
  {
    Close();
  }

  void txtSearch_TextChanged(object sender, EventArgs e)
  {
    btnClearSearch.Enabled = txtSearch.TextLength != 0;

    ApplyKeyFilter();
  }

  void btnRefresh_Click(object sender, EventArgs e)
  {
    InvalidateKeyList();
  }

  void tabs_Selected(object sender, TabControlEventArgs e)
  {
    if(tabs.SelectedTab == keysTab && keyListInvalidated) RefreshKeyList();
  }

  void text_KeyDown(object sender, KeyEventArgs e)
  {
    if(!e.Handled && e.KeyCode == Keys.A && e.Modifiers == Keys.Control) // ctrl-a selects all text
    {
      ((TextBoxBase)sender).SelectAll();
      e.Handled = true;
    }
  }

  void txtPad_TextChanged(object sender, EventArgs e)
  {
    btnDecrypt.Enabled = btnVerify.Enabled = txtPad.TextLength != 0;
  }

  void btnEncrypt_Click(object sender, EventArgs e)
  {
    RecipientSearchForm form = new RecipientSearchForm(pgp);
    if(form.ShowDialog() == DialogResult.OK) EncryptPad(new EncryptionOptions(form.GetSelectedRecipients()));
  }

  void btnSymmetric_Click(object sender, EventArgs e)
  {
    PasswordForm form = new PasswordForm();
    form.EnableRememberPassword = false;
    form.DescriptionText        = "Enter the password used to encrypt the data.";
    if(form.ShowDialog() == DialogResult.OK) EncryptPad(new EncryptionOptions(form.GetPassword()));
  }

  void btnDecrypt_Click(object sender, EventArgs e)
  {
    try 
    { 
      MemoryStream dest = new MemoryStream();
      Signature[] sigs = pgp.Decrypt(GetPadStream(), dest);
      SetPadText(dest);

      if(sigs.Length != 0) ShowSignatures(sigs);
    }
    catch(OperationCanceledException) { }
    catch(Exception ex)
    {
      MessageBox.Show("Decryption failed. The error was: " + ex.Message, "Decryption failed",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  void btnSign_Click(object sender, EventArgs e)
  {
    PadSignAndEncrypt(false);
  }

  void btnSignEncrypt_Click(object sender, EventArgs e)
  {
    PadSignAndEncrypt(true);
  }

  void btnVerify_Click(object sender, EventArgs e)
  {
    try
    {
      Signature[] sigs = pgp.Verify(GetPadStream());
      if(sigs.Length == 0)
      {
        MessageBox.Show("This data contains no signatures.", "No signatures",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        ShowSignatures(sigs);
      }
    }
    catch(OperationCanceledException) { }
    catch(Exception ex)
    {
      MessageBox.Show("Verification failed. The error was: " + ex.Message, "Verification failed",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  void btnOpen_Click(object sender, EventArgs e)
  {
    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter = "ASC Files (*.asc)|*.asc|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
    ofd.Title  = "Select the file to open.";
    ofd.SupportMultiDottedExtensions = true;
    
    if(ofd.ShowDialog() == DialogResult.OK)
    {
      FileStream file = null;
      try
      {
        file = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
        txtPad.Text = new StreamReader(file).ReadToEnd();
      }
      catch(Exception ex)
      {
        MessageBox.Show("Unable to read file '" + ofd.FileName + "'. The error was: " + ex.Message,
                        "Unable to read file", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        if(file != null) file.Dispose();
      }
    }
  }

  void btnSave_Click(object sender, EventArgs e)
  {
    SaveFileDialog sfd = new SaveFileDialog();
    sfd.Filter = "ASC Files (*.asc)|*.asc|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
    sfd.Title  = "Select location to save the text.";
    sfd.SupportMultiDottedExtensions = true;

    if(sfd.ShowDialog() == DialogResult.OK)
    {
      FileStream file = null;
      try
      {
        file = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.Write(txtPad.Text);
        sw.Close();
      }
      catch(Exception ex)
      {
        MessageBox.Show("Unable to write file '" + sfd.FileName + "'. The error was: " + ex.Message,
                        "Unable to write file", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        if(file != null) file.Dispose();
      }
    }
  }

  PGPSystem pgp;
  bool keyListInvalidated = true;
}

} // namespace GPGDesktop