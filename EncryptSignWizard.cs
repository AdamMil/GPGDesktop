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
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AdamMil.Security.PGP;
using AdamMil.Security.UI;

namespace GPGDesktop
{

public partial class EncryptSignWizard : WizardBase
{
  public EncryptSignWizard(PGPSystem pgp)
  {
    if(pgp == null) throw new ArgumentNullException();
    this.pgp = pgp;
   
    InitializeComponent();

    txtDetachedSig.KeyDown  += text_KeyDown;
    txtInput.KeyDown        += text_KeyDown;
    txtRecipients.KeyDown   += text_KeyDown;
    txtSaveFile.KeyDown     += text_KeyDown;
    txtSourceFile.KeyDown   += text_KeyDown;

    PrimaryKey[] ownedKeys = pgp.GetKeys(ListOptions.RetrieveOnlySecretKeys | ListOptions.IgnoreUnusableKeys);
    if(ownedKeys.Length == 0)
    {
      rbNoSign.Checked = lblCantSign.Visible = true;

      chkEncryptToSelf.Enabled = chkEncryptToSelf.Checked = rbEmbedSig.Enabled = rbDetachedSig.Enabled =
        cmbSigningKey.Enabled = false;
    }
    else
    {
      foreach(PrimaryKey key in ownedKeys)
      {
        KeyItem item = new KeyItem(key);
        cmbSigningKey.Items.Add(item);
        cmbAlsoEncryptTo.Items.Add(item);
      }
      cmbSigningKey.SelectedIndex = cmbAlsoEncryptTo.SelectedIndex = 0;
    }
  }

  #region Input step
  void UpdateInputStepButtons()
  {
    wizard.EnableNextButton = !rbSourceFile.Checked || txtSourceFile.Text.Trim().Length != 0;
  }

  void btnSourceBrowse_Click(object sender, EventArgs e)
  {
    BrowseInputFiles(txtSourceFile, "All Files (*.*)|*.*", "Select the files to sign and/or encrypt", true);
  }

  void inputStep_UpdateButtons(object sender, EventArgs e)
  {
    UpdateInputStepButtons();
  }

  void rbSourceFile_CheckedChanged(object sender, EventArgs e)
  {
    txtSourceFile.Enabled = btnSourceBrowse.Enabled = rbSourceFile.Checked;
    UpdateInputStepButtons();
    if(rbSourceFile.Checked) btnSourceBrowse.Focus();
  }

  void rbManual_CheckedChanged(object sender, EventArgs e)
  {
    txtInput.Enabled = rbManual.Checked;
    UpdateInputStepButtons();
    if(rbManual.Checked) txtInput.Focus();
  }

  void inputStep_StepDisplayed(object sender, EventArgs e)
  {
    if(rbSourceFile.Checked) btnSourceBrowse.Focus();
    else if(rbManual.Checked) txtInput.Focus();
    UpdateInputStepButtons();
  }

