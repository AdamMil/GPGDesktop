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
  MainForm()
  {
    InitializeComponent();
  }

  public MainForm(PGPSystem pgp)
  {
    if(pgp == null) throw new ArgumentNullException();
    this.pgp = pgp;
    InitializeComponent();
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

  void About()
  {
    new AboutBox().ShowDialog();
  }

  void Configure()
  {
  }

  void DecryptVerifyData()
  {
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

  void InvalidateKeyList()
  {
    keyListInvalidated = true;
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

  void txtPad_KeyDown(object sender, KeyEventArgs e)
  {
    if(!e.Handled && e.KeyCode == Keys.A && e.Modifiers == Keys.Control) // ctrl-a selects all text
    {
      txtPad.SelectAll();
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

  readonly PGPSystem pgp;
  bool keyListInvalidated = true;
}

} // namespace GPGDesktop