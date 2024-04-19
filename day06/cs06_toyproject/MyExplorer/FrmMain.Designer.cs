namespace MyExplorer
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel1 = new Panel();
            BtnOpen = new Button();
            TxtPath = new TextBox();
            label1 = new Label();
            SpcExplorer = new SplitContainer();
            TrvFolder = new TreeView();
            ImgSmallIcon = new ImageList(components);
            LsvFiles = new ListView();
            ClhTitle = new ColumnHeader();
            ClhModifiedDate = new ColumnHeader();
            ClhType = new ColumnHeader();
            ClhSize = new ColumnHeader();
            ImgLargeIcon = new ImageList(components);
            Cmsfiles = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            TsmMenuLargeIcon = new ToolStripMenuItem();
            TsmMenuSmallIcon = new ToolStripMenuItem();
            TsmMenuList = new ToolStripMenuItem();
            TsmMenuDetails = new ToolStripMenuItem();
            TsmMenuTile = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpcExplorer).BeginInit();
            SpcExplorer.Panel1.SuspendLayout();
            SpcExplorer.Panel2.SuspendLayout();
            SpcExplorer.SuspendLayout();
            Cmsfiles.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(BtnOpen);
            panel1.Controls.Add(TxtPath);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(809, 38);
            panel1.TabIndex = 1;
            // 
            // BtnOpen
            // 
            BtnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnOpen.BackColor = SystemColors.Control;
            BtnOpen.Location = new Point(736, 6);
            BtnOpen.Name = "BtnOpen";
            BtnOpen.Size = new Size(61, 23);
            BtnOpen.TabIndex = 0;
            BtnOpen.Text = "열기";
            BtnOpen.UseVisualStyleBackColor = false;
            BtnOpen.Click += BtnOpen_Click;
            // 
            // TxtPath
            // 
            TxtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtPath.Location = new Point(49, 6);
            TxtPath.Name = "TxtPath";
            TxtPath.ReadOnly = true;
            TxtPath.Size = new Size(681, 23);
            TxtPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "경로";
            // 
            // SpcExplorer
            // 
            SpcExplorer.Dock = DockStyle.Fill;
            SpcExplorer.Location = new Point(0, 38);
            SpcExplorer.Name = "SpcExplorer";
            // 
            // SpcExplorer.Panel1
            // 
            SpcExplorer.Panel1.Controls.Add(TrvFolder);
            // 
            // SpcExplorer.Panel2
            // 
            SpcExplorer.Panel2.Controls.Add(LsvFiles);
            SpcExplorer.Size = new Size(809, 401);
            SpcExplorer.SplitterDistance = 269;
            SpcExplorer.TabIndex = 2;
            // 
            // TrvFolder
            // 
            TrvFolder.BorderStyle = BorderStyle.None;
            TrvFolder.Dock = DockStyle.Fill;
            TrvFolder.ImageIndex = 0;
            TrvFolder.ImageList = ImgSmallIcon;
            TrvFolder.Location = new Point(0, 0);
            TrvFolder.Name = "TrvFolder";
            TrvFolder.SelectedImageIndex = 0;
            TrvFolder.Size = new Size(269, 401);
            TrvFolder.TabIndex = 0;
            TrvFolder.BeforeExpand += TrvFolder_BeforeExpand;
            TrvFolder.AfterSelect += TrvFolder_AfterSelect;
            // 
            // ImgSmallIcon
            // 
            ImgSmallIcon.ColorDepth = ColorDepth.Depth32Bit;
            ImgSmallIcon.ImageStream = (ImageListStreamer)resources.GetObject("ImgSmallIcon.ImageStream");
            ImgSmallIcon.TransparentColor = Color.Transparent;
            ImgSmallIcon.Images.SetKeyName(0, "hard-drive.png");
            ImgSmallIcon.Images.SetKeyName(1, "folder-normal.png");
            ImgSmallIcon.Images.SetKeyName(2, "folder-open.png");
            ImgSmallIcon.Images.SetKeyName(3, "file-exe.png");
            ImgSmallIcon.Images.SetKeyName(4, "file-normal.png");
            ImgSmallIcon.Images.SetKeyName(5, "txt.png");
            // 
            // LsvFiles
            // 
            LsvFiles.BorderStyle = BorderStyle.None;
            LsvFiles.Columns.AddRange(new ColumnHeader[] { ClhTitle, ClhModifiedDate, ClhType, ClhSize });
            LsvFiles.Dock = DockStyle.Fill;
            LsvFiles.LargeImageList = ImgLargeIcon;
            LsvFiles.Location = new Point(0, 0);
            LsvFiles.Name = "LsvFiles";
            LsvFiles.Size = new Size(536, 401);
            LsvFiles.SmallImageList = ImgSmallIcon;
            LsvFiles.TabIndex = 0;
            LsvFiles.UseCompatibleStateImageBehavior = false;
            LsvFiles.View = View.Details;
            LsvFiles.DoubleClick += LsvFiles_DoubleClick;
            LsvFiles.MouseDown += LsvFiles_MouseDown;
            // 
            // ClhTitle
            // 
            ClhTitle.Text = "이름";
            ClhTitle.Width = 200;
            // 
            // ClhModifiedDate
            // 
            ClhModifiedDate.Text = "수정일자";
            ClhModifiedDate.Width = 100;
            // 
            // ClhType
            // 
            ClhType.Text = "유형";
            ClhType.Width = 100;
            // 
            // ClhSize
            // 
            ClhSize.Text = "크기";
            ClhSize.TextAlign = HorizontalAlignment.Right;
            ClhSize.Width = 100;
            // 
            // ImgLargeIcon
            // 
            ImgLargeIcon.ColorDepth = ColorDepth.Depth32Bit;
            ImgLargeIcon.ImageStream = (ImageListStreamer)resources.GetObject("ImgLargeIcon.ImageStream");
            ImgLargeIcon.TransparentColor = Color.Transparent;
            ImgLargeIcon.Images.SetKeyName(0, "hard-drive.png");
            ImgLargeIcon.Images.SetKeyName(1, "folder-normal.png");
            ImgLargeIcon.Images.SetKeyName(2, "folder-open.png");
            ImgLargeIcon.Images.SetKeyName(3, "file-exe.png");
            ImgLargeIcon.Images.SetKeyName(4, "file-normal.png");
            ImgLargeIcon.Images.SetKeyName(5, "txt.png");
            // 
            // Cmsfiles
            // 
            Cmsfiles.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            Cmsfiles.Name = "contextMenuStrip1";
            Cmsfiles.Size = new Size(99, 26);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { TsmMenuLargeIcon, TsmMenuSmallIcon, TsmMenuList, TsmMenuDetails, TsmMenuTile });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(98, 22);
            toolStripMenuItem1.Text = "보기";
            // 
            // TsmMenuLargeIcon
            // 
            TsmMenuLargeIcon.Name = "TsmMenuLargeIcon";
            TsmMenuLargeIcon.Size = new Size(180, 22);
            TsmMenuLargeIcon.Text = "큰 아이콘";
            TsmMenuLargeIcon.Click += TsmMenuLargeIcon_Click;
            // 
            // TsmMenuSmallIcon
            // 
            TsmMenuSmallIcon.Name = "TsmMenuSmallIcon";
            TsmMenuSmallIcon.Size = new Size(180, 22);
            TsmMenuSmallIcon.Text = "작은 아이콘";
            TsmMenuSmallIcon.Click += TsmMenuSmallIcon_Click;
            // 
            // TsmMenuList
            // 
            TsmMenuList.Name = "TsmMenuList";
            TsmMenuList.Size = new Size(180, 22);
            TsmMenuList.Text = "목록";
            TsmMenuList.Click += TsmMenuList_Click;
            // 
            // TsmMenuDetails
            // 
            TsmMenuDetails.Name = "TsmMenuDetails";
            TsmMenuDetails.Size = new Size(180, 22);
            TsmMenuDetails.Text = "자세히";
            TsmMenuDetails.Click += TsmMenuDetails_Click;
            // 
            // TsmMenuTile
            // 
            TsmMenuTile.Name = "TsmMenuTile";
            TsmMenuTile.Size = new Size(180, 22);
            TsmMenuTile.Text = "타일";
            TsmMenuTile.Click += TsmMenuTile_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 439);
            Controls.Add(SpcExplorer);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "내 탐색기 v1.0";
            Load += FrmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            SpcExplorer.Panel1.ResumeLayout(false);
            SpcExplorer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SpcExplorer).EndInit();
            SpcExplorer.ResumeLayout(false);
            Cmsfiles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BtnOpen;
        private TextBox TxtPath;
        private Label label1;
        private SplitContainer SpcExplorer;
        private TreeView TrvFolder;
        private ListView LsvFiles;
        private ColumnHeader ClhTitle;
        private ColumnHeader ClhType;
        private ColumnHeader ClhModifiedDate;
        private ColumnHeader ClhSize;
        private ImageList ImgSmallIcon;
        private ImageList ImgLargeIcon;
        private ContextMenuStrip Cmsfiles;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem TsmMenuLargeIcon;
        private ToolStripMenuItem TsmMenuSmallIcon;
        private ToolStripMenuItem TsmMenuList;
        private ToolStripMenuItem TsmMenuDetails;
        private ToolStripMenuItem TsmMenuTile;
    }
}
