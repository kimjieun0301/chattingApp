namespace chatServer
{
    partial class FrmServer
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
            BtnListen = new Button();
            LvChkServer = new ListBox();
            Txtcount = new Label();
            SuspendLayout();
            // 
            // BtnListen
            // 
            BtnListen.Location = new Point(14, 16);
            BtnListen.Margin = new Padding(3, 4, 3, 4);
            BtnListen.Name = "BtnListen";
            BtnListen.Size = new Size(143, 76);
            BtnListen.TabIndex = 0;
            BtnListen.Text = "연결";
            BtnListen.UseVisualStyleBackColor = true;
            BtnListen.Click += BtnListen_Click;
            // 
            // LvChkServer
            // 
            LvChkServer.FormattingEnabled = true;
            LvChkServer.ItemHeight = 20;
            LvChkServer.Location = new Point(190, 16);
            LvChkServer.Margin = new Padding(3, 4, 3, 4);
            LvChkServer.Name = "LvChkServer";
            LvChkServer.Size = new Size(364, 664);
            LvChkServer.TabIndex = 1;
            // 
            // Txtcount
            // 
            Txtcount.AutoSize = true;
            Txtcount.Location = new Point(15, 111);
            Txtcount.Name = "Txtcount";
            Txtcount.Size = new Size(48, 20);
            Txtcount.TabIndex = 2;
            Txtcount.Text = "count";
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 693);
            Controls.Add(Txtcount);
            Controls.Add(LvChkServer);
            Controls.Add(BtnListen);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmServer";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "서버";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnListen;
        private ListBox LvChkServer;
        private Label Txtcount;
    }
}

