using AdamMil.Security.UI;
using AdamMil.Security.PGP;

namespace GPGDesktop
{
  public partial class KeyFormWithOptions : KeyForm
  {
    public KeyFormWithOptions()
    {
      InitializeComponent();
    }

    public KeyFormWithOptions(string description, params PrimaryKey[] keys) : base(description, keys)
    {
      InitializeComponent();
    }

    public bool EncryptToSelf
    {
      get { return chkEncryptToSelf.Checked; }
      set { chkEncryptToSelf.Checked = value; }
    }
  }
}
