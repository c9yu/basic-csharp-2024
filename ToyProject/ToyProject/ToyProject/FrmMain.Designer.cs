namespace ToyProject
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
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            listBox3 = new ListBox();
            listBox4 = new ListBox();
            listBox5 = new ListBox();
            listBox6 = new ListBox();
            BtnCount = new Button();
            BtnEnd = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            LblTimer = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 38);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(220, 139);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(12, 213);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(220, 139);
            listBox2.TabIndex = 0;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(12, 388);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(220, 139);
            listBox3.TabIndex = 0;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 15;
            listBox4.Location = new Point(238, 38);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(220, 139);
            listBox4.TabIndex = 0;
            // 
            // listBox5
            // 
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 15;
            listBox5.Location = new Point(238, 213);
            listBox5.Name = "listBox5";
            listBox5.Size = new Size(220, 139);
            listBox5.TabIndex = 0;
            // 
            // listBox6
            // 
            listBox6.FormattingEnabled = true;
            listBox6.ItemHeight = 15;
            listBox6.Location = new Point(238, 388);
            listBox6.Name = "listBox6";
            listBox6.Size = new Size(220, 139);
            listBox6.TabIndex = 0;
            // 
            // BtnCount
            // 
            BtnCount.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnCount.Location = new Point(464, 431);
            BtnCount.Name = "BtnCount";
            BtnCount.Size = new Size(217, 45);
            BtnCount.TabIndex = 1;
            BtnCount.Text = "통계";
            BtnCount.UseVisualStyleBackColor = true;
            // 
            // BtnEnd
            // 
            BtnEnd.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnEnd.Location = new Point(464, 482);
            BtnEnd.Name = "BtnEnd";
            BtnEnd.Size = new Size(217, 45);
            BtnEnd.TabIndex = 1;
            BtnEnd.Text = "종료";
            BtnEnd.UseVisualStyleBackColor = true;
            BtnEnd.Click += BtnEnd_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // LblTimer
            // 
            LblTimer.AutoSize = true;
            LblTimer.Location = new Point(464, 413);
            LblTimer.Name = "LblTimer";
            LblTimer.Size = new Size(31, 15);
            LblTimer.TabIndex = 2;
            LblTimer.Text = "시간";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 3;
            label1.Text = "테이블 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(236, 15);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 3;
            label2.Text = "테이블 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label3.Location = new Point(10, 190);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 3;
            label3.Text = "테이블 3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label4.Location = new Point(236, 190);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 3;
            label4.Text = "테이블 4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label5.Location = new Point(10, 365);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 3;
            label5.Text = "테이블 5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label6.Location = new Point(236, 365);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 3;
            label6.Text = "테이블 6";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 544);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LblTimer);
            Controls.Add(BtnEnd);
            Controls.Add(BtnCount);
            Controls.Add(listBox6);
            Controls.Add(listBox3);
            Controls.Add(listBox5);
            Controls.Add(listBox2);
            Controls.Add(listBox4);
            Controls.Add(listBox1);
            Name = "FrmMain";
            Text = "매장 계산대";
            FormClosing += FrmMain_FormClosing_1;
            Load += FrmMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private ListBox listBox4;
        private ListBox listBox5;
        private ListBox listBox6;
        private Button BtnCount;
        private Button BtnEnd;
        private System.Windows.Forms.Timer timer1;
        private Label LblTimer;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
