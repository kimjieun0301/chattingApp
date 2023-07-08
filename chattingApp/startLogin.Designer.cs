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
            this.BtnLogin = new System.Windows.Forms.Button();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.TxtPwd = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.BtnJoin = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(237, 464);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "로그인";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(237, 282);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(144, 25);
            this.TxtId.TabIndex = 1;
            this.TxtId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtId_KeyDown);
            // 
            // TxtPwd
            // 
            this.TxtPwd.Location = new System.Drawing.Point(237, 330);
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.Size = new System.Drawing.Size(144, 25);
            this.TxtPwd.TabIndex = 2;
            this.TxtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPwd_KeyDown);
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Location = new System.Drawing.Point(154, 285);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(20, 15);
            this.Id.TabIndex = 3;
            this.Id.Text = "ID";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(154, 333);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(72, 15);
            this.Password.TabIndex = 4;
            this.Password.Text = "Password";
            // 
            // BtnJoin
            // 
            this.BtnJoin.AutoSize = true;
            this.BtnJoin.Location = new System.Drawing.Point(241, 416);
            this.BtnJoin.Name = "BtnJoin";
            this.BtnJoin.Size = new System.Drawing.Size(67, 15);
            this.BtnJoin.TabIndex = 5;
            this.BtnJoin.TabStop = true;
            this.BtnJoin.Text = "회원가입";
            this.BtnJoin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnJoin_LinkClicked);
            // 
            // StartLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 743);
            this.Controls.Add(this.BtnJoin);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.BtnLogin);
            this.Name = "StartLogin";
            this.Text = "로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.TextBox TxtPwd;
        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.LinkLabel BtnJoin;
    }
}

