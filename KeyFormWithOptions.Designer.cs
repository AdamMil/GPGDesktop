namespace GPGDesktop
{
  partial class KeyFormWithOptions
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
      this.chkEncryptToSelf = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // chkEncryptToSelf
      // 
      this.chkEncryptToSelf.AutoSize = true;
      this.chkEncryptToSelf.Checked = true;
      this.chkEncryptToSelf.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkEncryptToSelf.Location = new System.Drawing.Point(11, 63);
      this.chkEncryptToSelf.Name = "chkEncryptToSelf";
      this.chkEncryptToSelf.Size = new System.Drawing.Size(312, 17);
      this.chkEncryptToSelf.TabIndex = 5;
      this.chkEncryptToSelf.Text = "Encrypt to &myself (i.e. use this key as a recipient)";
      this.chkEncryptToSelf.UseVisualStyleBackColor = true;
      // 
      // KeyFormWithOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.ClientSize = new System.Drawing.Size(519, 92);
      this.Controls.Add(this.chkEncryptToSelf);
      this.Name = "KeyFormWithOptions";
      this.Controls.SetChildIndex(this.chkEncryptToSelf, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox chkEncryptToSelf;
  }
}
