namespace ToyProject
{
    partial class FrmLogin
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
            label1 = new Label();
            label2 = new Label();
            TxtUserId = new TextBox();
            TxtPassword = new TextBox();
            BtnLogin = new Button();
            BtnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 38);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "아이디";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 72);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "P/W";
            // 
            // TxtUserId
            // 
            TxtUserId.Location = new Point(86, 34);
            TxtUserId.Name = "TxtUserId";
            TxtUserId.Size = new Size(100, 23);
            TxtUserId.TabIndex = 2;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(86, 69);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.Size = new Size(100, 23);
            TxtPassword.TabIndex = 3;
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(34, 109);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(75, 23);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "로그인";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(111, 109);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(75, 23);
            BtnCancel.TabIndex = 5;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(220, 167);
            ControlBox = false;
            Controls.Add(BtnCancel);
            Controls.Add(BtnLogin);
            Controls.Add(TxtPassword);
            Controls.Add(TxtUserId);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmLogin";
            Text = "로그인";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TxtUserId;
        private TextBox TxtPassword;
        private Button BtnLogin;
        private Button BtnCancel;
    }
}