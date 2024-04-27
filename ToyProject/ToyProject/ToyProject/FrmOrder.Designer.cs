namespace ToyProject
{
    partial class FrmOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Dgv1 = new DataGridView();
            BtnG = new Button();
            BtnF = new Button();
            BtnD = new Button();
            BtnAdd = new Button();
            BtnSub = new Button();
            BtnDelete = new Button();
            BtnBack = new Button();
            Dgv2 = new DataGridView();
            BtnPay = new Button();
            ((System.ComponentModel.ISupportInitialize)Dgv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Dgv2).BeginInit();
            SuspendLayout();
            // 
            // Dgv1
            // 
            Dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv1.Location = new Point(426, 56);
            Dgv1.Name = "Dgv1";
            Dgv1.ReadOnly = true;
            Dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv1.Size = new Size(318, 198);
            Dgv1.TabIndex = 0;
            // 
            // BtnG
            // 
            BtnG.Location = new Point(426, 12);
            BtnG.Name = "BtnG";
            BtnG.Size = new Size(75, 38);
            BtnG.TabIndex = 1;
            BtnG.Text = "국밥";
            BtnG.UseVisualStyleBackColor = true;
            BtnG.Click += button1_Click;
            // 
            // BtnF
            // 
            BtnF.Location = new Point(507, 12);
            BtnF.Name = "BtnF";
            BtnF.Size = new Size(75, 38);
            BtnF.TabIndex = 1;
            BtnF.Text = "음식";
            BtnF.UseVisualStyleBackColor = true;
            BtnF.Click += button2_Click;
            // 
            // BtnD
            // 
            BtnD.Location = new Point(588, 12);
            BtnD.Name = "BtnD";
            BtnD.Size = new Size(75, 38);
            BtnD.TabIndex = 1;
            BtnD.Text = "주류";
            BtnD.UseVisualStyleBackColor = true;
            BtnD.Click += button3_Click;
            // 
            // BtnAdd
            // 
            BtnAdd.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnAdd.Location = new Point(507, 260);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(75, 34);
            BtnAdd.TabIndex = 2;
            BtnAdd.Text = "+";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnSub
            // 
            BtnSub.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnSub.Location = new Point(588, 260);
            BtnSub.Name = "BtnSub";
            BtnSub.Size = new Size(75, 34);
            BtnSub.TabIndex = 2;
            BtnSub.Text = "-";
            BtnSub.UseVisualStyleBackColor = true;
            BtnSub.Click += BtnSub_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(669, 260);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(75, 34);
            BtnDelete.TabIndex = 2;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnBack
            // 
            BtnBack.Location = new Point(12, 12);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(75, 38);
            BtnBack.TabIndex = 1;
            BtnBack.Text = "뒤로가기";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // Dgv2
            // 
            Dgv2.BackgroundColor = SystemColors.ControlLight;
            Dgv2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv2.Location = new Point(12, 56);
            Dgv2.Name = "Dgv2";
            Dgv2.ReadOnly = true;
            Dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv2.Size = new Size(408, 236);
            Dgv2.TabIndex = 3;
            // 
            // BtnPay
            // 
            BtnPay.Location = new Point(426, 260);
            BtnPay.Name = "BtnPay";
            BtnPay.Size = new Size(75, 34);
            BtnPay.TabIndex = 1;
            BtnPay.Text = "결제";
            BtnPay.UseVisualStyleBackColor = true;
            BtnPay.Click += BtnPay_Click;
            // 
            // FrmOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 304);
            Controls.Add(Dgv2);
            Controls.Add(BtnDelete);
            Controls.Add(BtnSub);
            Controls.Add(BtnAdd);
            Controls.Add(BtnPay);
            Controls.Add(BtnD);
            Controls.Add(BtnF);
            Controls.Add(BtnBack);
            Controls.Add(BtnG);
            Controls.Add(Dgv1);
            Name = "FrmOrder";
            Text = "Form1";
            Load += FrmOrder_Load;
            ((System.ComponentModel.ISupportInitialize)Dgv1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Dgv2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Dgv1;
        private Button BtnG;
        private Button BtnF;
        private Button BtnD;
        private Button BtnAdd;
        private Button BtnSub;
        private Button BtnDelete;
        private Button BtnBack;
        private DataGridView Dgv2;
        private Button BtnPay;
    }
}