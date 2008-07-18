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
  partial class MainForm
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label lblSearch;
      System.Windows.Forms.Button btnEncrypt;
      System.Windows.Forms.Button btnSign;
      System.Windows.Forms.Button btnSignEncrypt;
      System.Windows.Forms.Button btnVerify;
      System.Windows.Forms.Button btnDecrypt;
      System.Windows.Forms.Button btnOpen;
      System.Windows.Forms.Button btnSave;
      this.mainMenu = new System.Windows.Forms.MenuStrip();
      this.keysTab = new System.Windows.Forms.TabPage();
      this.btnClearSearch = new System.Windows.Forms.Button();
      this.txtSearch = new System.Windows.Forms.TextBox();
      this.keyList = new AdamMil.Security.UI.KeyManagementList();
      this.tabs = new System.Windows.Forms.TabControl();
      this.decryptTab = new System.Windows.Forms.TabPage();
      this.padTab = new System.Windows.Forms.TabPage();
      this.txtPad = new System.Windows.Forms.TextBox();
      lblSearch = new System.Windows.Forms.Label();
      btnEncrypt = new System.Windows.Forms.Button();
      btnSign = new System.Windows.Forms.Button();
      btnSignEncrypt = new System.Windows.Forms.Button();
      btnVerify = new System.Windows.Forms.Button();
      btnDecrypt = new System.Windows.Forms.Button();
      btnOpen = new System.Windows.Forms.Button();
      btnSave = new System.Windows.Forms.Button();
      this.keysTab.SuspendLayout();
      this.tabs.SuspendLayout();
      this.padTab.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblSearch
      // 
      lblSearch.Location = new System.Drawing.Point(2, 10);
      lblSearch.Name = "lblSearch";
      lblSearch.Size = new System.Drawing.Size(84, 15);
      lblSearch.TabIndex = 1;
      lblSearch.Text = "Search keys:";
      lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnEncrypt
      // 
      btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnEncrypt.Location = new System.Drawing.Point(0, 522);
      btnEncrypt.Name = "btnEncrypt";
      btnEncrypt.Size = new System.Drawing.Size(75, 23);
      btnEncrypt.TabIndex = 1;
      btnEncrypt.Text = "Encrypt";
      btnEncrypt.UseVisualStyleBackColor = true;
      // 
      // btnSign
      // 
      btnSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnSign.Location = new System.Drawing.Point(81, 522);
      btnSign.Name = "btnSign";
      btnSign.Size = new System.Drawing.Size(75, 23);
      btnSign.TabIndex = 2;
      btnSign.Text = "Sign";
      btnSign.UseVisualStyleBackColor = true;
      // 
      // btnSignEncrypt
      // 
      btnSignEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnSignEncrypt.Location = new System.Drawing.Point(162, 522);
      btnSignEncrypt.Name = "btnSignEncrypt";
      btnSignEncrypt.Size = new System.Drawing.Size(132, 23);
      btnSignEncrypt.TabIndex = 3;
      btnSignEncrypt.Text = "Sign and Encrypt";
      btnSignEncrypt.UseVisualStyleBackColor = true;
      // 
      // btnVerify
      // 
      btnVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnVerify.Enabled = false;
      btnVerify.Location = new System.Drawing.Point(381, 522);
      btnVerify.Name = "btnVerify";
      btnVerify.Size = new System.Drawing.Size(132, 23);
      btnVerify.TabIndex = 5;
      btnVerify.Text = "Verify Signature";
      btnVerify.UseVisualStyleBackColor = true;
      // 
      // btnDecrypt
      // 
      btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnDecrypt.Enabled = false;
      btnDecrypt.Location = new System.Drawing.Point(300, 522);
      btnDecrypt.Name = "btnDecrypt";
      btnDecrypt.Size = new System.Drawing.Size(75, 23);
      btnDecrypt.TabIndex = 4;
      btnDecrypt.Text = "Decrypt";
      btnDecrypt.UseVisualStyleBackColor = true;
      // 
      // btnOpen
      // 
      btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnOpen.Location = new System.Drawing.Point(519, 522);
      btnOpen.Name = "btnOpen";
      btnOpen.Size = new System.Drawing.Size(75, 23);
      btnOpen.TabIndex = 6;
      btnOpen.Text = "Open";
      btnOpen.UseVisualStyleBackColor = true;
      // 
      // btnSave
      // 
      btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnSave.Location = new System.Drawing.Point(600, 522);
      btnSave.Name = "btnSave";
      btnSave.Size = new System.Drawing.Size(75, 23);
      btnSave.TabIndex = 7;
      btnSave.Text = "Save";
      btnSave.UseVisualStyleBackColor = true;
      // 
      // mainMenu
      // 
      this.mainMenu.Location = new System.Drawing.Point(0, 0);
      this.mainMenu.Name = "mainMenu";
      this.mainMenu.Size = new System.Drawing.Size(874, 24);
      this.mainMenu.TabIndex = 0;
      // 
      // keysTab
      // 
      this.keysTab.Controls.Add(this.btnClearSearch);
      this.keysTab.Controls.Add(this.txtSearch);
      this.keysTab.Controls.Add(lblSearch);
      this.keysTab.Controls.Add(this.keyList);
      this.keysTab.Location = new System.Drawing.Point(4, 25);
      this.keysTab.Name = "keysTab";
      this.keysTab.Size = new System.Drawing.Size(866, 365);
      this.keysTab.TabIndex = 1;
      this.keysTab.Text = "Manage Keys";
      this.keysTab.UseVisualStyleBackColor = true;
      // 
      // btnClearSearch
      // 
      this.btnClearSearch.Enabled = false;
      this.btnClearSearch.Location = new System.Drawing.Point(328, 7);
      this.btnClearSearch.Name = "btnClearSearch";
      this.btnClearSearch.Size = new System.Drawing.Size(52, 21);
      this.btnClearSearch.TabIndex = 3;
      this.btnClearSearch.Text = "Clear";
      this.btnClearSearch.UseVisualStyleBackColor = true;
      // 
      // txtSearch
      // 
      this.txtSearch.Location = new System.Drawing.Point(87, 7);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(235, 21);
      this.txtSearch.TabIndex = 2;
      // 
      // keyList
      // 
      this.keyList.AllowColumnReorder = true;
      this.keyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.keyList.Font = new System.Drawing.Font("Arial", 8F);
      this.keyList.FullRowSelect = true;
      this.keyList.Location = new System.Drawing.Point(0, 34);
      this.keyList.Name = "keyList";
      this.keyList.PGP = null;
      this.keyList.Size = new System.Drawing.Size(866, 512);
      this.keyList.TabIndex = 0;
      this.keyList.UseCompatibleStateImageBehavior = false;
      this.keyList.View = System.Windows.Forms.View.Details;
      // 
      // tabs
      // 
      this.tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
      this.tabs.Controls.Add(this.decryptTab);
      this.tabs.Controls.Add(this.keysTab);
      this.tabs.Controls.Add(this.padTab);
      this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabs.HotTrack = true;
      this.tabs.Location = new System.Drawing.Point(0, 24);
      this.tabs.Multiline = true;
      this.tabs.Name = "tabs";
      this.tabs.SelectedIndex = 0;
      this.tabs.Size = new System.Drawing.Size(874, 394);
      this.tabs.TabIndex = 1;
      // 
      // decryptTab
      // 
      this.decryptTab.Location = new System.Drawing.Point(4, 25);
      this.decryptTab.Name = "decryptTab";
      this.decryptTab.Size = new System.Drawing.Size(866, 365);
      this.decryptTab.TabIndex = 3;
      this.decryptTab.Text = "Decrypt / Verify";
      this.decryptTab.UseVisualStyleBackColor = true;
      // 
      // padTab
      // 
      this.padTab.Controls.Add(btnSave);
      this.padTab.Controls.Add(btnOpen);
      this.padTab.Controls.Add(btnVerify);
      this.padTab.Controls.Add(btnDecrypt);
      this.padTab.Controls.Add(btnSignEncrypt);
      this.padTab.Controls.Add(btnSign);
      this.padTab.Controls.Add(btnEncrypt);
      this.padTab.Controls.Add(this.txtPad);
      this.padTab.Location = new System.Drawing.Point(4, 25);
      this.padTab.Name = "padTab";
      this.padTab.Size = new System.Drawing.Size(866, 365);
      this.padTab.TabIndex = 4;
      this.padTab.Text = "GPG Pad";
      this.padTab.UseVisualStyleBackColor = true;
      // 
      // txtPad
      // 
      this.txtPad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPad.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPad.Location = new System.Drawing.Point(0, 0);
      this.txtPad.MaxLength = 0;
      this.txtPad.Multiline = true;
      this.txtPad.Name = "txtPad";
      this.txtPad.Size = new System.Drawing.Size(866, 516);
      this.txtPad.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(874, 418);
      this.Controls.Add(this.tabs);
      this.Controls.Add(this.mainMenu);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MainMenuStrip = this.mainMenu;
      this.MinimumSize = new System.Drawing.Size(735, 250);
      this.Name = "MainForm";
      this.Text = "GPG Desktop";
      this.keysTab.ResumeLayout(false);
      this.keysTab.PerformLayout();
      this.tabs.ResumeLayout(false);
      this.padTab.ResumeLayout(false);
      this.padTab.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip mainMenu;
    private System.Windows.Forms.TabPage keysTab;
    private AdamMil.Security.UI.KeyManagementList keyList;
    private System.Windows.Forms.TabControl tabs;
    private System.Windows.Forms.TabPage decryptTab;
    private System.Windows.Forms.TabPage padTab;
    private System.Windows.Forms.Button btnClearSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.TextBox txtPad;
  }
}