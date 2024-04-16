namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // Ʈ���� ����̸����� ����� ������
        public FrmMain()
        {
            InitializeComponent(); // �����̳ʿ��� ������ ȭ�鱸���� �ʱ�ȭ

            LsvDummy.Columns.Add("�̸�");
            LsvDummy.Columns.Add("����");
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

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode node in TrvDummy.Nodes)
            {
                TreeToList(node);
            }
        }

        private void TreeToList(TreeNode node)
        {
            //throw new NotImplementedException();
            LsvDummy.Items.Add(
                new ListViewItem(
                    new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }
                    )
                );
            foreach (TreeNode subNode in node.Nodes)
            {
                TreeToList(subNode);
            }
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

        // Ʈ���� ��ũ�� �̺�Ʈ �ڵ鷯
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PrgDummy.Value = TrbDummy.Value; // Ʈ������ �����͸� �ű�� ���α׷����� ���� ���� ����ȴ�.
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "��� â";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Red;
            FrmModal.ShowDialog(); // ���â ����
            // ���� â�� �ݱ� ������ '�θ� â'�� ���� �� ����.
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "��޸��� â";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Green;
            FrmModaless.Show(); // ��޸��� â ����
            // ���� â�� ���� �ʾƵ� '�θ� â'�� ���� �� �ִ�.
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TxtSampleText.Text, "�޽��� �ڽ�", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("��� �����Ű���?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("�� �����ϴ�!");
            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("�ƴϿ� ���� �ʽ��ϴ�.");
            }
        }

        // ������ �����ư�� Ŭ������ �� �߻��ϴ� �̺�Ʈ �ڵ鷯
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("���� �����Ͻðڽ��ϱ�?", "���� ����", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.No) e.Cancel = true;
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rand.Next().ToString());
            TreeToList();

        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode == null) // �θ��带 �������� ������
            {
                MessageBox.Show("������ ��尡 ����.", "���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // �� �̻� ������� �޼��� ����
            }
            TrvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            TrvDummy.SelectedNode.Expand();
            TreeToList(); // ����Ʈ�並 �ٽ� �׷��ش�.
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DlgOpenimage.Title = "�̹��� ����";
            DlgOpenimage.Filter = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png"; // Filter�� Ȯ���ڸ� �̹����θ� ����
            var res = DlgOpenimage.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                //MessageBox.Show(DlgOpenimage.FileName.ToString());
                PicNormal.Image = Bitmap.FromFile(DlgOpenimage.FileName);
            }
        }

        private void PicNormal_Click(object sender, EventArgs e)
        {
            if (PicNormal.SizeMode == PictureBoxSizeMode.Normal)
            {
                PicNormal.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PicNormal.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}
