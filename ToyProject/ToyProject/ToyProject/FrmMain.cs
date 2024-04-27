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
        //                        FROM usertbl"; // ȭ�鿡 �ʿ��� ���̺� ���� ����

        //        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
        //        DataSet ds = new DataSet();
        //        adapter.Fill(ds, "usertbl");  // ��ǥ ���̺��̸� ����ϸ� ��

        //        DgvMain.DataSource = ds.Tables[0];
        //        DgvMain.ReadOnly = true; // �����Ұ�
        //        DgvMain.Columns[0].HeaderText = "���̵�";
        //        DgvMain.Columns[1].HeaderText = "��й�ȣ";
        //        // �� �÷� ���� ����, �÷� ���� ����

        //    }
        //}

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.TopMost = true; // ���� â ��ܿ� ������ ���ش�
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
            if (MessageBox.Show("�����Ͻðڽ��ϱ� ?", "���� Ȯ��", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                blnBtnClosing = true; // ��ư���� ���� ��Ų ���
                this.DialogResult = DialogResult.Abort;
                Application.Exit();
            }
        }

        private void FrmMain_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show(this, "�����Ͻðڽ��ϱ�?", "���� Ȯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true; // ���� �ȵǴ� �κ�
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
