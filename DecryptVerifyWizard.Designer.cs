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

namespace GPGDesktop
{
  partial class DecryptVerifyWizard
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      AdamMil.UI.Wizard.MiddleStep verifyStep;
      System.Windows.Forms.Label lblPassword;
      this.rbFileDetached = new System.Windows.Forms.RadioButton();
      this.btnSigBrowse = new System.Windows.Forms.Button();
      this.txtSigFile = new System.Windows.Forms.TextBox();
      this.rbEmbeddedSig = new System.Windows.Forms.RadioButton();
      this.rbNearDetached = new System.Windows.Forms.RadioButton();
      this.wizard = new AdamMil.UI.Wizard.Wizard();
      this.startStep = new AdamMil.UI.Wizard.StartStep();
      this.inputStep = new AdamMil.UI.Wizard.MiddleStep();
      this.btnSourceBrowse = new System.Windows.Forms.Button();
      this.txtSourceFile = new System.Windows.Forms.TextBox();
      this.rbSourceClipboard = new System.Windows.Forms.RadioButton();
      this.rbSourceFile = new System.Windows.Forms.RadioButton();
      this.saveStep = new AdamMil.UI.Wizard.MiddleStep();
      this.rbDontSave = new System.Windows.Forms.RadioButton();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.rbSaveNear = new System.Windows.Forms.RadioButton();
      this.rbSaveFile = new System.Windows.Forms.RadioButton();
      this.btnSaveFileBrowse = new System.Windows.Forms.Button();
      this.txtSaveFile = new System.Windows.Forms.TextBox();
      this.rbOverwrite = new System.Windows.Forms.RadioButton();
      this.txtPassword = new AdamMil.Security.UI.SecureTextBox();
      verifyStep = new AdamMil.UI.Wizard.MiddleStep();
      lblPassword = new System.Windows.Forms.Label();
      verifyStep.SuspendLayout();
      this.inputStep.SuspendLayout();
      this.saveStep.SuspendLayout();
      this.SuspendLayout();
      // 
      // verifyStep
      // 
      verifyStep.Controls.Add(this.rbFileDetached);
      verifyStep.Controls.Add(this.btnSigBrowse);
      verifyStep.Controls.Add(this.txtSigFile);
      verifyStep.Controls.Add(this.rbEmbeddedSig);
      verifyStep.Controls.Add(this.rbNearDetached);
      verifyStep.Dock = System.Windows.Forms.DockStyle.Fill;
      verifyStep.Location = new System.Drawing.Point(0, 0);
      verifyStep.Name = "verifyStep";
      verifyStep.Size = new System.Drawing.Size(511, 348);
      verifyStep.Subtitle = "Where are the signatures for this data?";
      verifyStep.TabIndex = 1;
      verifyStep.Title = "Signature Verification";
      verifyStep.StepDisplayed += new System.EventHandler(this.verifyStep_StepDisplayed);
      verifyStep.NextButtonClicked += new System.ComponentModel.CancelEventHandler(this.verifyStep_NextButtonClicked);
      // 
      // rbFileDetached
      // 
      this.rbFileDetached.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbFileDetached.Location = new System.Drawing.Point(12, 116);
      this.rbFileDetached.Name = "rbFileDetached";
      this.rbFileDetached.Size = new System.Drawing.Size(487, 17);
      this.rbFileDetached.TabIndex = 2;
      this.rbFileDetached.Text = "The signature is in this &file:";
      this.rbFileDetached.UseVisualStyleBackColor = true;
      this.rbFileDetached.CheckedChanged += new System.EventHandler(this.rbFileDetached_CheckedChanged);
      // 
      // btnSigBrowse
      // 
      this.btnSigBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSigBrowse.Enabled = false;
      this.btnSigBrowse.Location = new System.Drawing.Point(432, 139);
      this.btnSigBrowse.Name = "btnSigBrowse";
      this.btnSigBrowse.Size = new System.Drawing.Size(67, 21);
      this.btnSigBrowse.TabIndex = 4;
      this.btnSigBrowse.Text = "B&rowse";
      this.btnSigBrowse.UseVisualStyleBackColor = true;
      this.btnSigBrowse.Click += new System.EventHandler(this.btnSigBrowse_Click);
      // 
      // txtSigFile
      // 
      this.txtSigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSigFile.Enabled = false;
      this.txtSigFile.Location = new System.Drawing.Point(29, 139);
      this.txtSigFile.Name = "txtSigFile";
      this.txtSigFile.Size = new System.Drawing.Size(397, 21);
      this.txtSigFile.TabIndex = 3;
      this.txtSigFile.TextChanged += new System.EventHandler(this.verifyStep_UpdateButtons);
      // 
      // rbEmbeddedSig
      // 
      this.rbEmbeddedSig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbEmbeddedSig.Checked = true;
      this.rbEmbeddedSig.Location = new System.Drawing.Point(12, 72);
      this.rbEmbeddedSig.Name = "rbEmbeddedSig";
      this.rbEmbeddedSig.Size = new System.Drawing.Size(487, 17);
      this.rbEmbeddedSig.TabIndex = 0;
      this.rbEmbeddedSig.TabStop = true;
      this.rbEmbeddedSig.Text = "There are no signatures, or they are &embedded in the source data.";
      this.rbEmbeddedSig.UseVisualStyleBackColor = true;
      // 
      // rbNearDetached
      // 
      this.rbNearDetached.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbNearDetached.Location = new System.Drawing.Point(12, 95);
      this.rbNearDetached.Name = "rbNearDetached";
      this.rbNearDetached.Size = new System.Drawing.Size(487, 17);
      this.rbNearDetached.TabIndex = 1;
      this.rbNearDetached.Text = "The signatures are in the source file &directory, with .sig or .sig.asc extension" +
    "s.";
      this.rbNearDetached.UseVisualStyleBackColor = true;
      // 
      // wizard
      // 
      this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
      this.wizard.Location = new System.Drawing.Point(0, 0);
      this.wizard.Name = "wizard";
      this.wizard.ShowHelpButton = false;
      this.wizard.Size = new System.Drawing.Size(511, 386);
      this.wizard.Steps.Add(this.startStep);
      this.wizard.Steps.Add(this.inputStep);
      this.wizard.Steps.Add(verifyStep);
      this.wizard.Steps.Add(this.saveStep);
      this.wizard.TabIndex = 0;
      // 
      // startStep
      // 
      this.startStep.BackColor = System.Drawing.SystemColors.Window;
      this.startStep.Dock = System.Windows.Forms.DockStyle.Fill;
      this.startStep.HeaderOrientation = System.Windows.Forms.Orientation.Vertical;
      this.startStep.Location = new System.Drawing.Point(0, 0);
      this.startStep.Name = "startStep";
      this.startStep.Size = new System.Drawing.Size(511, 348);
      this.startStep.Subtitle = "This wizard will walk you through the process of decrypting and verifying data.";
      this.startStep.TabIndex = 0;
      this.startStep.Title = "Decryption and Verification";
      // 
      // inputStep
      // 
      this.inputStep.Controls.Add(this.btnSourceBrowse);
      this.inputStep.Controls.Add(this.txtSourceFile);
      this.inputStep.Controls.Add(this.rbSourceClipboard);
      this.inputStep.Controls.Add(this.rbSourceFile);
      this.inputStep.Dock = System.Windows.Forms.DockStyle.Fill;
      this.inputStep.Location = new System.Drawing.Point(0, 0);
      this.inputStep.Name = "inputStep";
      this.inputStep.Size = new System.Drawing.Size(511, 348);
      this.inputStep.Subtitle = "Where is the data that you want to decrypt or verify?";
      this.inputStep.TabIndex = 0;
      this.inputStep.Title = "Source Data";
      this.inputStep.StepDisplayed += new System.EventHandler(this.inputStep_StepDisplayed);
      this.inputStep.NextButtonClicked += new System.ComponentModel.CancelEventHandler(this.inputStep_NextButtonClicked);
      // 
      // btnSourceBrowse
      // 
      this.btnSourceBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSourceBrowse.Location = new System.Drawing.Point(432, 116);
      this.btnSourceBrowse.Name = "btnSourceBrowse";
      this.btnSourceBrowse.Size = new System.Drawing.Size(67, 21);
      this.btnSourceBrowse.TabIndex = 3;
      this.btnSourceBrowse.Text = "B&rowse";
      this.btnSourceBrowse.UseVisualStyleBackColor = true;
      this.btnSourceBrowse.Click += new System.EventHandler(this.btnSourceBrowse_Click);
      // 
      // txtSourceFile
      // 
      this.txtSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSourceFile.Location = new System.Drawing.Point(29, 116);
      this.txtSourceFile.Name = "txtSourceFile";
      this.txtSourceFile.Size = new System.Drawing.Size(397, 21);
      this.txtSourceFile.TabIndex = 2;
      this.txtSourceFile.TextChanged += new System.EventHandler(this.txtSourceFile_TextChanged);
      // 
      // rbSourceClipboard
      // 
      this.rbSourceClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbSourceClipboard.Location = new System.Drawing.Point(12, 72);
      this.rbSourceClipboard.Name = "rbSourceClipboard";
      this.rbSourceClipboard.Size = new System.Drawing.Size(487, 17);
      this.rbSourceClipboard.TabIndex = 0;
      this.rbSourceClipboard.Text = "It\'s on the &clipboard.";
      this.rbSourceClipboard.UseVisualStyleBackColor = true;
      this.rbSourceClipboard.CheckedChanged += new System.EventHandler(this.inputStep_UpdateButtons);
      // 
      // rbSourceFile
      // 
      this.rbSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbSourceFile.Checked = true;
      this.rbSourceFile.Location = new System.Drawing.Point(12, 95);
      this.rbSourceFile.Name = "rbSourceFile";
      this.rbSourceFile.Size = new System.Drawing.Size(487, 17);
      this.rbSourceFile.TabIndex = 1;
      this.rbSourceFile.TabStop = true;
      this.rbSourceFile.Text = "It\'s in a &file, or in multiple files:";
      this.rbSourceFile.UseVisualStyleBackColor = true;
      this.rbSourceFile.CheckedChanged += new System.EventHandler(this.rbSourceFile_CheckedChanged);
      // 
      // saveStep
      // 
      this.saveStep.Controls.Add(this.txtPassword);
      this.saveStep.Controls.Add(lblPassword);
      this.saveStep.Controls.Add(this.rbDontSave);
      this.saveStep.Controls.Add(this.progressBar);
      this.saveStep.Controls.Add(this.rbSaveNear);
      this.saveStep.Controls.Add(this.rbSaveFile);
      this.saveStep.Controls.Add(this.btnSaveFileBrowse);
      this.saveStep.Controls.Add(this.txtSaveFile);
      this.saveStep.Controls.Add(this.rbOverwrite);
      this.saveStep.Dock = System.Windows.Forms.DockStyle.Fill;
      this.saveStep.Location = new System.Drawing.Point(0, 0);
      this.saveStep.Name = "saveStep";
      this.saveStep.Size = new System.Drawing.Size(511, 348);
      this.saveStep.Subtitle = "Where should the original/decrypted data be saved?";
      this.saveStep.TabIndex = 0;
      this.saveStep.Title = "Destination";
      this.saveStep.StepDisplayed += new System.EventHandler(this.saveStep_StepDisplayed);
      this.saveStep.FinishButtonClicked += new System.ComponentModel.CancelEventHandler(this.saveStep_FinishButtonClicked);
      // 
      // rbDontSave
      // 
      this.rbDontSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbDontSave.Location = new System.Drawing.Point(12, 72);
      this.rbDontSave.Name = "rbDontSave";
      this.rbDontSave.Size = new System.Drawing.Size(487, 17);
      this.rbDontSave.TabIndex = 0;
      this.rbDontSave.Text = "&Don\'t save it. Just verify the signatures.";
      this.rbDontSave.UseVisualStyleBackColor = true;
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(4, 319);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(502, 23);
      this.progressBar.TabIndex = 7;
      // 
      // rbSaveNear
      // 
      this.rbSaveNear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbSaveNear.Checked = true;
      this.rbSaveNear.Location = new System.Drawing.Point(12, 117);
      this.rbSaveNear.Name = "rbSaveNear";
      this.rbSaveNear.Size = new System.Drawing.Size(487, 17);
      this.rbSaveNear.TabIndex = 3;
      this.rbSaveNear.TabStop = true;
      this.rbSaveNear.Text = "Save in the source file directory with a new file &extension.";
      this.rbSaveNear.UseVisualStyleBackColor = true;
      // 
      // rbSaveFile
      // 
      this.rbSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbSaveFile.Location = new System.Drawing.Point(12, 140);
      this.rbSaveFile.Name = "rbSaveFile";
      this.rbSaveFile.Size = new System.Drawing.Size(487, 17);
      this.rbSaveFile.TabIndex = 4;
      this.rbSaveFile.Text = "&Save it in a file:";
      this.rbSaveFile.UseVisualStyleBackColor = true;
      this.rbSaveFile.CheckedChanged += new System.EventHandler(this.rbSaveFile_CheckedChanged);
      // 
      // btnSaveFileBrowse
      // 
      this.btnSaveFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveFileBrowse.Enabled = false;
      this.btnSaveFileBrowse.Location = new System.Drawing.Point(432, 161);
      this.btnSaveFileBrowse.Name = "btnSaveFileBrowse";
      this.btnSaveFileBrowse.Size = new System.Drawing.Size(67, 21);
      this.btnSaveFileBrowse.TabIndex = 6;
      this.btnSaveFileBrowse.Text = "B&rowse";
      this.btnSaveFileBrowse.UseVisualStyleBackColor = true;
      this.btnSaveFileBrowse.Click += new System.EventHandler(this.btnSaveFileBrowse_Click);
      // 
      // txtSaveFile
      // 
      this.txtSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSaveFile.Enabled = false;
      this.txtSaveFile.Location = new System.Drawing.Point(30, 161);
      this.txtSaveFile.Name = "txtSaveFile";
      this.txtSaveFile.Size = new System.Drawing.Size(396, 21);
      this.txtSaveFile.TabIndex = 5;
      this.txtSaveFile.TextChanged += new System.EventHandler(this.saveStep_UpdateButtons);
      // 
      // rbOverwrite
      // 
      this.rbOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbOverwrite.Location = new System.Drawing.Point(12, 95);
      this.rbOverwrite.Name = "rbOverwrite";
      this.rbOverwrite.Size = new System.Drawing.Size(487, 17);
      this.rbOverwrite.TabIndex = 2;
      this.rbOverwrite.Text = "&Overwrite the source file(s).";
      this.rbOverwrite.UseVisualStyleBackColor = true;
      // 
      // lblPassword
      // 
      lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblPassword.Location = new System.Drawing.Point(9, 194);
      lblPassword.Name = "lblPassword";
      lblPassword.Size = new System.Drawing.Size(490, 21);
      lblPassword.TabIndex = 8;
      lblPassword.Text = "If the data is encrypted with a &password, enter it here:";
      lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtPassword
      // 
      this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
      this.txtPassword.Location = new System.Drawing.Point(30, 219);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(208, 21);
      this.txtPassword.TabIndex = 9;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // DecryptVerifyWizard
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(511, 386);
      this.Controls.Add(this.wizard);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DecryptVerifyWizard";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Decrypt and Verify";
      verifyStep.ResumeLayout(false);
      verifyStep.PerformLayout();
      this.inputStep.ResumeLayout(false);
      this.inputStep.PerformLayout();
      this.saveStep.ResumeLayout(false);
      this.saveStep.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private AdamMil.UI.Wizard.Wizard wizard;
    private AdamMil.UI.Wizard.StartStep startStep;
    private AdamMil.UI.Wizard.MiddleStep inputStep;
    private System.Windows.Forms.Button btnSourceBrowse;
    private System.Windows.Forms.TextBox txtSourceFile;
    private System.Windows.Forms.RadioButton rbSourceFile;
    private System.Windows.Forms.RadioButton rbSourceClipboard;
    private AdamMil.UI.Wizard.MiddleStep saveStep;
    private System.Windows.Forms.RadioButton rbSaveFile;
    private System.Windows.Forms.Button btnSaveFileBrowse;
    private System.Windows.Forms.TextBox txtSaveFile;
    private System.Windows.Forms.RadioButton rbOverwrite;
    private System.Windows.Forms.RadioButton rbSaveNear;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.RadioButton rbDontSave;
    private System.Windows.Forms.RadioButton rbFileDetached;
    private System.Windows.Forms.Button btnSigBrowse;
    private System.Windows.Forms.TextBox txtSigFile;
    private System.Windows.Forms.RadioButton rbEmbeddedSig;
    private System.Windows.Forms.RadioButton rbNearDetached;
    private AdamMil.Security.UI.SecureTextBox txtPassword;
  }
}