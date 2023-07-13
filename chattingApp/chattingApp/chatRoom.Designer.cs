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
            BtnChtOut = new Button();
            BtnSendMsg = new Button();
            BtnSendPic = new Button();
            TxtMessage = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            BtnPicSend = new Button();
            chtmemList = new ListBox();
            ChatNm = new Label();
            MsgList = new ListBox();
            SuspendLayout();
            // 
            // BtnChtOut
            // 
            BtnChtOut.Enabled = false;
            BtnChtOut.Font = new Font("굴림", 15F, FontStyle.Regular, GraphicsUnit.Point);
            BtnChtOut.Location = new Point(425, 63);
            BtnChtOut.Margin = new Padding(3, 4, 3, 4);
            BtnChtOut.Name = "BtnChtOut";
            BtnChtOut.Size = new Size(84, 51);
            BtnChtOut.TabIndex = 2;
            BtnChtOut.Text = "→]";
            BtnChtOut.UseVisualStyleBackColor = true;
            // 
            // BtnSendMsg
            // 
            BtnSendMsg.Enabled = false;
            BtnSendMsg.Location = new Point(367, 844);
            BtnSendMsg.Margin = new Padding(3, 4, 3, 4);
            BtnSendMsg.Name = "BtnSendMsg";
            BtnSendMsg.Size = new Size(141, 68);
            BtnSendMsg.TabIndex = 3;
            BtnSendMsg.Text = "전송";
            BtnSendMsg.UseVisualStyleBackColor = true;
            BtnSendMsg.Click += BtnSendMsg_Click;
            // 
            // BtnSendPic
            // 
            BtnSendPic.Location = new Point(14, 844);
            BtnSendPic.Margin = new Padding(3, 4, 3, 4);
            BtnSendPic.Name = "BtnSendPic";
            BtnSendPic.Size = new Size(71, 68);
            BtnSendPic.TabIndex = 4;
            BtnSendPic.Text = "사진";
            BtnSendPic.UseVisualStyleBackColor = true;
            BtnSendPic.Click += BtnSendPic_Click;
            // 
            // TxtMessage
            // 
            TxtMessage.Location = new Point(14, 672);
            TxtMessage.Margin = new Padding(3, 4, 3, 4);
            TxtMessage.Multiline = true;
            TxtMessage.Name = "TxtMessage";
            TxtMessage.Size = new Size(493, 163);
            TxtMessage.TabIndex = 7;
            TxtMessage.TextChanged += TxtMessage_TextChanged;
            TxtMessage.KeyDown += TxtMessage_KeyDown;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtnPicSend
            // 
            BtnPicSend.Enabled = false;
            BtnPicSend.Location = new Point(91, 844);
            BtnPicSend.Margin = new Padding(3, 4, 3, 4);
            BtnPicSend.Name = "BtnPicSend";
            BtnPicSend.Size = new Size(100, 68);
            BtnPicSend.TabIndex = 8;
            BtnPicSend.Text = "사진보내기";
            BtnPicSend.UseVisualStyleBackColor = true;
            // 
            // chtmemList
            // 
            chtmemList.FormattingEnabled = true;
            chtmemList.ItemHeight = 20;
            chtmemList.Location = new Point(16, 63);
            chtmemList.Name = "chtmemList";
            chtmemList.Size = new Size(403, 144);
            chtmemList.TabIndex = 9;
            // 
            // ChatNm
            // 
            ChatNm.AutoSize = true;
            ChatNm.Font = new Font("맑은 고딕", 13F, FontStyle.Regular, GraphicsUnit.Point);
            ChatNm.Location = new Point(16, 14);
            ChatNm.Name = "ChatNm";
            ChatNm.Size = new Size(118, 30);
            ChatNm.TabIndex = 10;
            ChatNm.Text = "chat name";
            // 
            // MsgList
            // 
            MsgList.FormattingEnabled = true;
            MsgList.ItemHeight = 20;
            MsgList.Location = new Point(16, 233);
            MsgList.Name = "MsgList";
            MsgList.Size = new Size(491, 424);
            MsgList.TabIndex = 11;
            // 
            // chatRoom
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 917);
            Controls.Add(MsgList);
            Controls.Add(ChatNm);
            Controls.Add(chtmemList);
            Controls.Add(BtnPicSend);
            Controls.Add(TxtMessage);
            Controls.Add(BtnSendPic);
            Controls.Add(BtnSendMsg);
            Controls.Add(BtnChtOut);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "chatRoom";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "채팅방";
            Load += chatRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnChtOut;
        private Button BtnSendMsg;
        private Button BtnSendPic;
        private TextBox TxtMessage;
        private OpenFileDialog openFileDialog1;
        private Button BtnPicSend;
        private ListBox chtmemList;
        private Label ChatNm;
        private ListBox MsgList;
    }
}