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
using System.Windows.Forms;
using AdamMil.Security.PGP;
using AdamMil.Security.PGP.GPG;

namespace GPGDesktop
{

static class Program
{
  [STAThread]
  static void Main()
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);

    ExeGPG gpg = new ExeGPG("d:/adammil/programs/gnupg/gpg.exe");
    #if DEBUG
    gpg.LineLogged += delegate(string line) { System.Diagnostics.Debugger.Log(0, "GPG", line+"\n"); };
    #endif

    Application.Run(new EncryptSignWizard(gpg, gpg.GetKeys(ListOptions.RetrieveOnlySecretKeys | ListOptions.IgnoreUnusableKeys)));
  }
}

} // namespace GPGDesktop