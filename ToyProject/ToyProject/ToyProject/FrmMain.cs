using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ToyProject
{
    public partial class FrmMain : Form
    {
        bool blnBtnClosing = false;

        public static string ConnSting = "Data Source = localhost;" +
                            "Initial Catalog = Counter;" +
                            "Persist Security Info = True;" +
                            "User ID = sa; Encrypt = False;Password=mssql_p@ss";
        public FrmMain()
        {
            InitializeComponent();

        }
        //private void RefreshData()
        //{
        //    using (SqlConnection conn = new SqlConnection(ConnSting))
        //    {
        //        conn.Open();

        //        var query = @"SELECT userId,
        //                             userPw
        //                        FROM usertbl"; // 화면에 필요한 테이블 쿼리 변경

        //        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
        //        DataSet ds = new DataSet();
        //        adapter.Fill(ds, "usertbl");  // 대표 테이블이름 사용하면 됨

        //        DgvMain.DataSource = ds.Tables[0];
        //        DgvMain.ReadOnly = true; // 수정불가
        //        DgvMain.Columns[0].HeaderText = "아이디";
        //        DgvMain.Columns[1].HeaderText = "비밀번호";
        //        // 각 컬럼 넓이 지정, 컬럼 숨김 지정

        //    }
        //}

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.TopMost = true; // 실행 창 상단에 가도록 해준다
            frm.ShowDialog();

            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblTimer.Text = DateTime.Now.ToString("F");

        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까 ?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                blnBtnClosing = true; // 버튼으로 종료 시킨 경우
                this.DialogResult = DialogResult.Abort;
                Application.Exit();
            }
        }

        private void FrmMain_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show(this, "종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true; // 종료 안되는 부분
            }
            else
            {
                Environment.Exit(0);
            }
        }
        Form ShowActiveForm(Form form, Type type)
        {
            if (form == null) // 화면이 한번도 안열었으면
            {
                form = Activator.CreateInstance(type) as Form; // 타입은 클래스 타입
                form.MdiParent = this; // 자식창의 부모는 FrmMain
                form.WindowState = FormWindowState.Normal;
                form.Show();
            }
            else
            {
                if (form.IsDisposed)  // 창이 한번 닫혔으면 쭉 진행
                {
                    form = Activator.CreateInstance(type) as Form;
                    form.MdiParent = this;
                    form.WindowState = FormWindowState.Normal;
                    form.Show();
                }
                else // 창을 그냥 최소화, 열려있으면
                {
                    form.Activate(); // 화면에 열려있는 창을 활성화
                }
            }

            return form;

        }
        public void AddToListbox(string value)
        {
            ListBox1.Items.Add(value);
        }

        public ListBox Listbox1
        {
            get { return ListBox1; }
            set { ListBox1 = value; }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            FrmOrder frmOrder = new FrmOrder(); // 새로운 FrmOrder 인스턴스 생성
            frmOrder.Show();
            frmOrder = ShowActiveForm(frmOrder, typeof(FrmOrder)) as FrmOrder;

        }
    }
}
