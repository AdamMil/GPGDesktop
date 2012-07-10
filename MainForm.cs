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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AdamMil.Security;
using AdamMil.Security.PGP;
using AdamMil.Security.PGP.GPG;
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

    ExeGPG gpg = null;

    string gpgPath = GPGDesktop.Properties.Settings.Default.GPGPath;
    if(!string.IsNullOrEmpty(gpgPath))
    {
      try { gpg = new ExeGPG(gpgPath); }
      catch { }
    }

    if(gpg == null)
    {
      Configure();
      if(this.gpg == null) Close();
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
      InitializePGP(new ExeGPG(GPGDesktop.Properties.Settings.Default.GPGPath));
      InvalidateKeyList();
    }
  }

  void DecryptVerifyData()
  {
    new DecryptVerifyWizard(gpg).ShowDialog();
  }

  void EncryptPad(EncryptionOptions options)
  {
    PGPUI.DoWithErrorHandling("encrypting", delegate
    {
      options.AlwaysTrustRecipients = true;
      MemoryStream dest = new MemoryStream();
      gpg.Encrypt(GetPadStream(), dest, options, new OutputOptions(OutputFormat.ASCII));
      SetPadText(dest);
    });
  }

  void EncryptSignData()
  {
    new EncryptSignWizard(gpg).ShowDialog();
  }

  void GenerateKeyPair()
  {
    GenerateKeyForm form = new GenerateKeyForm(gpg);
    form.KeyGenerated += delegate { InvalidateKeyList(); };
    form.ShowDialog();
  }

  Stream GetPadStream()
  {
    return new MemoryStream(Encoding.UTF8.GetBytes(txtPad.Text), false);
  }

  void InitializePGP(ExeGPG gpg)
  {
    gpg.DecryptionPasswordNeeded += Program.GetDecryptionPassword;
    gpg.KeyPasswordNeeded        += Program.GetKeyPassword;
    gpg.KeyPasswordInvalid       += Program.OnPasswordInvalid;
    #if DEBUG
    gpg.LineLogged += delegate(string line) { System.Diagnostics.Debugger.Log(0, "GPG", line+"\n"); };
    #endif

    this.gpg = gpg;
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
    try { keys = gpg.GetKeys(ListOptions.RetrieveOnlySecretKeys | ListOptions.IgnoreUnusableKeys); }
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

    KeyFormWithOptions form = new KeyFormWithOptions("Select the signing key to use.", keys);
    if(form.ShowDialog() == DialogResult.OK)
    {
      EncryptionOptions encryptOptions = null;
      if(encrypt)
      {
        RecipientSearchForm recipForm = new RecipientSearchForm(gpg);
        if(recipForm.ShowDialog() == DialogResult.Cancel) return;
        List<PrimaryKey> recipients = new List<PrimaryKey>(recipForm.GetSelectedRecipients());
        if(form.EncryptToSelf && recipients.Find(p => p.EffectiveId == form.SelectedKey.EffectiveId) == null)
        {
          recipients.Add(form.SelectedKey);
        }
        encryptOptions = new EncryptionOptions(recipients.ToArray());
        encryptOptions.AlwaysTrustRecipients = true;
      }

      PGPUI.DoWithErrorHandling("signing", delegate
      {
        MemoryStream dest = new MemoryStream();
        SignatureType sigType = encryptOptions == null ? SignatureType.ClearSignedText : SignatureType.Embedded;
        gpg.SignAndEncrypt(GetPadStream(), dest, new SigningOptions(sigType, form.SelectedKey), encryptOptions,
                           new OutputOptions(OutputFormat.ASCII));
        SetPadText(dest);
      });
    }
  }

  void RefreshKeyList()
  {
    keyList.PGP = gpg;
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

  void btnClearSearch_Click(object sender, EventArgs e)
  {
    txtSearch.Text = string.Empty;
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
    RecipientSearchForm form = new RecipientSearchForm(gpg);
    if(form.ShowDialog() == DialogResult.OK) EncryptPad(new EncryptionOptions(form.GetSelectedRecipients()));
  }

  void btnSymmetric_Click(object sender, EventArgs e)
  {
    // TODO: in gpg 2+, it ignores the password we give it in favor of its own UI, so there's no point in asking the user for
    // the password beforehand. we should avoid asking the user in that case
    PasswordForm form = new PasswordForm();
    form.EnableRememberPassword = false;
    form.RequirePassword        = true;
    while(true)
    {
      form.DescriptionText = "Enter the password used to encrypt the data.";
      form.ClearPassword();
      if(form.ShowDialog() != DialogResult.OK) break;

      using(System.Security.SecureString pass = form.GetPassword())
      {
        form.DescriptionText = "Enter the password a second time to verify it.";
        form.ClearPassword();
        if(form.ShowDialog() != DialogResult.OK) break;

        using(System.Security.SecureString pass2 = form.GetPassword())
        {
          if(pass.IsEqualTo(pass2))
          {
            EncryptPad(new EncryptionOptions(pass));
            break;
          }
          else
          {
            MessageBox.Show("The passwords do not match.", "Password mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
    }
  }

  void btnDecrypt_Click(object sender, EventArgs e)
  {
    PGPUI.DoWithErrorHandling("decrypting", delegate
    { 
      MemoryStream dest = new MemoryStream();
      Signature[] sigs = gpg.Decrypt(GetPadStream(), dest);
      SetPadText(dest);

      if(sigs.Length != 0) ShowSignatures(sigs);
    });
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
    PGPUI.DoWithErrorHandling("verifying", delegate
    {
      Signature[] sigs;
      try
      {
        sigs = gpg.Verify(GetPadStream());
      }
      catch(DecryptionFailedException) // if the data appears encrypted, try decrypting it
      {
        sigs = gpg.Decrypt(GetPadStream(), Stream.Null);
      }

      if(sigs.Length == 0)
      {
        MessageBox.Show("This data contains no signatures.", "No signatures",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        ShowSignatures(sigs);
      }
    });
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

  ExeGPG gpg;
  bool keyListInvalidated = true;
}

} // namespace GPGDesktop