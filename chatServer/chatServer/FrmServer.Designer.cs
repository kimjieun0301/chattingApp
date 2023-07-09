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
            this.BtnListen = new System.Windows.Forms.Button();
            this.LvChkServer = new System.Windows.Forms.ListBox();
            this.Txtcount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnListen
            // 
            this.BtnListen.Location = new System.Drawing.Point(12, 12);
            this.BtnListen.Name = "BtnListen";
            this.BtnListen.Size = new System.Drawing.Size(127, 57);
            this.BtnListen.TabIndex = 0;
            this.BtnListen.Text = "연결";
            this.BtnListen.UseVisualStyleBackColor = true;
            this.BtnListen.Click += new System.EventHandler(this.BtnListen_Click);
            // 
            // LvChkServer
            // 
            this.LvChkServer.FormattingEnabled = true;
            this.LvChkServer.ItemHeight = 15;
            this.LvChkServer.Location = new System.Drawing.Point(169, 12);
            this.LvChkServer.Name = "LvChkServer";
            this.LvChkServer.Size = new System.Drawing.Size(324, 499);
            this.LvChkServer.TabIndex = 1;
            // 
            // Txtcount
            // 
            this.Txtcount.AutoSize = true;
            this.Txtcount.Location = new System.Drawing.Point(13, 83);
            this.Txtcount.Name = "Txtcount";
            this.Txtcount.Size = new System.Drawing.Size(44, 15);
            this.Txtcount.TabIndex = 2;
            this.Txtcount.Text = "count";
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.Txtcount);
            this.Controls.Add(this.LvChkServer);
            this.Controls.Add(this.BtnListen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmServer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "서버";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnListen;
        private System.Windows.Forms.ListBox LvChkServer;
        private System.Windows.Forms.Label Txtcount;
    }
}

