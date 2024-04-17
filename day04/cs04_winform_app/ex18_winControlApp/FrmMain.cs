using System.ComponentModel;
using System.Threading; // 스레드 클래스 사용등록

namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // 트리뷰 노드이름으로 사용할 랜덤값
        public FrmMain()
        {
            InitializeComponent(); // 디자이너에서 정의한 화면구성을 초기화

            LsvDummy.Columns.Add("이름");
            LsvDummy.Columns.Add("깊이");

            GrbEditor.Text = "텍스트 에디터";
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

        // 트랙바 스크롤 이벤트 핸들러
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PrgDummy.Value = TrbDummy.Value; // 트랙바의 포인터를 옮기면 프로그레스바 값도 같이 변경된다.
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "모달 창";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Red;
            FrmModal.StartPosition = FormStartPosition.CenterParent; // 모달창이 열릴 때 위치를 조정
            FrmModal.ShowDialog(); // 모달창 띄우기
            // 열린 창을 닫기 전까지 '부모 창'을 닫을 수 없다.
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "모달리스 창";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Green;
            // 모달리스 창을 부모 정중앙에 위치시킬 때는 아래와 같이 작업해야 함
            FrmModaless.StartPosition = FormStartPosition.Manual;
            FrmModaless.Location = new Point(this.Location.X + (this.Width - FrmModaless.Width) / 2,
                                this.Location.Y + (this.Height - FrmModaless.Height) / 2);
            FrmModaless.Show(); // 모달리스 창 띄우기 
            // 열린 창을 닫지 않아도 '부모 창'을 닫을 수 있다.// '부모 창'을 닫으면 같이 닫힌다
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TxtSampleText.Text, "메시지 박스", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("기분 좋으신가요?", "질문", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("네 좋습니다!");
            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("아니요 좋지 않습니다.");
            }
        }

        // 윈도우 종료버튼을 클릭했을 때 발생하는 이벤트 핸들러
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("정말 종료하시겠습니까?", "종료 여부", MessageBoxButtons.YesNo,
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
            if (TrvDummy.SelectedNode == null) // 부모노드를 선택하지 않으면
            {
                MessageBox.Show("선택한 노드가 없음.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // 더 이상 진행없이 메서드 종료
            }
            TrvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            TrvDummy.SelectedNode.Expand();
            TreeToList(); // 리스트뷰를 다시 그려준다.
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DlgOpenimage.Title = "이미지 열기";
            DlgOpenimage.Filter = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png"; // Filter는 확장자를 이미지로만 한정
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

        private void BtnFileLoad_Click(object sender, EventArgs e)
        {
            // OpenFileDialog 컨트롤을 디자인에서 구성하지 않고 생성하는 방법
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false; // 여러개 파일 선택을 금지
            dialog.Filter = "Text Files(*.txt;*.cs;*.py)|*.txt;*.cs;*.py";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // UTF-8이 한글이 깨짐. EUC-KR(Window 949), UTF-8(BOM)은 한글 문제 없음.
                RtxEditor.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void BtnFileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "RichText Files(*.rtf)|*rtf";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                RtxEditor.SaveFile(dialog.FileName, RichTextBoxStreamType.RichNoOleObjs);
            }
        }

        private void BtnNothread_Click(object sender, EventArgs e) // 스레드가 없는 경우 응답없음이 발생
        {
            // 프로그레스바 설정
            var maxValue = 100;
            var currValue = 0;
            PrgProcess.Minimum = 0;
            PrgProcess.Maximum = maxValue;
            PrgProcess.Value = 0; // 0으로 초기화

            BtnThread.Enabled = false;
            BtnNothread.Enabled = false;
            BtnStop.Enabled = true;

            // 반복 시작
            for (var i = 0; i <= maxValue; i++)
            {
                // 내부적으로 복잡하고 시간이 많이 요하는 작업
                currValue = i;
                PrgProcess.Value = currValue;
                TxtLog.AppendText($"현재 진행 :{currValue}\r\n"); // 윈도우는 \r\n를 같이 사용해주는 것이 원래는 맞다. 
                Thread.Sleep(500); // 1000ms = 1초, 500ms = 0.5초
            }
            BtnThread.Enabled = BtnNothread.Enabled = true;
            BtnStop.Enabled = false;
        }

        private void BtnThread_Click(object sender, EventArgs e)
        {
            var maxValue = 100;
            PrgProcess.Minimum = 0;
            PrgProcess.Maximum = maxValue;
            PrgProcess.Value = 0; // 0으로 초기화

            BtnThread.Enabled = BtnNothread.Enabled = false;
            BtnStop.Enabled= true;

            BgwProgress.WorkerReportsProgress = true; // 진행상황 리포트 활성화
            BgwProgress.WorkerSupportsCancellation = true; // 백그라운드 워커 취소 활성화
            BgwProgress.RunWorkerAsync(null); // 배그라운드 워커 실행!
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            BgwProgress.CancelAsync(); // 비동기로 취소실행!
        }

        #region '백그라운드 워커 이벤트 핸들러'
        
        private void DoRealWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var maxValue = 100;
            double currValue = 0;

            for (var i = 0; i <= maxValue; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    currValue = i;
                    // 오랜 시간이 걸리는 일처리
                    Thread.Sleep(500);

                    // 아래를 실행하면, BgwProgress_ProgressChanged 이 이벤트 핸들러의
                    // ProgressChangedEventArgs내의 ProcessPercentage 속성에 값이 들어감.
                    worker.ReportProgress((int)((currValue / maxValue) * 100));
                }
            }
        }

        // 일을 진행
        private void BgwProgress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DoRealWork((BackgroundWorker)sender, e);
            e.Result = null;
        }

        // 진행상태가 바뀌는 것을 표시
        private void BgwProgress_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            PrgProcess.Value = e.ProgressPercentage;
            TxtLog.AppendText($"진행률 : {PrgProcess.Value}% \r\n");
        }

        // 진행이 완료되면 그 이후 처리
        private void BgwProgress_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                TxtLog.AppendText("작업이 취소되었습니다.\r\n");
            }
            else
            {
                TxtLog.AppendText("작업이 완료되었습니다.\r\n");
            }
            BtnNothread.Enabled = BtnThread.Enabled = true;
            BtnStop.Enabled = false;
        }
        #endregion
    }
}
