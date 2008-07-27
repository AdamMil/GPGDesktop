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
      System.Windows.Forms.Button btnOpen;
      System.Windows.Forms.Button btnSave;
      System.Windows.Forms.ImageList homeIcons;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.ToolStripMenuItem gpgMenu;
      System.Windows.Forms.ToolStripMenuItem encryptMenuItem;
      System.Windows.Forms.ToolStripMenuItem decryptMenuItem;
      System.Windows.Forms.ToolStripMenuItem generateMenuItem;
      System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
      System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
      System.Windows.Forms.ToolStripSeparator menuSep1;
      System.Windows.Forms.ToolStripMenuItem exitMenuItem;
      System.Windows.Forms.Button btnSymmetric;
      System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Encrypt/Sign Data", 0);
      System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Decrypt/Verify Data", 1);
      System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Generate Your Key", 2);
      System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Options", 3);
      System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("About", 4);
      this.btnVerify = new System.Windows.Forms.Button();
      this.btnDecrypt = new System.Windows.Forms.Button();
      this.homeList = new System.Windows.Forms.ListView();
      this.keysTab = new System.Windows.Forms.TabPage();
      this.btnClearSearch = new System.Windows.Forms.Button();
      this.txtSearch = new System.Windows.Forms.TextBox();
      this.keyList = new AdamMil.Security.UI.KeyManagementList();
      this.tabs = new System.Windows.Forms.TabControl();
      this.homeTab = new System.Windows.Forms.TabPage();
      this.padTab = new System.Windows.Forms.TabPage();
      this.txtPad = new System.Windows.Forms.TextBox();
      this.mainMenu = new System.Windows.Forms.MenuStrip();
      lblSearch = new System.Windows.Forms.Label();
      btnEncrypt = new System.Windows.Forms.Button();
      btnSign = new System.Windows.Forms.Button();
      btnSignEncrypt = new System.Windows.Forms.Button();
      btnOpen = new System.Windows.Forms.Button();
      btnSave = new System.Windows.Forms.Button();
      homeIcons = new System.Windows.Forms.ImageList(this.components);
      gpgMenu = new System.Windows.Forms.ToolStripMenuItem();
      encryptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      decryptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      generateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      menuSep1 = new System.Windows.Forms.ToolStripSeparator();
      exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      btnSymmetric = new System.Windows.Forms.Button();
      this.keysTab.SuspendLayout();
      this.tabs.SuspendLayout();
      this.homeTab.SuspendLayout();
      this.padTab.SuspendLayout();
      this.mainMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblSearch
      // 
      lblSearch.Location = new System.Drawing.Point(2, 8);
      lblSearch.Name = "lblSearch";
      lblSearch.Size = new System.Drawing.Size(84, 15);
      lblSearch.TabIndex = 1;
      lblSearch.Text = "Search keys:";
      lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnEncrypt
      // 
      btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnEncrypt.Location = new System.Drawing.Point(0, 342);
      btnEncrypt.Name = "btnEncrypt";
      btnEncrypt.Size = new System.Drawing.Size(75, 23);
      btnEncrypt.TabIndex = 1;
      btnEncrypt.Text = "&Encrypt";
      btnEncrypt.UseVisualStyleBackColor = true;
      btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
      // 
      // btnSign
      // 
      btnSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnSign.Location = new System.Drawing.Point(237, 342);
      btnSign.Name = "btnSign";
      btnSign.Size = new System.Drawing.Size(75, 23);
      btnSign.TabIndex = 2;
      btnSign.Text = "&Sign";
      btnSign.UseVisualStyleBackColor = true;
      btnSign.Click += new System.EventHandler(this.btnSign_Click);
      // 
      // btnSignEncrypt
      // 
      btnSignEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnSignEncrypt.Location = new System.Drawing.Point(318, 342);
      btnSignEncrypt.Name = "btnSignEncrypt";
      btnSignEncrypt.Size = new System.Drawing.Size(132, 23);
      btnSignEncrypt.TabIndex = 3;
      btnSignEncrypt.Text = "Sign &and Encrypt";
      btnSignEncrypt.UseVisualStyleBackColor = true;
      btnSignEncrypt.Click += new System.EventHandler(this.btnSignEncrypt_Click);
      // 
      // btnOpen
      // 
      btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnOpen.Location = new System.Drawing.Point(675, 342);
      btnOpen.Name = "btnOpen";
      btnOpen.Size = new System.Drawing.Size(75, 23);
      btnOpen.TabIndex = 6;
      btnOpen.Text = "&Open";
      btnOpen.UseVisualStyleBackColor = true;
      btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // btnSave
      // 
      btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnSave.Location = new System.Drawing.Point(756, 342);
      btnSave.Name = "btnSave";
      btnSave.Size = new System.Drawing.Size(75, 23);
      btnSave.TabIndex = 7;
      btnSave.Text = "&Save";
      btnSave.UseVisualStyleBackColor = true;
      btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // homeIcons
      // 
      homeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("homeIcons.ImageStream")));
      homeIcons.TransparentColor = System.Drawing.Color.Transparent;
      homeIcons.Images.SetKeyName(0, "lock.png");
      homeIcons.Images.SetKeyName(1, "unlock.png");
      homeIcons.Images.SetKeyName(2, "key.png");
      homeIcons.Images.SetKeyName(3, "wrench.png");
      homeIcons.Images.SetKeyName(4, "info.png");
      // 
      // gpgMenu
      // 
      gpgMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            encryptMenuItem,
            decryptMenuItem,
            generateMenuItem,
            optionsMenuItem,
            aboutMenuItem,
            menuSep1,
            exitMenuItem});
      gpgMenu.Name = "gpgMenu";
      gpgMenu.Size = new System.Drawing.Size(39, 20);
      gpgMenu.Text = "&GPG";
      // 
      // encryptMenuItem
      // 
      encryptMenuItem.Name = "encryptMenuItem";
      encryptMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
      encryptMenuItem.Size = new System.Drawing.Size(221, 22);
      encryptMenuItem.Text = "&Encrypt/Sign Data...";
      encryptMenuItem.Click += new System.EventHandler(this.encryptMenuItem_Click);
      // 
      // decryptMenuItem
      // 
      decryptMenuItem.Name = "decryptMenuItem";
      decryptMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
      decryptMenuItem.Size = new System.Drawing.Size(221, 22);
      decryptMenuItem.Text = "&Decrypt/Verify Data...";
      decryptMenuItem.Click += new System.EventHandler(this.decryptMenuItem_Click);
      // 
      // generateMenuItem
      // 
      generateMenuItem.Name = "generateMenuItem";
      generateMenuItem.Size = new System.Drawing.Size(221, 22);
      generateMenuItem.Text = "&Generate Your Key...";
      generateMenuItem.Click += new System.EventHandler(this.generateMenuItem_Click);
      // 
      // optionsMenuItem
      // 
      optionsMenuItem.Name = "optionsMenuItem";
      optionsMenuItem.Size = new System.Drawing.Size(221, 22);
      optionsMenuItem.Text = "&Options...";
      optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
      // 
      // aboutMenuItem
      // 
      aboutMenuItem.Name = "aboutMenuItem";
      aboutMenuItem.Size = new System.Drawing.Size(221, 22);
      aboutMenuItem.Text = "&About...";
      aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
      // 
      // menuSep1
      // 
      menuSep1.Name = "menuSep1";
      menuSep1.Size = new System.Drawing.Size(218, 6);
      // 
      // exitMenuItem
      // 
      exitMenuItem.Name = "exitMenuItem";
      exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      exitMenuItem.Size = new System.Drawing.Size(221, 22);
      exitMenuItem.Text = "E&xit";
      exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
      // 
      // btnSymmetric
      // 
      btnSymmetric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnSymmetric.Location = new System.Drawing.Point(81, 342);
      btnSymmetric.Name = "btnSymmetric";
      btnSymmetric.Size = new System.Drawing.Size(150, 23);
      btnSymmetric.TabIndex = 8;
      btnSymmetric.Text = "Encrypt w/ &Password";
      btnSymmetric.UseVisualStyleBackColor = true;
      btnSymmetric.Click += new System.EventHandler(this.btnSymmetric_Click);
      // 
      // btnVerify
      // 
      this.btnVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnVerify.Enabled = false;
      this.btnVerify.Location = new System.Drawing.Point(537, 342);
      this.btnVerify.Name = "btnVerify";
      this.btnVerify.Size = new System.Drawing.Size(132, 23);
      this.btnVerify.TabIndex = 5;
      this.btnVerify.Text = "&Verify Signatures";
      this.btnVerify.UseVisualStyleBackColor = true;
      this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
      // 
      // btnDecrypt
      // 
      this.btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDecrypt.Enabled = false;
      this.btnDecrypt.Location = new System.Drawing.Point(456, 342);
      this.btnDecrypt.Name = "btnDecrypt";
      this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
      this.btnDecrypt.TabIndex = 4;
      this.btnDecrypt.Text = "&Decrypt";
      this.btnDecrypt.UseVisualStyleBackColor = true;
      this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
      // 
      // homeList
      // 
      this.homeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      listViewItem6.ToolTipText = "Encrypt data to protect its confidentiality, and/or sign it to protect its authen" +
    "ticity.";
      listViewItem7.ToolTipText = "Decrypt data and/or verify the signatures in a signed document.";
      listViewItem8.ToolTipText = "Generate a new key pair for yourself, so that you can sign documents and receive " +
    "encrypted data.";
      listViewItem9.ToolTipText = "Change GPG Desktop configuration options.";
      listViewItem10.ToolTipText = "About this program.";
      this.homeList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
      this.homeList.LargeImageList = homeIcons;
      this.homeList.Location = new System.Drawing.Point(0, 0);
      this.homeList.MultiSelect = false;
      this.homeList.Name = "homeList";
      this.homeList.Size = new System.Drawing.Size(831, 365);
      this.homeList.TabIndex = 0;
      this.homeList.UseCompatibleStateImageBehavior = false;
      this.homeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.homeList_MouseDoubleClick);
      this.homeList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.homeList_KeyDown);
      // 
      // keysTab
      // 
      this.keysTab.Controls.Add(this.btnClearSearch);
      this.keysTab.Controls.Add(this.txtSearch);
      this.keysTab.Controls.Add(lblSearch);
      this.keysTab.Controls.Add(this.keyList);
      this.keysTab.Location = new System.Drawing.Point(4, 25);
      this.keysTab.Name = "keysTab";
      this.keysTab.Size = new System.Drawing.Size(831, 365);
      this.keysTab.TabIndex = 1;
      this.keysTab.Text = "Manage Keys";
      this.keysTab.UseVisualStyleBackColor = true;
      // 
      // btnClearSearch
      // 
      this.btnClearSearch.Enabled = false;
      this.btnClearSearch.Location = new System.Drawing.Point(328, 5);
      this.btnClearSearch.Name = "btnClearSearch";
      this.btnClearSearch.Size = new System.Drawing.Size(52, 21);
      this.btnClearSearch.TabIndex = 3;
      this.btnClearSearch.Text = "Clear";
      this.btnClearSearch.UseVisualStyleBackColor = true;
      // 
      // txtSearch
      // 
      this.txtSearch.Location = new System.Drawing.Point(87, 5);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(235, 21);
      this.txtSearch.TabIndex = 2;
      this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
      this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
      // 
      // keyList
      // 
      this.keyList.AllowColumnReorder = true;
      this.keyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.keyList.DisplayRevokers = true;
      this.keyList.DisplaySubkeys = true;
      this.keyList.Font = new System.Drawing.Font("Arial", 8F);
      this.keyList.FullRowSelect = true;
      this.keyList.HideSelection = false;
      this.keyList.Location = new System.Drawing.Point(0, 34);
      this.keyList.Name = "keyList";
      this.keyList.PGP = null;
      this.keyList.Size = new System.Drawing.Size(831, 331);
      this.keyList.TabIndex = 0;
      this.keyList.UseCompatibleStateImageBehavior = false;
      this.keyList.View = System.Windows.Forms.View.Details;
      // 
      // tabs
      // 
      this.tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
      this.tabs.Controls.Add(this.homeTab);
      this.tabs.Controls.Add(this.keysTab);
      this.tabs.Controls.Add(this.padTab);
      this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabs.HotTrack = true;
      this.tabs.Location = new System.Drawing.Point(0, 24);
      this.tabs.Multiline = true;
      this.tabs.Name = "tabs";
      this.tabs.SelectedIndex = 0;
      this.tabs.Size = new System.Drawing.Size(839, 394);
      this.tabs.TabIndex = 1;
      this.tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabs_Selected);
      // 
      // homeTab
      // 
      this.homeTab.Controls.Add(this.homeList);
      this.homeTab.Location = new System.Drawing.Point(4, 25);
      this.homeTab.Name = "homeTab";
      this.homeTab.Size = new System.Drawing.Size(831, 365);
      this.homeTab.TabIndex = 3;
      this.homeTab.Text = "Home";
      this.homeTab.UseVisualStyleBackColor = true;
      // 
      // padTab
      // 
      this.padTab.Controls.Add(btnSymmetric);
      this.padTab.Controls.Add(btnSave);
      this.padTab.Controls.Add(btnOpen);
      this.padTab.Controls.Add(this.btnVerify);
      this.padTab.Controls.Add(this.btnDecrypt);
      this.padTab.Controls.Add(btnSignEncrypt);
      this.padTab.Controls.Add(btnSign);
      this.padTab.Controls.Add(btnEncrypt);
      this.padTab.Controls.Add(this.txtPad);
      this.padTab.Location = new System.Drawing.Point(4, 25);
      this.padTab.Name = "padTab";
      this.padTab.Size = new System.Drawing.Size(831, 365);
      this.padTab.TabIndex = 4;
      this.padTab.Text = "Scratch Pad";
      this.padTab.UseVisualStyleBackColor = true;
      // 
      // txtPad
      // 
      this.txtPad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPad.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPad.Location = new System.Drawing.Point(0, 0);
      this.txtPad.MaxLength = 0;
      this.txtPad.Multiline = true;
      this.txtPad.Name = "txtPad";
      this.txtPad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtPad.Size = new System.Drawing.Size(831, 336);
      this.txtPad.TabIndex = 0;
      this.txtPad.TextChanged += new System.EventHandler(this.txtPad_TextChanged);
      this.txtPad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
      // 
      // mainMenu
      // 
      this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            gpgMenu});
      this.mainMenu.Location = new System.Drawing.Point(0, 0);
      this.mainMenu.Name = "mainMenu";
      this.mainMenu.Size = new System.Drawing.Size(839, 24);
      this.mainMenu.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(839, 418);
      this.Controls.Add(this.tabs);
      this.Controls.Add(this.mainMenu);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.mainMenu;
      this.MinimumSize = new System.Drawing.Size(847, 250);
      this.Name = "MainForm";
      this.Text = "GPG Desktop";
      this.keysTab.ResumeLayout(false);
      this.keysTab.PerformLayout();
      this.tabs.ResumeLayout(false);
      this.homeTab.ResumeLayout(false);
      this.padTab.ResumeLayout(false);
      this.padTab.PerformLayout();
      this.mainMenu.ResumeLayout(false);
      this.mainMenu.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabPage keysTab;
    private AdamMil.Security.UI.KeyManagementList keyList;
    private System.Windows.Forms.TabControl tabs;
    private System.Windows.Forms.TabPage homeTab;
    private System.Windows.Forms.TabPage padTab;
    private System.Windows.Forms.Button btnClearSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.TextBox txtPad;
    private System.Windows.Forms.ListView homeList;
    private System.Windows.Forms.MenuStrip mainMenu;
    private System.Windows.Forms.Button btnVerify;
    private System.Windows.Forms.Button btnDecrypt;
  }
}