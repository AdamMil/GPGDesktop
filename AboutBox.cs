using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GPGDesktop
{

public partial class AboutBox : Form
{
  public AboutBox()
  {
    InitializeComponent();
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