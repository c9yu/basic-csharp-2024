using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmLogin : MetroForm
    {
        private bool isLogin = false;

        public bool IsLogin
        {   // 로그인 성공여부 저장 변수
            get { return isLogin; }
            set { isLogin = value; }
        }

        public FrmLogin()
        {
            InitializeComponent();

            TxtUserId.Text = string.Empty;  // 실행 시 초기화
            TxtPassword.Text = string.Empty;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit(); // 종료 시 종료를 물어보는 다이얼로그가 나타남
            Environment.Exit(0); // 무조건 종료
        }

        // 로그인버튼 클릭 이벤트핸들러
        private void BtbLogin_Click(object sender, EventArgs e)
        {
            bool isfail = false;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                isfail = true;
                errMsg += "아이디를 입력하라.\n";
            }

            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                isfail = true;
                errMsg += "패스워들를 입력하라.\n";
            }
            // DB연계
            IsLogin = LoginProcess();   // 로그인이 성공하면 True, 실패하면 False 리턴
            if (IsLogin) this.Close();  // 현재 로그인창 닫기
        }

        // 로그인 DB 처리시작!!
        private bool LoginProcess()
        {
            var md5Hash = MD5.Create();

            string userId = TxtUserId.Text; // 현재 DB로 넘기는 값
            string password = TxtPassword.Text;
            string chkUserId = string.Empty; // DB에서 넘어온 값
            string chkPassword = string.Empty;

            /*
             * 1. Connection 생성
             * 2. 쿼리 문자열 작성
             * 3. SqlCommand 명령 객체 생성
             * 4. SqlParameter 객체 생성
             * 5. Select SqlDataReader, SqlDataSet 객체 사용
             * 6. CUD 작업 SqlCommand.ExcuteQuery()
             * 7. Connection 닫기
             */
            // 연결문자열(ConnectionString)
            // Data Source = localhost; Initial Catalog = BookRentalShop2024; Persist Security Info = True; User ID = sa; Encrypt = False;Password=mssql_p@ss
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                // @userId, @password 는 쿼리문이 아닌 쿼리문 외부에서 변수값을 안전하게 주입을 시켜줌
                string query = @"SELECT userId
                                      , [password]
                                   FROM usertbl
                                  WHERE userId = @userId
                                    AND [password] = @password";    
                SqlCommand cmd = new SqlCommand(query, conn);
                // @userId, @password 파라미터 할당
                SqlParameter prmUserId = new SqlParameter("@userId", userId); // 파라미터 이름과 변수 이름을 다 동일 시켜야 코딩하기 편함
                SqlParameter prmPassword = new SqlParameter("Password", Helper.Common.GetMd5Hash(md5Hash, password));
                cmd.Parameters.Add(prmUserId);
                cmd.Parameters.Add(prmPassword);

                SqlDataReader reader = cmd.ExecuteReader(); // 실행해서 reader로 보내라
                
                if (reader.Read())
                {
                    chkUserId = reader["userId"] != null ? reader["userId"].ToString() : "-"; // 유저아이디가 null일 때 '-' 로 변경
                    chkPassword = reader["password"] != null ? reader["password"].ToString() : "-"; // 패스워드가 null일 때 '-' 로 변경

                    return true;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 없습니다.", "DB오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            } // using을 사용하면 conn.Close()가 필요없음! ★★★
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 13 은 엔터키를 뜻함
            {
                BtbLogin_Click(sender, e);
            }
        }

        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 13 은 엔터키를 뜻함
            {
                TxtPassword.Focus();
            }

        }
        
    }
}
