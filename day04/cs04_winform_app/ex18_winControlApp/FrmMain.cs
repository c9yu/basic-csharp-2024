namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonsts = FontFamily.Families; // 현재 OS내에 설치된 폰트를 다 가져와라
            foreach (var font in Fonsts)
            {
                CboFonsts.Items.Add(font.Name);
            }
        }

        // Font를 볼드, 이텔릭으로 변경하는 메서드
        void ChangeFont()
        {
            if (CboFonsts.SelectedIndex < 0) // 아무것도 선택 안된 상태
                return;

            FontStyle style = FontStyle.Regular; // 일반 글자 (노멀, 볼드 X, 이텔릭 X)

            if (ChkBold.Checked) // '굵게' 체크박스를 체크하면
                style |= FontStyle.Bold;

            if (ChkItalic.Checked) // '이텔릭' 체크박스를 체크하면
                style |= FontStyle.Italic;

            TxtSampleText.Font = new Font((string)CboFonsts.SelectedItem, 12, style);
        }

        private void CboFonsts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }
    }
}