  void inputStep_NextButtonClicked(object sender, CancelEventArgs e)
  {
    if(e.Cancel) return;

    multipleInputs = false;

    if(rbSourceClipboard.Checked)
    {
      inputText = Clipboard.GetText();

      if(string.IsNullOrEmpty(inputText))
      {
        MessageBox.Show("No text data could be found on the clipboard.", "Clipboard has no text",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        e.Cancel = true;
      }
    }
    else if(rbSourceFile.Checked)
    {
      inputText = null;

      if(txtSourceFile.Tag == null) // if the filename was entered manually, check that the files exist
      {
        txtSourceFile.Tag = ValidateInputFiles(txtSourceFile, "input", true);
        if(txtSourceFile.Tag == null) e.Cancel = true;
      }

      multipleInputs = txtSourceFile.Tag != null && ((string[])txtSourceFile.Tag).Length > 1;
    }
    else
    {
      inputText = txtInput.Text;
    }
  }

  void txtSourceFile_TextChanged(object sender, EventArgs e)
  {
    txtSourceFile.Tag = null;
    UpdateInputStepButtons();
  }
  #endregion

  #region Signing step
  void UpdateSigningStepButtons()
  {
    wizard.EnableNextButton = !rbDetachedSig.Checked || multipleInputs || txtDetachedSig.Text.Trim().Length != 0;
  }

  void btnSigBrowse_Click(object sender, EventArgs e)
  {
    BrowseOutputFile(txtDetachedSig, ".sig", "Signature Files (*.sig;*.sig.asc)|*.sig;*.sig.asc|ASCII Files (*.asc)|"+
                     "*.asc|All Files (*.*)|*.*", "Detached Signature",
                     rbSourceFile.Checked ? ((string[])txtSourceFile.Tag)[0] + ".sig" : "data.sig");
  }

  void rbDetachedSig_CheckedChanged(object sender, EventArgs e)
  {
    txtDetachedSig.Enabled = btnSigBrowse.Enabled = !multipleInputs && rbDetachedSig.Checked;

    UpdateSigningStepButtons();
    
    if(rbDetachedSig.Checked)
    {
      if(txtDetachedSig.TextLength == 0 && rbSourceFile.Checked && !multipleInputs)
      {
        txtDetachedSig.Text = ((string[])txtSourceFile.Tag)[0] + ".sig";
      }

      if(btnSigBrowse.Enabled) btnSigBrowse.Focus();
    }
  }

  void rbNoSign_CheckedChanged(object sender, EventArgs e)
  {
    cmbSigningKey.Enabled = !rbNoSign.Checked;
    UpdateSigningStepButtons();
  }

  void signStep_StepDisplayed(object sender, EventArgs e)
  {
    rbDetachedSig.Text = multipleInputs ? "Create &detached signatures and save them in the source file directory."
                                        : "Create a &detached signature and save it in this file:";
    if(rbDetachedSig.Checked) txtDetachedSig.Enabled = btnSigBrowse.Enabled = !multipleInputs;

    UpdateSigningStepButtons();
  }

  void signStep_UpdateButtons(object sender, EventArgs e)
  {
    UpdateSigningStepButtons();
  }

  void signStep_NextButtonClicked(object sender, CancelEventArgs e)
  {
    if(rbDetachedSig.Checked && !multipleInputs)
    {
      bool validFile = false;
      try
      {
        new FileInfo(txtDetachedSig.Text.Trim());
        validFile = true;
      }
      catch { }

      if(!validFile)
      {
        MessageBox.Show("The detached signature filename '" + txtDetachedSig.Text + "' is not valid.",
                        "Invalid filename", MessageBoxButtons.OK, MessageBoxIcon.Error);
        e.Cancel = true;
      }
    }
  }
  #endregion

  #region Encryption step
  bool ResolveRecipients()
  {
    if(txtRecipients.Tag == null)
    {
      string trimmed = txtRecipients.Text.Trim();
      if(!string.IsNullOrEmpty(trimmed))
      {
        List<PrimaryKey> keysFound = new List<PrimaryKey>();
        foreach(string search in trimmed.Split(';'))
        {
          string keyword = search.Trim();
          if(!string.IsNullOrEmpty(keyword))
          {
            PrimaryKey key = pgp.FindKey(keyword, ListOptions.IgnoreUnusableKeys);
            if(key != null)
            {
              keysFound.Add(key);
            }
            else
            {
              MessageBox.Show("The recipient '" + keyword + "' could not be found, or was ambiguous.",
                              "Recipient not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return false;
            }
          }
        }

        SetSelectedRecipients(keysFound.ToArray());
      }
    }

    return true;
  }

  void SetSelectedRecipients(PrimaryKey[] keys)
  {
    string text = null;
    foreach(PrimaryKey key in keys)
    {
      text += (text == null ? null : "; ") + key.PrimaryUserId.Name;
    }
    txtRecipients.Text = text;

    txtRecipients.Tag = keys.Length == 0 ? null : keys;
  }

  void UpdateEncryptStepButtons()
  {
    wizard.EnableNextButton = rbNoEncrypt.Checked || rbAsymmetric.Checked && txtRecipients.Text.Trim().Length != 0 ||
                              rbSymmetric.Checked && txtPassword.TextLength != 0;
  }

  void chkEncryptToSelf_CheckedChanged(object sender, EventArgs e)
  {
    cmbAlsoEncryptTo.Enabled = chkEncryptToSelf.Checked;
    if(chkEncryptToSelf.Checked) cmbAlsoEncryptTo.Focus();
  }

  void btnRecipBrowse_Click(object sender, EventArgs e)
  {
    RecipientSearchForm form = new RecipientSearchForm(pgp);
    if(form.ShowDialog() == DialogResult.OK) SetSelectedRecipients(form.GetSelectedRecipients());
  }

  void rbSymmetric_CheckedChanged(object sender, EventArgs e)
  {
    txtPassword.Enabled = txtPassword2.Enabled = rbSymmetric.Checked;
    UpdateEncryptStepButtons();
    if(rbSymmetric.Checked) txtPassword.Focus();
  }

  void encryptStep_NextButtonClicked(object sender, CancelEventArgs e)
  {
    if(!e.Cancel)
    {
      if(!ResolveRecipients() || !PGPUI.ValidatePasswords(txtPassword, txtPassword2)) e.Cancel = true;
    }
  }

  void encryptStep_StepDisplayed(object sender, EventArgs e)
  {
    rbNoEncrypt.Enabled = !rbNoSign.Checked;
    if(!rbNoEncrypt.Enabled && rbNoEncrypt.Checked) rbAsymmetric.Checked = true;

    if(rbSymmetric.Checked) txtPassword.Focus();
    else if(rbAsymmetric.Checked) btnRecipBrowse.Focus();

    cmbAlsoEncryptTo.SelectedIndex = cmbSigningKey.SelectedIndex;

    UpdateEncryptStepButtons();
  }

  void encryptStep_UpdateButtons(object sender, EventArgs e)
  {
    UpdateEncryptStepButtons();
  }

  void rbAsymmetric_CheckedChanged(object sender, EventArgs e)
  {
    txtRecipients.Enabled = btnRecipBrowse.Enabled = chkEncryptToSelf.Enabled = rbAsymmetric.Checked;
    cmbAlsoEncryptTo.Enabled = chkEncryptToSelf.Enabled && chkEncryptToSelf.Checked;

    UpdateEncryptStepButtons();
    
    if(rbAsymmetric.Checked) btnRecipBrowse.Focus();
  }

  void txtPassword_TextChanged(object sender, EventArgs e)
  {
    lblStrength.Text = "Password strength: " +
                       PGPUI.GetPasswordStrengthDescription(txtPassword.GetPasswordStrength());
    UpdateEncryptStepButtons();
  }

  void txtRecipients_Leave(object sender, EventArgs e)
  {
    ResolveRecipients();
    UpdateEncryptStepButtons();
  }

  void txtRecipients_TextChanged(object sender, EventArgs e)
  {
    txtRecipients.Tag = null;
    UpdateEncryptStepButtons();
  }
  #endregion

  #region Save step
  void UpdateSaveStepButtons()
  {
    wizard.EnableNextButton = !rbSaveFile.Checked || txtSaveFile.Text.Trim().Length != 0;
  }

  void btnSaveFileBrowse_Click(object sender, EventArgs e)
  {
    BrowseOutputFile(txtSaveFile, ".pgp", "PGP Files (*.pgp;*.pgp.asc)|*.pgp;*.pgp.asc|ASC Files (*.asc)|*.asc|"+
                     "All Files (*.*)|*.*", "Select the output file", null);
  }

  void rbSaveFile_CheckedChanged(object sender, EventArgs e)
  {
    txtSaveFile.Enabled = btnSaveFileBrowse.Enabled = rbSaveFile.Checked;
    UpdateSaveStepButtons();
    if(rbSaveFile.Checked) btnSaveFileBrowse.Focus();
  }

  void saveStep_StepDisplayed(object sender, EventArgs e)
  {
    bool detachedAndNoEncrypt = rbDetachedSig.Checked && rbNoEncrypt.Checked;

    rbOverwrite.Enabled = rbSaveNear.Enabled = inputText == null && !detachedAndNoEncrypt;
    rbSaveClipboard.Enabled = rbSaveFile.Enabled = txtSaveFile.Enabled = btnSaveFileBrowse.Enabled =
      !multipleInputs && !detachedAndNoEncrypt;

    if(rbSaveClipboard.Checked && !rbSaveClipboard.Enabled || rbOverwrite.Checked && !rbOverwrite.Enabled ||
       rbSaveNear.Checked && !rbSaveNear.Enabled || rbSaveFile.Checked && !rbSaveFile.Enabled ||
       !detachedAndNoEncrypt &&
         !rbOverwrite.Checked && !rbSaveNear.Checked && !rbSaveClipboard.Checked && !rbSaveFile.Checked)
    {
      if(rbSaveNear.Enabled) rbSaveNear.Checked = true;
      else if(rbSaveFile.Enabled) rbSaveFile.Checked = true;
      else
      {
        rbSaveClipboard.Checked = rbOverwrite.Checked = rbSaveNear.Checked = rbSaveFile.Checked = false;
        chkAscii.Focus();
      }
    }

    if(rbSaveFile.Checked) btnSaveFileBrowse.Focus();

    UpdateSaveStepButtons();
  }

  void rbSaveClipboard_CheckedChanged(object sender, EventArgs e)
  {
    chkAscii.Checked = rbSaveClipboard.Checked;
    chkAscii.Enabled = !rbSaveClipboard.Checked;
    UpdateSaveStepButtons();
  }

  void saveStep_FinishButtonClicked(object sender, CancelEventArgs e)
  {
    if(e.Cancel) return;

    EncryptionOptions encryptOptions = new EncryptionOptions();
    if(rbSymmetric.Checked) encryptOptions.Password = txtPassword.GetText();
    else if(rbAsymmetric.Checked)
    {
      encryptOptions.Recipients.AddRange((PrimaryKey[])txtRecipients.Tag);
      if(chkEncryptToSelf.Checked) encryptOptions.Recipients.Add(((KeyItem)cmbAlsoEncryptTo.SelectedItem).Value);
      encryptOptions.AlwaysTrustRecipients = true;
    }
    else encryptOptions = null;

    SigningOptions signingOptions = new SigningOptions();

    if(!rbNoSign.Checked && cmbSigningKey.SelectedIndex != -1)
    {
      signingOptions.Signers.Add(((KeyItem)cmbSigningKey.SelectedItem).Value);
    }

    if(rbEmbedSig.Checked)
    {
      signingOptions.Type = inputText != null && chkAscii.Checked && encryptOptions == null ?
        SignatureType.ClearSignedText : SignatureType.Embedded;
    }
    else if(rbDetachedSig.Checked) signingOptions.Type = SignatureType.Detached;
    else signingOptions = null;

    OutputOptions outputOptions = new OutputOptions(chkAscii.Checked ? OutputFormat.ASCII : OutputFormat.Binary);

    bool success = true;
    if(inputText != null) // we're encrypting/signing some literal text
    {
      progressBar.Style = ProgressBarStyle.Marquee;
      MemoryStream source = new MemoryStream(Encoding.UTF8.GetBytes(inputText), false);
      success = EncryptAndSign(source, null, encryptOptions, signingOptions, outputOptions);
    }
    else // we're encrypting/signing one or more files
    {
      string[] files = (string[])txtSourceFile.Tag;
      progressBar.Style   = ProgressBarStyle.Blocks;
      progressBar.Maximum = files.Length;
      wizard.CurrentStep.Enabled = false;
      foreach(string file in files)
      {
        success = EncryptAndSign(file, encryptOptions, signingOptions, outputOptions) && success;
        progressBar.Value++;
        Application.DoEvents();
      }
      wizard.CurrentStep.Enabled = true;
    }

    progressBar.Style = ProgressBarStyle.Blocks;
    progressBar.Value = 0;

    if(success)
    {
      string op = encryptOptions == null ? "Signing was" :
        signingOptions == null ? "Encryption was" : "Encryption and signing were";
      MessageBox.Show(op + " successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else
    {
      e.Cancel = true;
    }
  }
  #endregion

  bool EncryptAndSign(Stream srcStream, string srcFile, EncryptionOptions encryptOptions,
                      SigningOptions signingOptions, OutputOptions outputOptions)
  {
    Stream output = rbSaveClipboard.Checked ? (Stream)new MemoryStream() :
                    rbSaveFile.Checked ? new FileStream(txtSaveFile.Text, FileMode.Create, FileAccess.Write) : null;
    try
    {
      if(EncryptAndSign(srcStream, output, srcFile, encryptOptions, signingOptions, outputOptions))
      {
        if(rbSaveClipboard.Checked) Clipboard.SetText(Encoding.UTF8.GetString(((MemoryStream)output).ToArray()));
        return true;
      }
      else
      {
        return false;
      }
    }
    finally
    {
      if(output != null) output.Dispose();
    }
  }

  bool EncryptAndSign(string srcFile, EncryptionOptions encryptOptions, SigningOptions signingOptions,
                      OutputOptions outputOptions)
  {
    FileStream srcStream = null, outStream = null;
    string tempFile = null;
    bool success = false;

    try
    {
      try { srcStream = new FileStream(srcFile, FileMode.Open, FileAccess.Read); }
      catch(Exception ex)
      {
        ShowCantOpenFileMessage("input", srcFile, ex);
        return false;
      }

      if(rbOverwrite.Checked)
      {
        try
        {
          tempFile  = Path.GetTempFileName();
          outStream = new FileStream(tempFile, FileMode.Open, FileAccess.Write);
        }
        catch(Exception ex)
        {
          ShowCantOpenFileMessage("temporary", tempFile, ex);
          return false;
        }

        success = EncryptAndSign(srcStream, outStream, srcFile, encryptOptions, signingOptions, outputOptions);

        if(success)
        {
          srcStream.Close();
          outStream.Close();
          try 
          {
            File.Delete(srcFile);
            File.Move(tempFile, srcFile); 
          }
          catch(Exception ex)
          {
            MessageBox.Show("Unable to overwrite source file '" + srcFile + "'. The error was: " + ex.Message,
                            "Unable to overwrite file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            success = false;
          }
        }
      }
      else if(rbSaveNear.Checked)
      {
        outStream = GetNearFile(srcFile, chkAscii.Checked ? ".pgp.asc" : ".pgp", "output");
        if(outStream == null) return false;
        success = EncryptAndSign(srcStream, outStream, srcFile, encryptOptions, signingOptions, outputOptions);
      }
      else
      {
        success = EncryptAndSign(srcStream, srcFile, encryptOptions, signingOptions, outputOptions);
      }
    }
    finally
    {
      if(srcStream != null) srcStream.Dispose();
      if(outStream != null) outStream.Dispose();
      if(tempFile != null) File.Delete(tempFile);
    }

    return success;
  }

  bool EncryptAndSign(Stream srcStream, Stream destStream, string srcFile, EncryptionOptions encryptionOptions,
                      SigningOptions signingOptions, OutputOptions outputOptions)
  {
    try
    {
      if(rbDetachedSig.Checked)
      {
        Stream sigStream;

        if(txtDetachedSig.Enabled)
        {
          try { sigStream = new FileStream(txtDetachedSig.Text, FileMode.Create, FileAccess.Write); }
          catch(Exception ex)
          {
            ShowCantOpenFileMessage("signature", txtDetachedSig.Text, ex);
            return false;
          }
        }
        else
        {
          sigStream = GetNearFile(srcFile, chkAscii.Checked ? ".sig.asc" : ".sig", "signature");
          if(sigStream == null) return false;
        }

        using(sigStream) pgp.Sign(srcStream, sigStream, signingOptions, outputOptions);

        if(destStream != null)
        {
          srcStream.Position = 0;
          pgp.Encrypt(srcStream, destStream, encryptionOptions, outputOptions);
        }
      }
      else
      {
        pgp.SignAndEncrypt(srcStream, destStream, signingOptions, encryptionOptions, outputOptions);
      }

      return true;
    }
    catch(OperationCanceledException) { }
    catch(Exception ex) 
    { 
      MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error); 
    }

    return false;
  }

  PGPSystem pgp;
  string inputText;
  bool multipleInputs;
}

} // namespace GPGDesktop