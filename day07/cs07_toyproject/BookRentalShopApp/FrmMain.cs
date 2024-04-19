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
            // 값형식 변수에 null 값을 넣을 수 있도록 만들어준 기능 : Nullable

            int? a = null;
            MessageBox.Show(a.ToString());
        }
    }
}
