namespace GPGDesktop
{
  partial class OptionsForm
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
      System.Windows.Forms.Button btnCancel;
      System.Windows.Forms.LinkLabel lblLink;
      this.lblPath = new System.Windows.Forms.Label();
      this.txtGPG = new System.Windows.Forms.TextBox();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      btnCancel = new System.Windows.Forms.Button();
      lblLink = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // lblPath
      // 
      this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPath.Location = new System.Drawing.Point(5, 7);
      this.lblPath.Name = "lblPath";
      this.lblPath.Size = new System.Drawing.Size(452, 44);
      this.lblPath.TabIndex = 0;
      this.lblPath.Text = "GPG Desktop is built upon the GNU Privacy Guard (GPG). Select the path to the GPG" +
    " executable (gpg.exe). GPG2 will also work, but is not recommended. If you do no" +
    "t have GPG, you can install it from:";
      // 
      // txtGPG
      // 
      this.txtGPG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtGPG.Location = new System.Drawing.Point(8, 56);
      this.txtGPG.Name = "txtGPG";
      this.txtGPG.Size = new System.Drawing.Size(368, 21);
      this.txtGPG.TabIndex = 1;
      this.txtGPG.TextChanged += new System.EventHandler(this.txtGPG_TextChanged);
      this.txtGPG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGPG_KeyDown);
      // 
      // btnBrowse
      // 
      this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBrowse.Location = new System.Drawing.Point(382, 56);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(75, 21);
      this.btnBrowse.TabIndex = 2;
      this.btnBrowse.Text = "&Browse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnOK.Location = new System.Drawing.Point(154, 85);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "&OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnCancel.Location = new System.Drawing.Point(235, 85);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 4;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // lblLink
      // 
      lblLink.Location = new System.Drawing.Point(281, 33);
      lblLink.Name = "lblLink";
      lblLink.Size = new System.Drawing.Size(146, 13);
      lblLink.TabIndex = 5;
      lblLink.TabStop = true;
      lblLink.Text = "http://www.gpg4win.org";
      lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
      // 
      // OptionsForm
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnCancel;
      this.ClientSize = new System.Drawing.Size(465, 115);
      this.Controls.Add(lblLink);
      this.Controls.Add(btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnBrowse);
      this.Controls.Add(this.txtGPG);
      this.Controls.Add(this.lblPath);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "OptionsForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "GPG Desktop Configuration";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblPath;
    private System.Windows.Forms.TextBox txtGPG;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.Button btnOK;
  }
}