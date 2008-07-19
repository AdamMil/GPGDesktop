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
using System.Security;
using System.Windows.Forms;
using AdamMil.Security.PGP;
using AdamMil.Security.PGP.GPG;
using AdamMil.Security.UI;

namespace GPGDesktop
{

static class Program
{
  public static readonly PasswordCache PasswordCache = new PasswordCache();

  [STAThread]
  static void Main()
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);

    ExeGPG gpg = new ExeGPG("d:/adammil/programs/gnupg/gpg.exe");
    gpg.DecryptionPasswordNeeded += GetDecryptionPassword;
    gpg.KeyPasswordNeeded        += GetKeyPassword;
    gpg.KeyPasswordInvalid       += OnPasswordInvalid;
    #if DEBUG
    gpg.LineLogged += delegate(string line) { System.Diagnostics.Debugger.Log(0, "GPG", line+"\n"); };
    #endif

    try { Application.Run(new MainForm(gpg)); }
    finally { PasswordCache.Dispose(); }
  }

  static SecureString GetDecryptionPassword()
  {
    PasswordForm form = new PasswordForm();
    form.DescriptionText        = "This data is encrypted with a password. Enter the password to decrypt the data.";
    form.EnableRememberPassword = false;
    return form.ShowDialog() == DialogResult.OK ? form.GetPassword() : null;
  }

  static SecureString GetKeyPassword(string keyId, string userId)
  {
    SecureString password = PasswordCache.Get(keyId, false);
    if(password == null)
    {
      PasswordForm form = new PasswordForm();
      form.DescriptionText  = "A password is needed to unlock the secret key for " + userId;
      form.RememberPassword = rememberPassword;
      form.RememberText     = "Remember my password for 5 minutes";
      if(form.ShowDialog() == DialogResult.OK)
      {
        password = form.GetPassword();
        rememberPassword = form.RememberPassword;
        if(password != null) PasswordCache.Add(keyId, password.Copy(), !rememberPassword);
      }
    }
    return password;
  }

  static void OnPasswordInvalid(string keyId)
  {
    PasswordCache.Remove(keyId);
    MessageBox.Show("Incorrect password.", "Incorrect password", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }

  static bool rememberPassword = true;
}

} // namespace GPGDesktop