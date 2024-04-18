using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows.Forms.VisualStyles;

namespace MyExploler
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // 열기 버튼 클릭 이벤트 핸들러
        private void BtnOpen_Click(object sender, EventArgs e)
        {

        }

        // 트리노드 선택 후 이벤트 핸들러
        private void FrmMain_Load(object sender, EventArgs e)
        {
            TreeNode root = TrvFolder.Nodes.Add("내 컴퓨터");

            string[] drives = Directory.GetLogicalDrives(); // 내 컴퓨터 논리 드라이브를 전부 가져옴
            foreach (var drive in drives)
            {
                TreeNode node = root.Nodes.Add(drive);
                node.Nodes.Add("..."); // 최초의 상태로 Setup
            }
        }

        // 트리노드 선택 후 이벤트 핸들러
        private void TrvFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 폴더에서 노드 선택하면 리스트뷰에 파일 표시
            TreeNode current = e.Node;
            if (e.Node == null) return;

            string path = current.FullPath.Replace("\\\\", "\\"); // \\\\를 \\로 바꿔준다.
            TxtPath.Text = path.Substring(path.IndexOf("\\") + 1); // '내 컴퓨터 \' 제거

            try
            {
                LsvFile.Items.Clear(); // 다른 폴더에 있던 이전 파일 정보 삭제
                                       // 현재 폴더의 하위 폴더 정보 디스플레이
                string[] directories = Directory.GetDirectories(TxtPath.Text);
                foreach (var directory in directories)
                {
                    DirectoryInfo info = new DirectoryInfo(directory);
                    ListViewItem item = new ListViewItem(new string[] { info.Name, info.LastWriteTime.ToString(), "파일 폴더", string.Empty });
                    // empty를 쓰는 방법, 문자열 빈 값 : "" or string.Empty 두 가지로 사용 가능
                    item.ImageIndex = 1; // 리스트뷰의 폴더 이미지 인덱스
                    LsvFile.Items.Add(item);
                }

                // 파일 리스트 업
                string[] files = Directory.GetFiles(TxtPath.Text);
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    ListViewItem item = new ListViewItem((new string[] { info.Name, info.LastWriteTime.ToString(), info.Extension, info.Length.ToString() }));
                    LsvFile.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        // 트리 확장 축소, 아이콘 클릭해서 확장되기 직전 발생하는 이벤트 핸들러
        private void TrvFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode current = e.Node;
            // 폼이 로드된 후 최초의 상태라면
            if (current.Nodes.Count == 1 && current.Nodes[0].Text.Equals("..."))
            {
                current.Nodes.Clear(); // "..."을 삭제
                // FullPath, 내 컴퓨터\C:\
                string path = current.FullPath.Substring(current.FullPath.IndexOf("\\") + 1);

                try
                {
                    string[] directories = Directory.GetDirectories(path);
                    foreach (var directory in directories)
                    {
                        Debug.WriteLine(directory); // 디버그시에만 출력되므로 이를 통해 정상 작동하는지를 확인 할 수 있다.
                        TreeNode newNode = current.Nodes.Add(directory);
                        newNode.ImageIndex = 1; // 미선택시 폴더 이미지
                        newNode.SelectedImageIndex = 2;
                        newNode.Nodes.Add("...");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}