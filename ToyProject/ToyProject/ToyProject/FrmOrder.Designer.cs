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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            listView1 = new ListView();
            button8 = new Button();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(366, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(378, 198);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(366, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 38);
            button1.TabIndex = 1;
            button1.Text = "국밥";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(447, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 38);
            button2.TabIndex = 1;
            button2.Text = "음식";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(528, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 38);
            button3.TabIndex = 1;
            button3.Text = "주류";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(366, 260);
            button4.Name = "button4";
            button4.Size = new Size(90, 34);
            button4.TabIndex = 2;
            button4.Text = "주문";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button5.Location = new Point(462, 260);
            button5.Name = "button5";
            button5.Size = new Size(90, 34);
            button5.TabIndex = 2;
            button5.Text = "+";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button6.Location = new Point(558, 260);
            button6.Name = "button6";
            button6.Size = new Size(90, 34);
            button6.TabIndex = 2;
            button6.Text = "-";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(654, 260);
            button7.Name = "button7";
            button7.Size = new Size(90, 34);
            button7.TabIndex = 2;
            button7.Text = "취소";
            button7.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 56);
            listView1.Name = "listView1";
            listView1.Size = new Size(348, 236);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button8
            // 
            button8.Location = new Point(12, 12);
            button8.Name = "button8";
            button8.Size = new Size(75, 38);
            button8.TabIndex = 1;
            button8.Text = "뒤로가기";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(669, 12);
            button9.Name = "button9";
            button9.Size = new Size(75, 38);
            button9.TabIndex = 1;
            button9.Text = "결제";
            button9.UseVisualStyleBackColor = true;
            // 
            // FrmOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 304);
            Controls.Add(listView1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button9);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button8);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "FrmOrder";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private ListView listView1;
        private Button button8;
        private Button button9;
    }
}