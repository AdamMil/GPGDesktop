using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using AdamMil.Security.PGP.GPG;
using GPGDesktop.Properties;

namespace GPGDesktop
{

public partial class OptionsForm : Form
{
  public OptionsForm()
  {
    InitializeComponent();

    Settings.Default.Reload();
    txtGPG.Text = Settings.Default.GPGPath;

    if(string.IsNullOrEmpty(txtGPG.Text))
    {
      // the GPG installation path may be stored in the registry
      string path = GetInstallationPath("HKEY_CURRENT_USER");
      if(path == null)
      {
        path = GetInstallationPath("HKEY_LOCAL_MACHINE");
        if(path == null)
        {
          path = LookForExecutableInDirectory(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"GNU\GnuPG"));
        }
      }

      if(path != null) txtGPG.Text = path;
    }
  }

  void btnBrowse_Click(object sender, EventArgs e)
  {
    OpenFileDialog ofd = new OpenFileDialog();

    if(!string.IsNullOrEmpty(txtGPG.Text))
    {
      try { ofd.InitialDirectory = Path.GetDirectoryName(txtGPG.Text); }
      catch { }
    }

    ofd.FileName = "gpg.exe";
    ofd.Filter   = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
    ofd.SupportMultiDottedExtensions = true;
    
    if(ofd.ShowDialog() == DialogResult.OK) txtGPG.Text = ofd.FileName;
  }

  void btnOK_Click(object sender, EventArgs e)
  {
    string path = txtGPG.Text.Trim();
    
    try { new ExeGPG(path); }
    catch
    {
      MessageBox.Show("'" + path + "' doesn't seem to be a valid GPG executable.", "Invalid path",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    Settings.Default.GPGPath = path;
    Settings.Default.Save();

    DialogResult = DialogResult.OK;
  }

  void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    ProcessStartInfo psi = new ProcessStartInfo();
    psi.FileName = ((LinkLabel)sender).Text;
    psi.UseShellExecute = true;
    Process.Start(psi);
  }

  void txtGPG_KeyDown(object sender, KeyEventArgs e)
  {
    if(!e.Handled && e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
    {
      txtGPG.SelectAll();
      e.Handled = true;
    }
  }

  void txtGPG_TextChanged(object sender, EventArgs e)
  {
    btnOK.Enabled = txtGPG.Text.Trim().Length != 0;
  }

  static string GetInstallationPath(string root)
  {
    string path = Registry.GetValue(root + @"\Software\GNU\GnuPG", "gpgProgram", null) as string;
    if(!string.IsNullOrEmpty(path) && File.Exists(path)) return path;

    string dir = Registry.GetValue(root + @"\Software\GNU\GnuPG", "Install Directory", null) as string;
    return string.IsNullOrEmpty(dir) ? null : LookForExecutableInDirectory(dir);
  }

  static string LookForExecutableInDirectory(string dir)
  {
    string path = Path.Combine(dir, "gpg.exe");
    if(File.Exists(path)) return path;

    path = Path.Combine(dir, "gpg2.exe");
    if(File.Exists(path)) return path;

    return null;
  }
}

} // namespace GPGDesktop