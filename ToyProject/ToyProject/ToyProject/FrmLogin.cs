using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToyProject
{
    public partial class FrmLogin : Form
    {
        private bool isLogin = false;

        public bool IsLogin
        {   // 로그인 성공여부 저장 변수
            get { return isLogin; }
            set { isLogin = value; }
        }

        public static string ConnSting = "Data Source = localhost;" +
                                    "Initial Catalog = Counter;" +
                                    "Persist Security Info = True;" +
                                    "User ID = sa; Encrypt = False;Password=mssql_p@ss";

        public object LoginId { get; set; }

        public FrmLogin()
        {
            InitializeComponent();

            TxtUserId.Text = string.Empty;  // 실행 시 초기화
            TxtPassword.Text = string.Empty;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit(); // 종료 시 종료를 물어보는 다이얼로그가 나타남
            Environment.Exit(0); // 무조건 종료
        }



        // 로그인 DB 처리시작!!
        private bool LoginProcess()
        {
            var md5Hash = MD5.Create();

            string userId = TxtUserId.Text; // 현재 DB로 넘기는 값
            string userPw = TxtPassword.Text;
            string chkUserId = string.Empty; // DB에서 넘어온 값
            string chkuserPw = string.Empty;
                
            using (SqlConnection conn = new SqlConnection(ConnSting))
            {
                conn.Open();
                // @userId, @userPw 는 쿼리문이 아닌 쿼리문 외부에서 변수값을 안전하게 주입을 시켜줌
                string query = @"SELECT userId,
                                        userPw
                                   FROM usertbl
                                  WHERE userId = @userId
                                    AND userPw = @userPw";
                SqlCommand cmd = new SqlCommand(query, conn);
                // @userId, @userPw 파라미터 할당
                SqlParameter prmUserId = new SqlParameter("@userId", userId); // 파라미터 이름과 변수 이름을 다 동일 시켜야 코딩하기 편함
                SqlParameter prmuserPw = new SqlParameter("userPw", userPw);
                cmd.Parameters.Add(prmUserId);
                cmd.Parameters.Add(prmuserPw);

                SqlDataReader reader = cmd.ExecuteReader(); // 실행해서 reader로 보내라

                if (reader.Read())
                {
                    chkUserId = reader["userId"] != null ? reader["userId"].ToString() : "-"; // 유저아이디가 null일 때 '-' 로 변경
                    chkuserPw = reader["userPw"] != null ? reader["userPw"].ToString() : "-"; // 패스워드가 null일 때 '-' 로 변경
                    LoginId = chkUserId; // 로그인 된 아이디를 할당

                    return true;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 없습니다.", "DB오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }
        }
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 13 은 엔터키를 뜻함
            {
                BtnLogin_Click(sender, e);
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

