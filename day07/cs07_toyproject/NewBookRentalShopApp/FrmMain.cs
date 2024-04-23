using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmMain : MetroForm
    {
        // 각 화면을 초기화
        FrmLoginUser frmLoginUser = null; // 객체를 메서드로 생성
        FrmBookDivision frmBookDivision = null;
        FrmBookInfo frmBookInfo = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        // 폼로드 이벤트핸들러. 로그인창을 먼저 띄워야 함
        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.TopMost = true; // 실행 창 상단에 가도록 해준다
            frm.ShowDialog();

        }

        private void MnuLoginUsers_Click(object sender, EventArgs e)
        {
            // 만약 이미 창이 열려있으면 새로 창이 생성할 필요가 없기 때문에
            // 이런 작업을 안하며 메뉴 클릭 시 새 폼이 열림
            frmLoginUser = ShowActiveForm(frmLoginUser, typeof(FrmLoginUser)) as FrmLoginUser;
        }

        // 책 장르관리 메뉴 클릭 이벤트핸들러
        private void MnuBookDivision_Click(object sender, EventArgs e)
        {
            frmBookDivision = ShowActiveForm(frmBookDivision, typeof(FrmBookDivision)) as FrmBookDivision;
        }

        private void MnuBookInfo_Click(object sender, EventArgs e)
        {
            // 객체변수, 객체변수, 클래스, 클래스(밑에 순서대로)
            frmBookInfo = ShowActiveForm(frmBookInfo, typeof(FrmBookInfo)) as FrmBookInfo;  // FrmBookInfo로 형 변환
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

    }
}
