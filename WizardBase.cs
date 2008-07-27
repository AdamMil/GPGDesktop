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
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GPGDesktop
{

public class WizardBase : Form
{
  protected static void BrowseInputFiles(TextBoxBase txtFiles, string filter, string title, bool allowMultiple)
  {
    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter      = filter;
    ofd.Multiselect = allowMultiple;
    ofd.Title       = title;
    ofd.SupportMultiDottedExtensions = true;

    if(ofd.ShowDialog() == DialogResult.OK)
    {
      txtFiles.Tag  = ofd.FileNames;
      txtFiles.Text = string.Join("; ", ofd.FileNames);
    }
  }

  protected static void BrowseOutputFile(TextBoxBase txtFile, string defaultExt, string filter, string title,
                                         string defaultFileName)
  {
    SaveFileDialog sfd = new SaveFileDialog();
    sfd.DefaultExt = defaultExt;
    sfd.Filter     = filter;
    sfd.Title      = title;
    sfd.SupportMultiDottedExtensions = true;

    if(!string.IsNullOrEmpty(defaultFileName)) sfd.FileName = defaultFileName;

    if(sfd.ShowDialog() == DialogResult.OK) txtFile.Text = sfd.FileName;
  }

  protected static FileStream GetNearFile(string filename, string extension, string fileType)
  {
    string testName = filename + extension;
    int suffix = 2;

    while(File.Exists(testName))
    {
      testName = filename + (suffix++).ToString(System.Globalization.CultureInfo.InvariantCulture) + extension;
    }

    try { return new FileStream(testName, FileMode.CreateNew, FileAccess.ReadWrite); }
    catch(Exception ex)
    {
      ShowCantOpenFileMessage(fileType, testName, ex);
      return null;
    }
  }

  protected static void ShowCantOpenFileMessage(string fileType, string fileName, Exception ex)
  {
    MessageBox.Show("Unable to open " + fileType + " file '" + fileName + "'. The error was: " + ex.Message,
                    "Unable to open file", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }

  protected static string[] ValidateInputFiles(TextBoxBase txtFiles, string fileType, bool allowMultiple)
  {
    List<string> files = new List<string>();

    foreach(string file in allowMultiple ? txtFiles.Text.Split(';') : new string[] { txtFiles.Text })
    {
      string trimmed = file.Trim();
      if(!string.IsNullOrEmpty(trimmed))
      {
        if(!File.Exists(trimmed))
        {
          MessageBox.Show("The " + fileType + " file '" + trimmed + "' does not exist or cannot be opened.",
                          "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
          txtFiles.Focus();
          return null;
        }

        files.Add(trimmed);
      }
    }

    if(files.Count == 0)
    {
      MessageBox.Show("No " + fileType + " files were selected.", "No " + fileType + " files",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
      txtFiles.Focus();
      return null;
    }

    return files.ToArray();
  }

  protected static void text_KeyDown(object sender, KeyEventArgs e)
  {
    if(!e.Handled && e.KeyCode == Keys.A && e.Modifiers == Keys.Control) // ctrl-a selects all text
    {
      ((TextBoxBase)sender).SelectAll();
    }
  }
}

} // namespace GPGDesktop