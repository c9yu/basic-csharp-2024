using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToyProject
{
    public partial class FrmOrder : Form
    {
        public static string ConnSting = "Data Source = localhost;" +
                    "Initial Catalog = Counter;" +
                    "Persist Security Info = True;" +
                    "User ID = sa; Encrypt = False;Password=mssql_p@ss";

        public FrmOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnSting))
            {
                conn.Open();

                var query = @"SELECT 종류
                            , 이름
                            , 가격
                        FROM foodtbl AS r
                        WHERE r.종류 = '국밥'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "foodtbl");

                Dgv1.DataSource = ds.Tables[0];
                Dgv1.ReadOnly = true;
                Dgv1.Columns[0].HeaderText = "종류";
                Dgv1.Columns[1].HeaderText = "이름";
                Dgv1.Columns[2].HeaderText = "가격";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnSting))
            {
                conn.Open();

                var query = @"SELECT 종류
                            , 이름
                            , 가격
                        FROM foodtbl AS r
                        WHERE r.종류 = '음식'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "foodtbl");

                Dgv1.DataSource = ds.Tables[0];
                Dgv1.ReadOnly = true;
                Dgv1.Columns[0].HeaderText = "종류";
                Dgv1.Columns[1].HeaderText = "이름";
                Dgv1.Columns[2].HeaderText = "가격";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnSting))
            {
                conn.Open();

                var query = @"SELECT 종류
                            , 이름
                            , 가격
                        FROM foodtbl AS r
                        WHERE r.종류 = '주류'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "foodtbl");

                Dgv1.DataSource = ds.Tables[0];
                Dgv1.ReadOnly = true;
                Dgv1.Columns[0].HeaderText = "종류";
                Dgv1.Columns[1].HeaderText = "이름";
                Dgv1.Columns[2].HeaderText = "가격";
            }
        }



        private void BtnPay_Click(object sender, EventArgs e)
        {
            // 총 금액 초기화
            int totalAmount = 0;

            // 각 제품의 가격을 총 금액에 더해줌
            foreach (DataGridViewRow row in Dgv2.Rows)
            {
                // 모든 셀 값에 대한 null 체크
                if (row.Cells["가격"].Value != null && row.Cells["수량"].Value != null)
                {
                    int price = Convert.ToInt32(row.Cells["가격"].Value);
                    int quantity = Convert.ToInt32(row.Cells["수량"].Value);
                    totalAmount += price * quantity;
                }
            }

            // 사용자에게 결제를 진행할 것인지 물어보기
            DialogResult result = MessageBox.Show($"총 금액은 {totalAmount}원 입니다.\n결제를 진행하시겠습니까?", "결제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 판매시간 설정
                string sellTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // 판매 데이터를 saletbl에 저장
                using (SqlConnection conn = new SqlConnection(ConnSting))
                {
                    conn.Open();

                    // saletbl 테이블에 데이터 삽입
                    string query = @"INSERT INTO saletbl (총금액, 판매시간) 
                             VALUES (@총금액, @판매시간)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@총금액", totalAmount);
                    command.Parameters.AddWithValue("@판매시간", sellTime);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("결제가 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 판매 완료 후 Dgv2 초기화
                Dgv2.Rows.Clear();
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // 선택된 행이 있는지 확인
            if (Dgv1.SelectedRows.Count > 0 && Dgv2.Columns.Contains("종류") && Dgv2.Columns.Contains("이름") && Dgv2.Columns.Contains("가격") && Dgv2.Columns.Contains("수량"))
            {
                // 선택된 행에서 종류, 이름, 가격 가져오기
                string kind = Dgv1.SelectedRows[0].Cells["종류"].Value?.ToString();
                string name = Dgv1.SelectedRows[0].Cells["이름"].Value?.ToString();
                string price = Dgv1.SelectedRows[0].Cells["가격"].Value?.ToString();

                if (kind != null && name != null && price != null)
                {
                    // 수량을 1로 설정
                    int quantity = 1;

                    // 이미 Dgv2에 동일한 데이터가 있는지 확인
                    bool found = false;
                    foreach (DataGridViewRow row in Dgv2.Rows)
                    {
                        if (row.Cells["종류"].Value?.ToString() == kind && row.Cells["이름"].Value?.ToString() == name)
                        {
                            // 동일한 데이터가 있다면 수량을 증가시키고 플래그 설정
                            int currentQuantity = Convert.ToInt32(row.Cells["수량"].Value);
                            row.Cells["수량"].Value = currentQuantity + 1;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        // 동일한 데이터가 없으면 새로운 행 추가
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(Dgv2);
                        row.Cells[0].Value = kind; // 첫 번째 열에 종류 할당
                        row.Cells[1].Value = name; // 두 번째 열에 이름 할당
                        row.Cells[2].Value = price; // 세 번째 열에 가격 할당
                        row.Cells[3].Value = quantity; // 네 번째 열에 수량 할당
                        Dgv2.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("누락된 데이터가 있습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("선택된 행이 없거나 Dgv2에 적절한 열이 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            // DataGridView 열 추가
            Dgv2.Columns.Add("종류", "종류");
            Dgv2.Columns.Add("이름", "이름");
            Dgv2.Columns.Add("가격", "가격");
            Dgv2.Columns.Add("수량", "수량"); // 수량 열 추가
        }

        private void BtnSub_Click(object sender, EventArgs e)
        {
            // 선택된 행이 있는지 확인
            if (Dgv2.SelectedRows.Count > 0)
            {
                // 선택된 행에서 수량 값을 가져옴
                DataGridViewRow selectedRow = Dgv2.SelectedRows[0];
                int currentQuantity = Convert.ToInt32(selectedRow.Cells["수량"].Value);

                // 수량이 1개 이상인 경우에는 수량을 1 감소시킴
                if (currentQuantity > 1)
                {
                    int newQuantity = currentQuantity - 1;
                    selectedRow.Cells["수량"].Value = newQuantity;
                }
                else // 수량이 1개인 경우에는 행을 삭제함
                {
                    Dgv2.Rows.Remove(selectedRow);
                }
            }
            else
            {
                MessageBox.Show("선택된 행이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            {
                // 선택된 행이 있는지 확인
                if (Dgv2.SelectedRows.Count > 0)
                {
                    // 선택된 행을 삭제함
                    DataGridViewRow selectedRow = Dgv2.SelectedRows[0];
                    Dgv2.Rows.Remove(selectedRow);
                }
                else
                {
                    MessageBox.Show("선택된 행이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // FrmMain의 Listbox1에 Dgv2의 값들을 추가
            foreach (DataGridViewRow row in Dgv2.Rows)
            {
                string valueToAdd = $"{row.Cells["종류"].Value}, " +
                                    $"{row.Cells["이름"].Value}, " +
                                    $"{row.Cells["가격"].Value}, " +
                                    $"{row.Cells["수량"].Value + "개"}"; 
                // FrmMain의 Listbox1에 값을 추가하기 위해 FrmMain 인스턴스에 접근
                ((FrmMain)Application.OpenForms["FrmMain"]).AddToListbox(valueToAdd);
            }

            // 현재 폼 닫기
            this.Close();
        }
    }
}
