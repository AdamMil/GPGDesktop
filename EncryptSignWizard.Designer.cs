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
  partial class EncryptSignWizard
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
      System.Windows.Forms.Label lblRepeat;
      this.wizard = new AdamMil.UI.Wizard.Wizard();
      this.startStep = new AdamMil.UI.Wizard.StartStep();
      this.inputStep = new AdamMil.UI.Wizard.IntermediateStep();
      this.txtInput = new System.Windows.Forms.TextBox();
      this.rbManual = new System.Windows.Forms.RadioButton();
      this.btnSourceBrowse = new System.Windows.Forms.Button();
      this.txtSourceFile = new System.Windows.Forms.TextBox();
      this.rbSourceClipboard = new System.Windows.Forms.RadioButton();
      this.rbSourceFile = new System.Windows.Forms.RadioButton();
      this.signStep = new AdamMil.UI.Wizard.IntermediateStep();
      this.lblCantSign = new System.Windows.Forms.Label();
      this.cmbSigningKey = new System.Windows.Forms.ComboBox();
      this.lblSigningKey = new System.Windows.Forms.Label();
      this.btnSigBrowse = new System.Windows.Forms.Button();
      this.txtDetachedSig = new System.Windows.Forms.TextBox();
      this.rbDetachedSig = new System.Windows.Forms.RadioButton();
      this.rbEmbedSig = new System.Windows.Forms.RadioButton();
      this.rbNoSign = new System.Windows.Forms.RadioButton();
      this.encryptStep = new AdamMil.UI.Wizard.IntermediateStep();
      this.chkEncryptToSelf = new System.Windows.Forms.CheckBox();
      this.cmbAlsoEncryptTo = new System.Windows.Forms.ComboBox();
      this.lblStrength = new System.Windows.Forms.Label();
      this.txtPassword = new AdamMil.Security.UI.SecureTextBox();
      this.btnRecipBrowse = new System.Windows.Forms.Button();
      this.txtRecipients = new System.Windows.Forms.TextBox();
      this.rbAsymmetric = new System.Windows.Forms.RadioButton();
      this.rbSymmetric = new System.Windows.Forms.RadioButton();
      this.rbNoEncrypt = new System.Windows.Forms.RadioButton();
      this.saveStep = new AdamMil.UI.Wizard.IntermediateStep();
      this.rbSaveNear = new System.Windows.Forms.RadioButton();
      this.chkAscii = new System.Windows.Forms.CheckBox();
      this.rbSaveFile = new System.Windows.Forms.RadioButton();
      this.btnSaveFileBrowse = new System.Windows.Forms.Button();
      this.txtSaveFile = new System.Windows.Forms.TextBox();
      this.rbOverwrite = new System.Windows.Forms.RadioButton();
      this.rbSaveClipboard = new System.Windows.Forms.RadioButton();
      this.txtPassword2 = new AdamMil.Security.UI.SecureTextBox();
      lblRepeat = new System.Windows.Forms.Label();
      this.inputStep.SuspendLayout();
      this.signStep.SuspendLayout();
      this.encryptStep.SuspendLayout();
      this.saveStep.SuspendLayout();
      this.SuspendLayout();
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
      this.wizard.Steps.Add(this.signStep);
      this.wizard.Steps.Add(this.encryptStep);
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
      this.startStep.Subtitle = "This wizard will walk you through the process of signing and/or encrypting data.";
      this.startStep.TabIndex = 0;
      this.startStep.Title = "Signing and Encryption";
      // 
      // inputStep
      // 
      this.inputStep.Controls.Add(this.txtInput);
      this.inputStep.Controls.Add(this.rbManual);
      this.inputStep.Controls.Add(this.btnSourceBrowse);
      this.inputStep.Controls.Add(this.txtSourceFile);
      this.inputStep.Controls.Add(this.rbSourceClipboard);
      this.inputStep.Controls.Add(this.rbSourceFile);
      this.inputStep.Dock = System.Windows.Forms.DockStyle.Fill;
      this.inputStep.Location = new System.Drawing.Point(0, 0);
      this.inputStep.Name = "inputStep";
      this.inputStep.Size = new System.Drawing.Size(511, 348);
      this.inputStep.Subtitle = "Where is the data that you want to sign or encrypt?";
      this.inputStep.TabIndex = 0;
      this.inputStep.Title = "Source Data";
      this.inputStep.StepDisplayed += new System.EventHandler(this.inputStep_StepDisplayed);
      this.inputStep.NextButtonClicked += new System.ComponentModel.CancelEventHandler(this.inputStep_NextButtonClicked);
      // 
      // txtInput
      // 
      this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtInput.Enabled = false;
      this.txtInput.Location = new System.Drawing.Point(29, 166);
      this.txtInput.MaxLength = 0;
      this.txtInput.Multiline = true;
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new System.Drawing.Size(470, 170);
      this.txtInput.TabIndex = 5;
      this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
      // 
      // rbManual
      // 
      this.rbManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbManual.Location = new System.Drawing.Point(12, 143);
      this.rbManual.Name = "rbManual";
      this.rbManual.Size = new System.Drawing.Size(487, 17);
      this.rbManual.TabIndex = 4;
      this.rbManual.Text = "I\'m going to &type it in here:";
      this.rbManual.UseVisualStyleBackColor = true;
      this.rbManual.CheckedChanged += new System.EventHandler(this.rbManual_CheckedChanged);
      // 
      // btnSourceBrowse
      // 
      this.btnSourceBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSourceBrowse.Location = new System.Drawing.Point(432, 116);
      this.btnSourceBrowse.Name = "btnSourceBrowse";
      this.btnSourceBrowse.Size = new System.Drawing.Size(67, 21);
      this.btnSourceBrowse.TabIndex = 3;
      this.btnSourceBrowse.Text = "&Browse";
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
      this.txtSourceFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
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
      // signStep
      // 
      this.signStep.Controls.Add(this.lblCantSign);
      this.signStep.Controls.Add(this.cmbSigningKey);
      this.signStep.Controls.Add(this.lblSigningKey);
      this.signStep.Controls.Add(this.btnSigBrowse);
      this.signStep.Controls.Add(this.txtDetachedSig);
      this.signStep.Controls.Add(this.rbDetachedSig);
      this.signStep.Controls.Add(this.rbEmbedSig);
      this.signStep.Controls.Add(this.rbNoSign);
      this.signStep.Dock = System.Windows.Forms.DockStyle.Fill;
      this.signStep.Location = new System.Drawing.Point(0, 0);
      this.signStep.Name = "signStep";
      this.signStep.Size = new System.Drawing.Size(511, 348);
      this.signStep.Subtitle = "Signing data allows people to know that it came from you, and that it has not bee" +
    "n corrupted or tampered with.";
      this.signStep.TabIndex = 0;
      this.signStep.Title = "Signing";
      this.signStep.StepDisplayed += new System.EventHandler(this.signStep_StepDisplayed);
      this.signStep.NextButtonClicked += new System.ComponentModel.CancelEventHandler(this.signStep_NextButtonClicked);
      // 
      // lblCantSign
      // 
      this.lblCantSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCantSign.Location = new System.Drawing.Point(9, 229);
      this.lblCantSign.Name = "lblCantSign";
      this.lblCantSign.Size = new System.Drawing.Size(490, 41);
      this.lblCantSign.TabIndex = 16;
      this.lblCantSign.Text = "You cannot sign data because you do not have any key pairs with secret keys. If y" +
    "ou want to sign the data, first generate a key pair for yourself.";
      this.lblCantSign.Visible = false;
      // 
      // cmbSigningKey
      // 
      this.cmbSigningKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbSigningKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbSigningKey.FormattingEnabled = true;
      this.cmbSigningKey.Location = new System.Drawing.Point(29, 195);
      this.cmbSigningKey.Name = "cmbSigningKey";
      this.cmbSigningKey.Size = new System.Drawing.Size(470, 21);
      this.cmbSigningKey.TabIndex = 6;
      // 
      // lblSigningKey
      // 
      this.lblSigningKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblSigningKey.Location = new System.Drawing.Point(9, 171);
      this.lblSigningKey.Name = "lblSigningKey";
      this.lblSigningKey.Size = new System.Drawing.Size(490, 21);
      this.lblSigningKey.TabIndex = 5;
      this.lblSigningKey.Text = "Use this &key to sign the data:";
      this.lblSigningKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnSigBrowse
      // 
      this.btnSigBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSigBrowse.Enabled = false;
      this.btnSigBrowse.Location = new System.Drawing.Point(432, 147);
      this.btnSigBrowse.Name = "btnSigBrowse";
      this.btnSigBrowse.Size = new System.Drawing.Size(67, 21);
      this.btnSigBrowse.TabIndex = 4;
      this.btnSigBrowse.Text = "&Browse";
      this.btnSigBrowse.UseVisualStyleBackColor = true;
      this.btnSigBrowse.Click += new System.EventHandler(this.btnSigBrowse_Click);
      // 
      // txtDetachedSig
      // 
      this.txtDetachedSig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDetachedSig.Enabled = false;
      this.txtDetachedSig.Location = new System.Drawing.Point(29, 147);
      this.txtDetachedSig.Name = "txtDetachedSig";
      this.txtDetachedSig.Size = new System.Drawing.Size(397, 21);
      this.txtDetachedSig.TabIndex = 3;
      this.txtDetachedSig.TextChanged += new System.EventHandler(this.signStep_UpdateButtons);
      this.txtDetachedSig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
      // 
      // rbDetachedSig
      // 
      this.rbDetachedSig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbDetachedSig.Location = new System.Drawing.Point(12, 127);
      this.rbDetachedSig.Name = "rbDetachedSig";
      this.rbDetachedSig.Size = new System.Drawing.Size(487, 17);
      this.rbDetachedSig.TabIndex = 2;
      this.rbDetachedSig.Text = "Create a &detached signature and save it in this file:";
      this.rbDetachedSig.UseVisualStyleBackColor = true;
      this.rbDetachedSig.CheckedChanged += new System.EventHandler(this.rbDetachedSig_CheckedChanged);
      // 
      // rbEmbedSig
      // 
      this.rbEmbedSig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbEmbedSig.Checked = true;
      this.rbEmbedSig.Location = new System.Drawing.Point(12, 104);
      this.rbEmbedSig.Name = "rbEmbedSig";
      this.rbEmbedSig.Size = new System.Drawing.Size(487, 17);
      this.rbEmbedSig.TabIndex = 1;
      this.rbEmbedSig.TabStop = true;
      this.rbEmbedSig.Text = "&Embed the signature in the data.";
      this.rbEmbedSig.UseVisualStyleBackColor = true;
      // 
      // rbNoSign
      // 
      this.rbNoSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbNoSign.Location = new System.Drawing.Point(12, 81);
      this.rbNoSign.Name = "rbNoSign";
      this.rbNoSign.Size = new System.Drawing.Size(487, 17);
      this.rbNoSign.TabIndex = 0;
      this.rbNoSign.Text = "D&on\'t sign the data.";
      this.rbNoSign.UseVisualStyleBackColor = true;
      this.rbNoSign.CheckedChanged += new System.EventHandler(this.rbNoSign_CheckedChanged);
      // 
      // encryptStep
      // 
      this.encryptStep.Controls.Add(lblRepeat);
      this.encryptStep.Controls.Add(this.txtPassword2);
      this.encryptStep.Controls.Add(this.chkEncryptToSelf);
      this.encryptStep.Controls.Add(this.cmbAlsoEncryptTo);
      this.encryptStep.Controls.Add(this.lblStrength);
      this.encryptStep.Controls.Add(this.txtPassword);
      this.encryptStep.Controls.Add(this.btnRecipBrowse);
      this.encryptStep.Controls.Add(this.txtRecipients);
      this.encryptStep.Controls.Add(this.rbAsymmetric);
      this.encryptStep.Controls.Add(this.rbSymmetric);
      this.encryptStep.Controls.Add(this.rbNoEncrypt);
      this.encryptStep.Dock = System.Windows.Forms.DockStyle.Fill;
      this.encryptStep.Location = new System.Drawing.Point(0, 0);
      this.encryptStep.Name = "encryptStep";
      this.encryptStep.Size = new System.Drawing.Size(511, 348);
      this.encryptStep.Subtitle = "How should the data be encrypted?";
      this.encryptStep.TabIndex = 0;
      this.encryptStep.Title = "Encryption";
      this.encryptStep.StepDisplayed += new System.EventHandler(this.encryptStep_StepDisplayed);
      this.encryptStep.NextButtonClicked += new System.ComponentModel.CancelEventHandler(this.encryptStep_NextButtonClicked);
      // 
      // chkEncryptToSelf
      // 
      this.chkEncryptToSelf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkEncryptToSelf.Checked = true;
      this.chkEncryptToSelf.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkEncryptToSelf.Location = new System.Drawing.Point(29, 218);
      this.chkEncryptToSelf.Name = "chkEncryptToSelf";
      this.chkEncryptToSelf.Size = new System.Drawing.Size(470, 17);
      this.chkEncryptToSelf.TabIndex = 9;
      this.chkEncryptToSelf.Text = "Also encrypt to &myself:";
      this.chkEncryptToSelf.UseVisualStyleBackColor = true;
      this.chkEncryptToSelf.CheckedChanged += new System.EventHandler(this.chkEncryptToSelf_CheckedChanged);
      // 
      // cmbAlsoEncryptTo
      // 
      this.cmbAlsoEncryptTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbAlsoEncryptTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbAlsoEncryptTo.FormattingEnabled = true;
      this.cmbAlsoEncryptTo.Location = new System.Drawing.Point(29, 239);
      this.cmbAlsoEncryptTo.Name = "cmbAlsoEncryptTo";
      this.cmbAlsoEncryptTo.Size = new System.Drawing.Size(470, 21);
      this.cmbAlsoEncryptTo.TabIndex = 10;
      // 
      // lblStrength
      // 
      this.lblStrength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblStrength.Location = new System.Drawing.Point(234, 117);
      this.lblStrength.Name = "lblStrength";
      this.lblStrength.Size = new System.Drawing.Size(265, 21);
      this.lblStrength.TabIndex = 3;
      this.lblStrength.Text = "Password strength:";
      this.lblStrength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtPassword
      // 
      this.txtPassword.Enabled = false;
      this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
      this.txtPassword.Location = new System.Drawing.Point(29, 117);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(198, 21);
      this.txtPassword.TabIndex = 2;
      this.txtPassword.UseSystemPasswordChar = true;
      this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
      // 
      // btnRecipBrowse
      // 
      this.btnRecipBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRecipBrowse.Location = new System.Drawing.Point(432, 191);
      this.btnRecipBrowse.Name = "btnRecipBrowse";
      this.btnRecipBrowse.Size = new System.Drawing.Size(67, 21);
      this.btnRecipBrowse.TabIndex = 8;
      this.btnRecipBrowse.Text = "&Browse";
      this.btnRecipBrowse.UseVisualStyleBackColor = true;
      this.btnRecipBrowse.Click += new System.EventHandler(this.btnRecipBrowse_Click);
      // 
      // txtRecipients
      // 
      this.txtRecipients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtRecipients.Location = new System.Drawing.Point(29, 191);
      this.txtRecipients.Name = "txtRecipients";
      this.txtRecipients.Size = new System.Drawing.Size(397, 21);
      this.txtRecipients.TabIndex = 7;
      this.txtRecipients.TextChanged += new System.EventHandler(this.txtRecipients_TextChanged);
      this.txtRecipients.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
      this.txtRecipients.Leave += new System.EventHandler(this.txtRecipients_Leave);
      // 
      // rbAsymmetric
      // 
      this.rbAsymmetric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbAsymmetric.Checked = true;
      this.rbAsymmetric.Location = new System.Drawing.Point(12, 171);
      this.rbAsymmetric.Name = "rbAsymmetric";
      this.rbAsymmetric.Size = new System.Drawing.Size(487, 17);
      this.rbAsymmetric.TabIndex = 6;
      this.rbAsymmetric.TabStop = true;
      this.rbAsymmetric.Text = "Encrypt to &recipients using their public keys:";
      this.rbAsymmetric.UseVisualStyleBackColor = true;
      this.rbAsymmetric.CheckedChanged += new System.EventHandler(this.rbAsymmetric_CheckedChanged);
      // 
      // rbSymmetric
      // 
      this.rbSymmetric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbSymmetric.Location = new System.Drawing.Point(12, 95);
      this.rbSymmetric.Name = "rbSymmetric";
      this.rbSymmetric.Size = new System.Drawing.Size(487, 17);
      this.rbSymmetric.TabIndex = 1;
      this.rbSymmetric.Text = "Encrypt the data with a &password:";
      this.rbSymmetric.UseVisualStyleBackColor = true;
      this.rbSymmetric.CheckedChanged += new System.EventHandler(this.rbSymmetric_CheckedChanged);
      // 
      // rbNoEncrypt
      // 
      this.rbNoEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbNoEncrypt.Location = new System.Drawing.Point(12, 72);
      this.rbNoEncrypt.Name = "rbNoEncrypt";
      this.rbNoEncrypt.Size = new System.Drawing.Size(487, 17);
      this.rbNoEncrypt.TabIndex = 0;
      this.rbNoEncrypt.Text = "D&on\'t encrypt the data.";
      this.rbNoEncrypt.UseVisualStyleBackColor = true;
      this.rbNoEncrypt.CheckedChanged += new System.EventHandler(this.encryptStep_UpdateButtons);
      // 
      // saveStep
      // 
      this.saveStep.Controls.Add(this.rbSaveNear);
      this.saveStep.Controls.Add(this.chkAscii);
      this.saveStep.Controls.Add(this.rbSaveFile);
      this.saveStep.Controls.Add(this.btnSaveFileBrowse);
      this.saveStep.Controls.Add(this.txtSaveFile);
      this.saveStep.Controls.Add(this.rbOverwrite);
      this.saveStep.Controls.Add(this.rbSaveClipboard);
      this.saveStep.Dock = System.Windows.Forms.DockStyle.Fill;
      this.saveStep.Location = new System.Drawing.Point(0, 0);
      this.saveStep.Name = "saveStep";
      this.saveStep.Size = new System.Drawing.Size(511, 348);
      this.saveStep.Subtitle = "Where should the data be saved?";
      this.saveStep.TabIndex = 0;
      this.saveStep.Title = "Destination";
      this.saveStep.StepDisplayed += new System.EventHandler(this.saveStep_StepDisplayed);
      this.saveStep.FinishButtonClicked += new System.ComponentModel.CancelEventHandler(this.saveStep_FinishButtonClicked);
      // 
      // rbSaveNear
      // 
      this.rbSaveNear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbSaveNear.Checked = true;
      this.rbSaveNear.Location = new System.Drawing.Point(12, 117);
      this.rbSaveNear.Name = "rbSaveNear";
      this.rbSaveNear.Size = new System.Drawing.Size(487, 17);
      this.rbSaveNear.TabIndex = 2;
      this.rbSaveNear.TabStop = true;
      this.rbSaveNear.Text = "Save in the source file directory with a .pgp file &extension.";
      this.rbSaveNear.UseVisualStyleBackColor = true;
      // 
      // chkAscii
      // 
      this.chkAscii.AutoSize = true;
      this.chkAscii.Location = new System.Drawing.Point(12, 190);
      this.chkAscii.Name = "chkAscii";
      this.chkAscii.Size = new System.Drawing.Size(201, 17);
      this.chkAscii.TabIndex = 6;
      this.chkAscii.Text = "Save in a &text (ASCII) format.";
      this.chkAscii.UseVisualStyleBackColor = true;
      // 
      // rbSaveFile
      // 
      this.rbSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbSaveFile.Location = new System.Drawing.Point(12, 140);
      this.rbSaveFile.Name = "rbSaveFile";
      this.rbSaveFile.Size = new System.Drawing.Size(487, 17);
      this.rbSaveFile.TabIndex = 3;
      this.rbSaveFile.Text = "Save it in a &file:";
      this.rbSaveFile.UseVisualStyleBackColor = true;
      this.rbSaveFile.CheckedChanged += new System.EventHandler(this.rbSaveFile_CheckedChanged);
      // 
      // btnSaveFileBrowse
      // 
      this.btnSaveFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveFileBrowse.Location = new System.Drawing.Point(432, 161);
      this.btnSaveFileBrowse.Name = "btnSaveFileBrowse";
      this.btnSaveFileBrowse.Size = new System.Drawing.Size(67, 21);
      this.btnSaveFileBrowse.TabIndex = 5;
      this.btnSaveFileBrowse.Text = "&Browse";
      this.btnSaveFileBrowse.UseVisualStyleBackColor = true;
      this.btnSaveFileBrowse.Click += new System.EventHandler(this.btnSaveFileBrowse_Click);
      // 
      // txtSaveFile
      // 
      this.txtSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSaveFile.Location = new System.Drawing.Point(30, 161);
      this.txtSaveFile.Name = "txtSaveFile";
      this.txtSaveFile.Size = new System.Drawing.Size(396, 21);
      this.txtSaveFile.TabIndex = 4;
      this.txtSaveFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
      // 
      // rbOverwrite
      // 
      this.rbOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbOverwrite.Location = new System.Drawing.Point(12, 95);
      this.rbOverwrite.Name = "rbOverwrite";
      this.rbOverwrite.Size = new System.Drawing.Size(487, 17);
      this.rbOverwrite.TabIndex = 1;
      this.rbOverwrite.Text = "&Overwrite the source file(s).";
      this.rbOverwrite.UseVisualStyleBackColor = true;
      // 
      // rbSaveClipboard
      // 
      this.rbSaveClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbSaveClipboard.Location = new System.Drawing.Point(12, 72);
      this.rbSaveClipboard.Name = "rbSaveClipboard";
      this.rbSaveClipboard.Size = new System.Drawing.Size(487, 17);
      this.rbSaveClipboard.TabIndex = 0;
      this.rbSaveClipboard.Text = "Save it on the &clipboard.";
      this.rbSaveClipboard.UseVisualStyleBackColor = true;
      this.rbSaveClipboard.CheckedChanged += new System.EventHandler(this.rbSaveClipboard_CheckedChanged);
      // 
      // txtPassword2
      // 
      this.txtPassword2.Enabled = false;
      this.txtPassword2.ImeMode = System.Windows.Forms.ImeMode.Disable;
      this.txtPassword2.Location = new System.Drawing.Point(29, 144);
      this.txtPassword2.Name = "txtPassword2";
      this.txtPassword2.Size = new System.Drawing.Size(198, 21);
      this.txtPassword2.TabIndex = 4;
      this.txtPassword2.UseSystemPasswordChar = true;
      // 
      // lblRepeat
      // 
      lblRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblRepeat.Location = new System.Drawing.Point(234, 144);
      lblRepeat.Name = "lblRepeat";
      lblRepeat.Size = new System.Drawing.Size(265, 21);
      lblRepeat.TabIndex = 5;
      lblRepeat.Text = "(repeat password)";
      lblRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // EncryptSignWizard
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(511, 386);
      this.Controls.Add(this.wizard);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EncryptSignWizard";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Encrypt and Sign";
      this.inputStep.ResumeLayout(false);
      this.inputStep.PerformLayout();
      this.signStep.ResumeLayout(false);
      this.signStep.PerformLayout();
      this.encryptStep.ResumeLayout(false);
      this.encryptStep.PerformLayout();
      this.saveStep.ResumeLayout(false);
      this.saveStep.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private AdamMil.UI.Wizard.Wizard wizard;
    private AdamMil.UI.Wizard.StartStep startStep;
    private AdamMil.UI.Wizard.IntermediateStep inputStep;
    private System.Windows.Forms.Button btnSourceBrowse;
    private System.Windows.Forms.TextBox txtSourceFile;
    private System.Windows.Forms.RadioButton rbSourceFile;
    private System.Windows.Forms.RadioButton rbSourceClipboard;
    private System.Windows.Forms.RadioButton rbManual;
    private System.Windows.Forms.TextBox txtInput;
    private AdamMil.UI.Wizard.IntermediateStep signStep;
    private System.Windows.Forms.ComboBox cmbSigningKey;
    private System.Windows.Forms.Label lblSigningKey;
    private System.Windows.Forms.Button btnSigBrowse;
    private System.Windows.Forms.TextBox txtDetachedSig;
    private System.Windows.Forms.RadioButton rbDetachedSig;
    private System.Windows.Forms.RadioButton rbEmbedSig;
    private System.Windows.Forms.RadioButton rbNoSign;
    private AdamMil.UI.Wizard.IntermediateStep encryptStep;
    private AdamMil.Security.UI.SecureTextBox txtPassword;
    private System.Windows.Forms.Button btnRecipBrowse;
    private System.Windows.Forms.TextBox txtRecipients;
    private System.Windows.Forms.RadioButton rbAsymmetric;
    private System.Windows.Forms.RadioButton rbSymmetric;
    private System.Windows.Forms.RadioButton rbNoEncrypt;
    private System.Windows.Forms.Label lblStrength;
    private AdamMil.UI.Wizard.IntermediateStep saveStep;
    private System.Windows.Forms.RadioButton rbSaveFile;
    private System.Windows.Forms.Button btnSaveFileBrowse;
    private System.Windows.Forms.TextBox txtSaveFile;
    private System.Windows.Forms.RadioButton rbOverwrite;
    private System.Windows.Forms.RadioButton rbSaveClipboard;
    private System.Windows.Forms.Label lblCantSign;
    private System.Windows.Forms.CheckBox chkAscii;
    private System.Windows.Forms.RadioButton rbSaveNear;
    private System.Windows.Forms.CheckBox chkEncryptToSelf;
    private System.Windows.Forms.ComboBox cmbAlsoEncryptTo;
    private AdamMil.Security.UI.SecureTextBox txtPassword2;
  }
}