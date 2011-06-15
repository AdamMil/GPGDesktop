namespace GPGDesktop
{
  partial class AboutBox
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
      System.Windows.Forms.PictureBox picture;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
      System.Windows.Forms.Label lblText;
      System.Windows.Forms.LinkLabel myLink;
      System.Windows.Forms.Label lblText2;
      System.Windows.Forms.LinkLabel iconLink;
      this.btnOK = new System.Windows.Forms.Button();
      picture = new System.Windows.Forms.PictureBox();
      lblText = new System.Windows.Forms.Label();
      myLink = new System.Windows.Forms.LinkLabel();
      lblText2 = new System.Windows.Forms.Label();
      iconLink = new System.Windows.Forms.LinkLabel();
      ((System.ComponentModel.ISupportInitialize)(picture)).BeginInit();
      this.SuspendLayout();
      // 
      // picture
      // 
      picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
      picture.Location = new System.Drawing.Point(0, 6);
      picture.Name = "picture";
      picture.Size = new System.Drawing.Size(128, 128);
      picture.TabIndex = 0;
      picture.TabStop = false;
      // 
      // lblText
      // 
      lblText.Location = new System.Drawing.Point(130, 9);
      lblText.Name = "lblText";
      lblText.Size = new System.Drawing.Size(190, 28);
      lblText.TabIndex = 1;
      lblText.Text = "GPG Desktop v. 1.07\r\nDeveloped by Adam Milazzo\r\n";
      // 
      // myLink
      // 
      myLink.Location = new System.Drawing.Point(130, 37);
      myLink.Name = "myLink";
      myLink.Size = new System.Drawing.Size(190, 13);
      myLink.TabIndex = 2;
      myLink.TabStop = true;
      myLink.Text = "http://www.adammil.net/";
      myLink.Click += new System.EventHandler(this.link_Click);
      // 
      // lblText2
      // 
      lblText2.Location = new System.Drawing.Point(130, 62);
      lblText2.Name = "lblText2";
      lblText2.Size = new System.Drawing.Size(190, 16);
      lblText2.TabIndex = 3;
      lblText2.Text = "Using free icons from DryIcons";
      // 
      // iconLink
      // 
      iconLink.Location = new System.Drawing.Point(130, 78);
      iconLink.Name = "iconLink";
      iconLink.Size = new System.Drawing.Size(190, 13);
      iconLink.TabIndex = 4;
      iconLink.TabStop = true;
      iconLink.Text = "http://www.dryicons.com/";
      iconLink.Click += new System.EventHandler(this.link_Click);
      // 
      // btnOK
      // 
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(184, 106);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "&OK";
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // AboutBox
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(322, 141);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(iconLink);
      this.Controls.Add(lblText2);
      this.Controls.Add(myLink);
      this.Controls.Add(lblText);
      this.Controls.Add(picture);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutBox";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About GPG Desktop";
      ((System.ComponentModel.ISupportInitialize)(picture)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnOK;


  }
}