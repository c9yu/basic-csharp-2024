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
            var Fonsts = FontFamily.Families; // ���� OS���� ��ġ�� ��Ʈ�� �� �����Ͷ�
            foreach (var font in Fonsts)
            {
                CboFonsts.Items.Add(font.Name);
            }
        }

        // Font�� ����, ���ڸ����� �����ϴ� �޼���
        void ChangeFont()
        {
            if (CboFonsts.SelectedIndex < 0) // �ƹ��͵� ���� �ȵ� ����
                return;

            FontStyle style = FontStyle.Regular; // �Ϲ� ���� (���, ���� X, ���ڸ� X)

            if (ChkBold.Checked) // '����' üũ�ڽ��� üũ�ϸ�
                style |= FontStyle.Bold;

            if (ChkItalic.Checked) // '���ڸ�' üũ�ڽ��� üũ�ϸ�
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
