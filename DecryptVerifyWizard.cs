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

public partial class DecryptVerifyWizard : WizardBase
{
  public DecryptVerifyWizard(PGPSystem pgp)
  {
    if(pgp == null) throw new ArgumentNullException();
    this.pgp = pgp;
   
    InitializeComponent();

    txtSaveFile.KeyDown   += text_KeyDown;
    txtSigFile.KeyDown    += text_KeyDown;
    txtSourceFile.KeyDown += text_KeyDown;
  }

  #region Input step
  void UpdateInputStepButtons()
  {
    wizard.EnableNextButton = !rbSourceFile.Checked || txtSourceFile.Text.Trim().Length != 0;
  }

  void btnSourceBrowse_Click(object sender, EventArgs e)
  {
    BrowseInputFiles(txtSourceFile, "PGP Files (*.pgp;*.pgp.asc)|*.pgp;*.pgp.asc|All Files (*.*)|*.*",
                     "Select the files to decrypt and verify", true);
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

  void inputStep_StepDisplayed(object sender, EventArgs e)
  {
    if(rbSourceFile.Checked) btnSourceBrowse.Focus();
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
  }

  void txtSourceFile_TextChanged(object sender, EventArgs e)
  {
    txtSourceFile.Tag = null;
    UpdateInputStepButtons();
  }
  #endregion

  #region Verify step
  void UpdateVerifyStepButtons()
  {
    wizard.EnableNextButton = !rbFileDetached.Checked || txtSigFile.Text.Trim().Length != 0; 
  }

  void btnSigBrowse_Click(object sender, EventArgs e)
  {
    BrowseInputFiles(txtSigFile, "Signature Files (*.sig;*.sig.asc)|*.sig;*.sig.asc|All Files (*.*)|*.*",
                     "Select the signature file", false);
  }

  void rbFileDetached_CheckedChanged(object sender, EventArgs e)
  {
    txtSigFile.Enabled = btnSigBrowse.Enabled = rbFileDetached.Checked;
    UpdateVerifyStepButtons();
  }

  void verifyStep_StepDisplayed(object sender, EventArgs e)
  {
    rbFileDetached.Enabled = !multipleInputs;
    rbNearDetached.Enabled = inputText == null;

    if(rbNearDetached.Checked && rbNearDetached.Enabled || rbFileDetached.Checked && !rbFileDetached.Enabled)
    {
      rbEmbeddedSig.Checked = true;
    }

    if(rbFileDetached.Checked) btnSigBrowse.Focus();

    UpdateVerifyStepButtons();
  }

  void verifyStep_NextButtonClicked(object sender, CancelEventArgs e)
  {
    if(!e.Cancel && rbFileDetached.Checked && txtSigFile.Tag == null)
    {
      txtSigFile.Tag = ValidateInputFiles(txtSigFile, "signature", false);
      if(txtSigFile.Tag == null) e.Cancel = true;
    }
  }

  void verifyStep_UpdateButtons(object sender, EventArgs e)
  {
    UpdateVerifyStepButtons();
  }
  #endregion

  #region Save step
  void UpdateSaveStepButtons()
  {
    wizard.EnableNextButton = !rbSaveFile.Checked || txtSaveFile.Text.Trim().Length != 0;
  }

  void btnSaveFileBrowse_Click(object sender, EventArgs e)
  {
    BrowseOutputFile(txtSaveFile, "", "All Files (*.*)|*.*", "Select the output filename",
                     rbSourceFile.Checked ? GetOriginalFilename(((string[])txtSourceFile.Tag)[0]) : null);
  }

  void rbSaveFile_CheckedChanged(object sender, EventArgs e)
  {
    txtSaveFile.Enabled = btnSaveFileBrowse.Enabled = rbSaveFile.Checked;
    UpdateSaveStepButtons();
  }

  Signature[] DecryptAndVerify(Stream srcStream, string srcFile, DecryptionOptions options)
  {
    FileStream destStream = null;
    string tempFile = null;

    try
    {
      if(srcStream == null)
      {
        try { srcStream = new FileStream(srcFile, FileMode.Open, FileAccess.Read); }
        catch(Exception ex)
        {
          ShowCantOpenFileMessage("input", srcFile, ex);
          return null;
        }
      }

      if(rbSaveFile.Checked)
      {
        try { destStream = new FileStream(txtSaveFile.Text, FileMode.Create, FileAccess.ReadWrite); }
        catch(Exception ex)
        {
          ShowCantOpenFileMessage("output", txtSaveFile.Text, ex);
          return null;
        }
      }
      else if(srcFile != null)
      {
        if(rbOverwrite.Checked)
        {
          try
          {
            tempFile   = Path.GetTempFileName();
            destStream = new FileStream(tempFile, FileMode.Open, FileAccess.ReadWrite);
          }
          catch(Exception ex)
          {
            ShowCantOpenFileMessage("temporary", tempFile, ex);
            return null;
          }
        }
        else if(rbSaveNear.Checked)
        {
          string destFile = GetOriginalFilename(srcFile);

          if(srcFile.Length != destFile.Length && !File.Exists(destFile))
          {
            try { destStream = new FileStream(destFile, FileMode.CreateNew, FileAccess.ReadWrite); }
            catch { }
          }

          if(destStream == null)
          {
            destStream = GetNearFile(Path.GetFileNameWithoutExtension(destFile),
                                     ".orig" + Path.GetExtension(destFile), "output");
            if(destStream == null) return null;
          }
        }
      }

      bool srcWasUnencrypted;
      Signature[] sigs = DecryptAndVerify(srcStream, destStream, srcFile, options, out srcWasUnencrypted);

      if(sigs != null)
      {
        if(srcWasUnencrypted && !rbDontSave.Checked)
        {
          destStream.SetLength(0);
          AdamMil.IO.IOH.CopyStream(srcStream, destStream, false, true);
        }
        else if(!srcWasUnencrypted && rbOverwrite.Checked)
        {
          srcStream.Close();
          destStream.Close();
          try 
          {
            File.Delete(srcFile);
            File.Move(tempFile, srcFile); 
          }
          catch(Exception ex)
          {
            MessageBox.Show("Unable to overwrite source file '" + srcFile + "'. The error was: " + ex.Message,
                            "Unable to overwrite file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            sigs = null;
          }
        }
      }

      return sigs;
    }
    finally
    {
      if(srcStream != null) srcStream.Dispose();
      if(destStream != null) destStream.Dispose();
      if(tempFile != null) File.Delete(tempFile);
    }
  }

  Signature[] DecryptAndVerify(Stream srcStream, Stream destStream, string srcFile, DecryptionOptions options,
                               out bool srcWasUnencrypted)
  {
    Stream sigStream = null;
    string sigFile = null;

    srcWasUnencrypted = false;

    if(rbFileDetached.Checked)
    {
      sigFile = ((string[])txtSigFile.Tag)[0];
    }
    else if(rbNearDetached.Checked)
    {
      sigFile = GetOriginalFilename(srcFile) + ".sig";
      if(!File.Exists(sigFile))
      {
        sigFile += ".asc";
        if(!File.Exists(sigFile)) sigFile = null;
      }
    }

    if(sigFile != null)
    {
      try { sigStream = new FileStream(sigFile, FileMode.Open, FileAccess.Read); }
      catch(Exception ex)
      {
        ShowCantOpenFileMessage("signature", sigFile, ex);
        return null;
      }
    }

    Signature[] sigs = null;
    try
    {
      if(sigStream != null) // we have a detached signature
      {
        string tempFile = null;

        try
        {
          if(destStream == null)
          {
            try
            {
              tempFile   = Path.GetTempFileName();
              destStream = new FileStream(tempFile, FileMode.Create, FileAccess.ReadWrite);
            }
            catch(Exception ex)
            {
              ShowCantOpenFileMessage("temporary", tempFile, ex);
              return null;
            }
          }

          try
          {
            pgp.Decrypt(srcStream, destStream, options);
            destStream.Position = 0;
            sigs = pgp.Verify(destStream, sigStream);
          }
          catch(DecryptionFailedException ex)
          {
            if(ex.Reasons != FailureReason.BadData) throw;

            srcWasUnencrypted  = true;
            sigStream.Position = srcStream.Position = 0;
            sigs = pgp.Verify(srcStream, sigStream);
          }
        }
        finally
        {
          if(tempFile != null)
          {
            destStream.Dispose();
            File.Delete(tempFile);
          }
        }
      }
      else // we have no signature, or an embedded signature
      {
        try { sigs = pgp.Decrypt(srcStream, destStream == null ? Stream.Null : destStream, options); }
        catch(DecryptionFailedException ex)
        {
          if(ex.Reasons != FailureReason.BadData) throw;

          srcWasUnencrypted  = true;
          srcStream.Position = 0;
          sigs = pgp.Verify(srcStream);
        }
      }
    }
    catch(OperationCanceledException) { }
    catch(Exception ex)
    {
      MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    return sigs;
  }

  void saveStep_FinishButtonClicked(object sender, CancelEventArgs e)
  {
    if(e.Cancel) return;

    Dictionary<string, Signature[]> fileSigs = new Dictionary<string, Signature[]>(StringComparer.Ordinal);
    bool totalSuccess = true, someSuccess = false;

    DecryptionOptions options = txtPassword.TextLength == 0 ? null : new DecryptionOptions(txtPassword.GetText());

    if(inputText != null)
    {
      progressBar.Style = ProgressBarStyle.Marquee;
      Signature[] sigs = DecryptAndVerify(new MemoryStream(Encoding.UTF8.GetBytes(inputText), false), null, options);
      if(sigs == null) totalSuccess = false;
      else someSuccess = true;
      fileSigs["Clipboard data"] = sigs;
    }
    else
    {
      string[] files = (string[])txtSourceFile.Tag;

      progressBar.Style   = ProgressBarStyle.Blocks;
      progressBar.Maximum = files.Length;
      wizard.CurrentStep.Enabled = false;
      foreach(string file in files)
      {
        Signature[] sigs = DecryptAndVerify(null, file, options);
        if(sigs == null) totalSuccess = false;
        else someSuccess = true;
        fileSigs[Path.GetFileName(file)] = sigs;

        progressBar.Value++;
        Application.DoEvents();
      }
      wizard.CurrentStep.Enabled = true;
    }

    progressBar.Style = ProgressBarStyle.Blocks;
    progressBar.Value = 0;

    if(someSuccess)
    {
      if(totalSuccess && !multipleInputs)
      {
        foreach(Signature[] sigs in fileSigs.Values)
        {
          new SignaturesForm(sigs).ShowDialog();
          break;
        }
      }
      else
      {
        new SignaturesForm(fileSigs).ShowDialog();
      }
    }

    if(!totalSuccess) e.Cancel = true;
  }

  void saveStep_StepDisplayed(object sender, EventArgs e)
  {
    rbOverwrite.Enabled = rbSaveNear.Enabled = inputText == null;
    rbSaveFile.Enabled  = !multipleInputs;

    if(rbOverwrite.Checked && !rbOverwrite.Enabled || rbSaveNear.Checked && !rbSaveNear.Enabled)
    {
      rbSaveFile.Checked = true;
    }

    if(rbSaveFile.Checked && !rbSaveFile.Enabled) rbDontSave.Checked = true;

    if(rbSaveFile.Checked) btnSaveFileBrowse.Focus();

    UpdateSaveStepButtons();
  }

  void saveStep_UpdateButtons(object sender, EventArgs e)
  {
    UpdateSaveStepButtons();
  }
  #endregion

  PGPSystem pgp;
  string inputText;
  bool multipleInputs;

  static string GetOriginalFilename(string srcFilename)
  {
    if(srcFilename.EndsWith(".pgp.asc", StringComparison.OrdinalIgnoreCase))
    {
      srcFilename = srcFilename.Substring(0, srcFilename.Length-8);
    }
    else if(srcFilename.EndsWith(".pgp", StringComparison.OrdinalIgnoreCase))
    {
      srcFilename = srcFilename.Substring(0, srcFilename.Length-4);
    }
    return srcFilename;
  }
}

} // namespace GPGDesktop