using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MyExplorer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // 열기버튼 클릭 이벤트핸들러
        private void BtnOpen_Click(object sender, EventArgs e)
        {

        }

        // 가장 기본. 폼로드 이벤트핸들러 (가장 먼저 실행됨)
        private void FrmMain_Load(object sender, EventArgs e)
        {
            TreeNode root = TrvFolder.Nodes.Add("내 컴퓨터");

            string[] drives = Directory.GetLogicalDrives(); // 내 컴퓨터 논리드라이브
            foreach (var drive in drives)
            {
                TreeNode node = root.Nodes.Add(drive);
                node.Nodes.Add("...");  // 최초의 상태로 Setup
            }
            LsvFiles.View = View.LargeIcon;
        }

        // 트리노드 선택후 이벤트핸들러
        private void TrvFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 폴더에서 노드 선택하면 리스트뷰에 파일표시
            TreeNode current = e.Node;
            if (e.Node == null) return;

            string path = current.FullPath.Replace("\\\\", "\\");
            TxtPath.Text = path.Substring(path.IndexOf("\\") + 1);  // '내 컴퓨터\' 제거

            try
            {
                LsvFiles.Items.Clear(); // 다른 폴더에 있던 이전 파일 정보 삭제
                                        // 현재폴더의 하위폴더 정보 디스플레이
                string[] directories = Directory.GetDirectories(TxtPath.Text);
                foreach (var directory in directories)
                {
                    DirectoryInfo info = new DirectoryInfo(directory);
                    // 리스트뷰 컬럼 이름, 수정일자, 유형, 크기 순으로 리스트뷰 아이템 생성
                    // 문자열 빈값 : "", string.Empty
                    ListViewItem item = new ListViewItem(new String[] { info.Name, info.LastWriteTime.ToString(), "파일폴더", string.Empty });
                    item.ImageIndex = 1; // 리스트뷰의 폴더 이미지 인덱스
                    LsvFiles.Items.Add(item);
                }
                // 파일 리스트업
                string[] files = Directory.GetFiles(TxtPath.Text);  // 현재 폴더내의 파일정보
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    ListViewItem item = new ListViewItem(new string[] { info.Name, info.LastWriteTime.ToString(), info.Extension, info.Length.ToString() });
                    item.ImageIndex = GetImageIndex(info.Extension);    // 확장자의 종류에 따라 이미지번호가 변경
                    LsvFiles.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetImageIndex(string extension)
        {
            // 3: 실행파일, 4:일반파일, 5:txt파일
            var index = -1;
            switch (extension.ToLower())
            {
                case ".exe":
                    index = 3;
                    break;
                case ".txt":
                    index = 5;
                    break;
                default:
                    index = 4;
                    break;
            }

            return index;
        }

        // 트리확장축소 아이콘 클릭해서 확장되기 직전 이벤트핸들러
        private void TrvFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode current = e.Node;
            // 폼이 로드된 후 최초의 상태라면
            if (current.Nodes.Count == 1 && current.Nodes[0].Text.Equals("..."))
            {
                current.Nodes.Clear();  // ...을 삭제
                // FullPath, 내 컴퓨터\C:\ 에서 C:\ 만 남김
                String path = current.FullPath.Substring(current.FullPath.IndexOf('\\') + 1);

                try
                {
                    string[] directories = Directory.GetDirectories(path);
                    foreach (var directory in directories)
                    {
                        Debug.WriteLine(directory); // 디버그시만 출력됨
                        TreeNode newNode = current.Nodes.Add(directory.Substring(directory.LastIndexOf("\\") + 1));
                        newNode.ImageIndex = 1;  // 미선택시 폴더 이미지
                        newNode.SelectedImageIndex = 2; // 선택시 폴더 이미지
                        newNode.Nodes.Add("...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void LsvFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 컨텍스트 메뉴는 오른쪽 버튼에서만 동작
                Cmsfiles.Show(LsvFiles, e.Location); // 마우스 위치에서 쇼를 실행
            }
        }

        private void SpcExplorer_Panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 컨텍스트 메뉴는 오른쪽 버튼에서만 동작
                Cmsfiles.Show(LsvFiles, e.Location); // 마우스 위치에서 쇼를 실행
            }
        }

        private void LsvFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 컨텍스트 메뉴는 오른쪽 버튼에서만 동작
                Cmsfiles.Show(LsvFiles, e.Location);
            }
        }

        private void TsmMenuLargeIcon_Click(object sender, EventArgs e)
        {
            LsvFiles.View = View.LargeIcon;
        }

        private void TsmMenuSmallIcon_Click(object sender, EventArgs e)
        {
            LsvFiles.View = View.SmallIcon;
        }

        private void TsmMenuList_Click(object sender, EventArgs e)
        {
            LsvFiles.View = View.List;
        }

        private void TsmMenuDetails_Click(object sender, EventArgs e)
        {
            LsvFiles.View = View.Details;
        }

        private void TsmMenuTile_Click(object sender, EventArgs e)
        {
            LsvFiles.View = View.Tile;
        }

        // 리스트뷰 아이템 더블클릭 이벤트 핸들러. 실행파일 실행
        private void LsvFiles_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                var extension = LsvFiles.SelectedItems[0].Text.Split(".")[1];
                if (extension == "exe")
                {
                    // 실행파일이면
                    // MessageBox.Show(LsvFiles.SelectedItems[0].Text); -> 디버깅용
                    // 실행파일의 경로는 TxtPath
                    var fullPath = TxtPath.Text + "\\" + LsvFiles.SelectedItems[0].Text;
                    Process.Start(fullPath); // 외부 프로그램 실행
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
