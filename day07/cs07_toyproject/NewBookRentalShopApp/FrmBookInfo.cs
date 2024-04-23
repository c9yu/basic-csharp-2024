﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmBookInfo : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookInfo()
        {
            InitializeComponent();
        }

        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData(); // bookstbl에서 데이터를 가져오는 부분
            // 콤보박스에 들어가는 데이터를 초기화
            
            InitInputData(); // 콤보박스, 날짜, NumericUpDown 컨트롤 데이터, 초기화 담당

        }

        private void InitInputData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();

                    var query = @"Select Division, Names FROM divtbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // SqlDataReader = 개발자가 하나씩 처리할 때 사용
                    // SqlDataAdapter, DataSet = 한번에 데이터그리드 뷰등에 뿌릴 때
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();

                    while (reader.Read())
                    {
                        // Key, Value
                        // B001, 공포/스릴러
                        // reader[0] = Division, reader[1] = Names컬럼
                        temp.Add(reader[0].ToString(), reader[1].ToString());
                    }

                    Debug.WriteLine(temp.Count);
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value"; // 공포/스릴러 표시
                    CboDivision.ValueMember = "Key"; // B001
                    CboDivision.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            TxtBookIdx.Focus(); // 번호는 자동증가하기 때문에 입력불가
            CboDivision.SelectedIndex = -1;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력검증(Validation Check), 이름, 패스워드를 안넣으면
            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                MessageBox.Show("저자명을 입력하세요.");
                return;
            }

            // 콤보박스는 SelectedIndex가 -1이 되면 안된다.
            if (CboDivision.SelectedIndex < 0)
            {
                MessageBox.Show("구분명을 선택하세요.");
                return;
            }

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("책제목을 입력하세요.");
                return;
            }

            // 출판일은 기본으로 오늘 날짜가 들어감
            // ISBN은 null이 들어가도 상관없음
            // 책가격은 기본이 0원



            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT이면
                    {
                        query = @"INSERT INTO [dbo].[bookstbl]
                                            ( [Author]
                                            , [Division]
                                            , [Names]
                                            , [ReleaseDate]
                                            , [ISBN]
                                            , [Price])
                                      VALUES
                                            ( @Author
                                            , @Division
                                            , @Names
                                            , @ReleaseDate
                                            , @ISBN
                                            , @Price)";
                    }
                    else // UPDATE
                    {
                        query = @"UPDATE [bookstbl]
                                     SET [Author] = @Author
                                       , [Division] = @Division
                                       , [Names] = @Names
                                       , [ReleaseDate] = @ReleaseDate
                                       , [ISBN] = @ISBN
                                       , [Price] = @Price
                                   WHERE bookIdx = @bookIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmAuthor = new SqlParameter("@Author", TxtAuthor.Text);
                    cmd.Parameters.Add(prmAuthor);
                    SqlParameter prmDivision = new SqlParameter("@Division", CboDivision.SelectedValue);
                    cmd.Parameters.Add(prmDivision);
                    SqlParameter prmNames = new SqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmNames);
                    SqlParameter prmReleaseDate = new SqlParameter("@ReleaseDate", DtpReleaseDate.Value);
                    cmd.Parameters.Add(prmReleaseDate);
                    SqlParameter prmIsbn = new SqlParameter("@ISBN", TxtIsbn.Text);
                    cmd.Parameters.Add(prmIsbn);
                    SqlParameter prmPrice = new SqlParameter("@Price", NudPrice.Value);
                    cmd.Parameters.Add(prmPrice);

                    if (isNew != true)
                    {
                        SqlParameter prmBookIdx = new SqlParameter("@bookIdx", TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);
                    }

                    //SqlParameter prmDivision = new SqlParameter("@Division", TxtBookIdx.Text);
                    //SqlParameter prmNames = new SqlParameter("@Names", TxtAuthor.Text);
                    // Command에 Parameter를 연결해줘야 함
                    //cmd.Parameters.Add(prmDivision);
                    //cmd.Parameters.Add(prmNames);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this 메시지 박스의 부모창이 누구냐, FrmLoginUser
                        MetroMessageBox.Show(this, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // MessageBox.Show("저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // MessageBox.Show("저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TxtBookIdx.Text = TxtAuthor.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            CboDivision.SelectedIndex = -1;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;
            RefreshData();
            
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBookIdx.Text)) // 책 순번이 없으면
            {
                MetroMessageBox.Show(this, "삭제할 구분값을 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var asnwer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (asnwer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM bookstbl WHERE bookIdx = @bookIdx";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmbookIdx = new SqlParameter("@bookIdx", TxtBookIdx.Text);
                cmd.Parameters.Add(prmbookIdx);

                var result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MetroMessageBox.Show(this, "삭제 성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroMessageBox.Show(this, "삭제 실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            TxtBookIdx.Text = TxtAuthor.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            CboDivision.SelectedIndex = -1;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;
            RefreshData(); // 데이터그리드 재조회
        }

        // 데이터그리뷰에 데이터를 새로 부르기
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT b.[bookIdx]
                                   , b.[Author]
	                               , b.[Division]
	                               , d.Names AS DivNames
                                   , b.[Names]
	                               , b.[ReleaseDate]
	                               , b.[ISBN]
	                               , b.[Price]
                                FROM [bookstbl] AS b
                                JOIN divtbl AS d
                                  ON b.Division = d.Division"; // 화면에 필요한 테이블 쿼리 변경
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "bookstbl");

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true; // 수정불가
                DgvResult.Columns[0].HeaderText = "책 번호";
                DgvResult.Columns[1].HeaderText = "저자명";
                DgvResult.Columns[2].HeaderText = "구분코드";
                DgvResult.Columns[3].HeaderText = "구분명"; // 새로 추가
                DgvResult.Columns[4].HeaderText = "책 제목";
                DgvResult.Columns[5].HeaderText = "출판일";
                DgvResult.Columns[6].HeaderText = "ISBN";
                DgvResult.Columns[7].HeaderText = "책 가격";
                // 각 컬럼 넓이 지정
                DgvResult.Columns[0].Width = 68;
                DgvResult.Columns[1].Width = 145;
                DgvResult.Columns[2].Visible = false; // 2번을 숨기겠다!
                DgvResult.Columns[4].Width = 195;
                DgvResult.Columns[5].Width = 73;
                DgvResult.Columns[7].Width = 68;

            }
        }

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스값
                TxtBookIdx.Text = selData.Cells[0].Value.ToString(); // 책순번
                TxtAuthor.Text = selData.Cells[1].Value.ToString(); // 저자명
                TxtNames.Text = selData.Cells[4].Value.ToString(); // 책 제목

                // 1. "2019-03-09" 문자열을 DateTime.Parse()을 통해 DateTime형으로 변경해주는 메소드
                DtpReleaseDate.Value = DateTime.Parse(selData.Cells[5].Value.ToString());
                TxtIsbn.Text = selData.Cells[6].Value.ToString();

                // 2. "20000" 문자열로 입력된 가격을 숫자 형태로 형변환 해주는 메소드
                NudPrice.Value = Decimal.Parse(selData.Cells[7].Value.ToString());

                // 1,2 처럼 거의 모든 타입에 ~.Parse(string)가 존재한다. -> 문자열을 형변환해주는 메소드

                // 콤보박스는 맨 마지막에
                // MessageBox.Show(selData.Cells[3].Value.ToString()); // 구분명이 출력된다.
                CboDivision.SelectedValue = selData.Cells[2].Value;
                // 사용자가 사용하기 위한것은 구분명
                // 개발자가 사용하기 위한 것은 구분코드 그래서 콤보박스가 필요하다.

                isNew = false; // UPDATE
            }
        }

    }
}
