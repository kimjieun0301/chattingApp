namespace chattingApp
{
    partial class chatRoom
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
            this.MsgList = new System.Windows.Forms.ListView();
            this.ChatMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChatMemNm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.BtnSendMsg = new System.Windows.Forms.Button();
            this.BtnSendPic = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MsgList
            // 
            this.MsgList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChatMsg,
            this.ChatMemNm});
            this.MsgList.HideSelection = false;
            this.MsgList.Location = new System.Drawing.Point(12, 49);
            this.MsgList.Name = "MsgList";
            this.MsgList.Size = new System.Drawing.Size(439, 449);
            this.MsgList.TabIndex = 0;
            this.MsgList.UseCompatibleStateImageBehavior = false;
            this.MsgList.View = System.Windows.Forms.View.Tile;
            // 
            // ChatMsg
            // 
            this.ChatMsg.Text = "대화";
            this.ChatMsg.Width = 250;
            // 
            // ChatMemNm
            // 
            this.ChatMemNm.Text = "이름";
            this.ChatMemNm.Width = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 15F);
            this.button1.Location = new System.Drawing.Point(376, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "→]";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnSendMsg
            // 
            this.BtnSendMsg.Location = new System.Drawing.Point(326, 633);
            this.BtnSendMsg.Name = "BtnSendMsg";
            this.BtnSendMsg.Size = new System.Drawing.Size(125, 51);
            this.BtnSendMsg.TabIndex = 3;
            this.BtnSendMsg.Text = "전송";
            this.BtnSendMsg.UseVisualStyleBackColor = true;
            this.BtnSendMsg.Click += new System.EventHandler(this.BtnSendMsg_Click);
            // 
            // BtnSendPic
            // 
            this.BtnSendPic.Location = new System.Drawing.Point(12, 633);
            this.BtnSendPic.Name = "BtnSendPic";
            this.BtnSendPic.Size = new System.Drawing.Size(63, 51);
            this.BtnSendPic.TabIndex = 4;
            this.BtnSendPic.Text = "사진";
            this.BtnSendPic.UseVisualStyleBackColor = true;
            this.BtnSendPic.Click += new System.EventHandler(this.BtnSendPic_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(295, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 38);
            this.button4.TabIndex = 5;
            this.button4.Text = "참여목록";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("굴림", 15F);
            this.button5.Location = new System.Drawing.Point(214, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 38);
            this.button5.TabIndex = 6;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(12, 504);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(439, 123);
            this.TxtMessage.TabIndex = 7;
            this.TxtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_KeyDown);
            // 
            // chatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 688);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.BtnSendPic);
            this.Controls.Add(this.BtnSendMsg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MsgList);
            this.Name = "chatRoom";
            this.Text = "채팅방";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MsgList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnSendMsg;
        private System.Windows.Forms.Button BtnSendPic;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.ColumnHeader ChatMemNm;
        private System.Windows.Forms.ColumnHeader ChatMsg;
    }
}