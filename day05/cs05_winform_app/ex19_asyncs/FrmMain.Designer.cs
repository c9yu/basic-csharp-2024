namespace ex19_asyncs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox1 = new GroupBox();
            TxtTarget = new TextBox();
            label2 = new Label();
            BtnCancel = new Button();
            BtnAsyncCopy = new Button();
            BtnSyncCopy = new Button();
            BtnSetTarget = new Button();
            PrgCopy = new ProgressBar();
            BtnGetSource = new Button();
            TxtSource = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtTarget);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(BtnCancel);
            groupBox1.Controls.Add(BtnAsyncCopy);
            groupBox1.Controls.Add(BtnSyncCopy);
            groupBox1.Controls.Add(BtnSetTarget);
            groupBox1.Controls.Add(PrgCopy);
            groupBox1.Controls.Add(BtnGetSource);
            groupBox1.Controls.Add(TxtSource);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(331, 143);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "비동기 전송";
            // 
            // TxtTarget
            // 
            TxtTarget.Location = new Point(50, 53);
            TxtTarget.Name = "TxtTarget";
            TxtTarget.Size = new Size(242, 23);
            TxtTarget.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 8;
            label2.Text = "타겟 :";
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(255, 82);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(70, 23);
            BtnCancel.TabIndex = 7;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnAsyncCopy
            // 
            BtnAsyncCopy.Location = new Point(122, 82);
            BtnAsyncCopy.Name = "BtnAsyncCopy";
            BtnAsyncCopy.Size = new Size(128, 23);
            BtnAsyncCopy.TabIndex = 6;
            BtnAsyncCopy.Text = "비동기화 복사";
            BtnAsyncCopy.UseVisualStyleBackColor = true;
            BtnAsyncCopy.Click += BtnAsyncCopy_Click;
            // 
            // BtnSyncCopy
            // 
            BtnSyncCopy.Location = new Point(6, 82);
            BtnSyncCopy.Name = "BtnSyncCopy";
            BtnSyncCopy.Size = new Size(110, 23);
            BtnSyncCopy.TabIndex = 5;
            BtnSyncCopy.Text = "동기화 복사";
            BtnSyncCopy.UseVisualStyleBackColor = true;
            BtnSyncCopy.Click += BtnSyncCopy_Click;
            // 
            // BtnSetTarget
            // 
            BtnSetTarget.Location = new Point(298, 53);
            BtnSetTarget.Name = "BtnSetTarget";
            BtnSetTarget.Size = new Size(28, 23);
            BtnSetTarget.TabIndex = 4;
            BtnSetTarget.Text = "...";
            BtnSetTarget.UseVisualStyleBackColor = true;
            BtnSetTarget.Click += BtnSetTarget_Click;
            // 
            // PrgCopy
            // 
            PrgCopy.Location = new Point(6, 111);
            PrgCopy.Name = "PrgCopy";
            PrgCopy.Size = new Size(320, 23);
            PrgCopy.TabIndex = 3;
            // 
            // BtnGetSource
            // 
            BtnGetSource.Location = new Point(298, 24);
            BtnGetSource.Name = "BtnGetSource";
            BtnGetSource.Size = new Size(28, 23);
            BtnGetSource.TabIndex = 2;
            BtnGetSource.Text = "...";
            BtnGetSource.UseVisualStyleBackColor = true;
            BtnGetSource.Click += BtnGetSource_Click;
            // 
            // TxtSource
            // 
            TxtSource.Location = new Point(50, 24);
            TxtSource.Name = "TxtSource";
            TxtSource.ReadOnly = true;
            TxtSource.Size = new Size(242, 23);
            TxtSource.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "소스 :";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 161);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            Text = "비동기 파일복사";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox TxtTarget;
        private Label label2;
        private Button BtnCancel;
        private Button BtnAsyncCopy;
        private Button BtnSyncCopy;
        private Button BtnSetTarget;
        private ProgressBar PrgCopy;
        private Button BtnGetSource;
        private TextBox TxtSource;
        private Label label1;
    }
}
