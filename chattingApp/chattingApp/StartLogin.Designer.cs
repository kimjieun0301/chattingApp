namespace chattingApp
{
    partial class StartLogin
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            BtnLogin = new Button();
            TxtId = new TextBox();
            TxtPwd = new TextBox();
            Id = new Label();
            Password = new Label();
            BtnJoin = new LinkLabel();
            SuspendLayout();
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(267, 619);
            BtnLogin.Margin = new Padding(3, 4, 3, 4);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(84, 31);
            BtnLogin.TabIndex = 0;
            BtnLogin.Text = "로그인";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // TxtId
            // 
            TxtId.Location = new Point(267, 376);
            TxtId.Margin = new Padding(3, 4, 3, 4);
            TxtId.Name = "TxtId";
            TxtId.Size = new Size(162, 27);
            TxtId.TabIndex = 1;
            TxtId.KeyDown += TxtId_KeyDown;
            // 
            // TxtPwd
            // 
            TxtPwd.Location = new Point(267, 440);
            TxtPwd.Margin = new Padding(3, 4, 3, 4);
            TxtPwd.Name = "TxtPwd";
            TxtPwd.Size = new Size(162, 27);
            TxtPwd.TabIndex = 2;
            TxtPwd.KeyDown += TxtPwd_KeyDown;
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Location = new Point(173, 380);
            Id.Name = "Id";
            Id.Size = new Size(24, 20);
            Id.TabIndex = 3;
            Id.Text = "ID";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(173, 444);
            Password.Name = "Password";
            Password.Size = new Size(72, 20);
            Password.TabIndex = 4;
            Password.Text = "Password";
            // 
            // BtnJoin
            // 
            BtnJoin.AutoSize = true;
            BtnJoin.Enabled = false;
            BtnJoin.Location = new Point(271, 555);
            BtnJoin.Name = "BtnJoin";
            BtnJoin.Size = new Size(69, 20);
            BtnJoin.TabIndex = 5;
            BtnJoin.TabStop = true;
            BtnJoin.Text = "회원가입";
            BtnJoin.LinkClicked += BtnJoin_LinkClicked;
            // 
            // StartLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 991);
            Controls.Add(BtnJoin);
            Controls.Add(Password);
            Controls.Add(Id);
            Controls.Add(TxtPwd);
            Controls.Add(TxtId);
            Controls.Add(BtnLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StartLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "로그인";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnLogin;
        private TextBox TxtId;
        private TextBox TxtPwd;
        private Label Id;
        private Label Password;
        private LinkLabel BtnJoin;
    }
}

