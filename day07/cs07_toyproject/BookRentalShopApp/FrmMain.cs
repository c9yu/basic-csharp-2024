using Ax.Fw.MetroFramework.Forms;

namespace BookRentalShopApp
{
    public partial class FrmMain : BorderlessForm // Metro
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // ������ ������ null ���� ���� �� �ֵ��� ������� ��� : Nullable

            int? a = null;
            MessageBox.Show(a.ToString());
        }
    }
}
