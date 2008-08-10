using System;
using System.Diagnostics;
using System.Windows.Forms;
using AdamMil.Security.UI;

namespace GPGDesktop
{

public partial class AboutBox : Form
{
  public AboutBox()
  {
    InitializeComponent();
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    base.OnKeyDown(e);

    if(!e.Handled && PGPUI.IsCloseKey(e))
    {
      Close();
      e.Handled = true;
    }
  }

  protected override void OnShown(EventArgs e)
  {
    base.OnShown(e);
    btnOK.Focus();
  }

  void link_Click(object sender, EventArgs e)
  {
    LinkLabel link = (LinkLabel)sender;

    ProcessStartInfo psi = new ProcessStartInfo();
    psi.FileName        = link.Text;
    psi.UseShellExecute = true;
    Process.Start(psi);
  }
}

} // namespace GPGDesktop