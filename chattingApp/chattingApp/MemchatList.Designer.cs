namespace chattingApp
{
    partial class MemchatList
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
            BtnMemList = new Button();
            BtnChtRmList = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            memchatListview = new ListView();
            BtnMkChat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("굴림", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 32);
            label1.Name = "label1";
            label1.Size = new Size(83, 34);
            label1.TabIndex = 1;
            label1.Text = "친구";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(260, 37);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 2;
            // 
            // BtnMemList
            // 
            BtnMemList.Location = new Point(39, 137);
            BtnMemList.Margin = new Padding(3, 4, 3, 4);
            BtnMemList.Name = "BtnMemList";
            BtnMemList.Size = new Size(102, 31);
            BtnMemList.TabIndex = 3;
            BtnMemList.Text = "친구목록";
            BtnMemList.UseVisualStyleBackColor = true;
            BtnMemList.Click += BtnMemList_Click;
            // 
            // BtnChtRmList
            // 
            BtnChtRmList.Location = new Point(37, 232);
            BtnChtRmList.Margin = new Padding(3, 4, 3, 4);
            BtnChtRmList.Name = "BtnChtRmList";
            BtnChtRmList.Size = new Size(105, 31);
            BtnChtRmList.TabIndex = 4;
            BtnChtRmList.Text = "채팅방목록";
            BtnChtRmList.UseVisualStyleBackColor = true;
            BtnChtRmList.Click += BtnChtRmList_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(37, 329);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(105, 31);
            button3.TabIndex = 5;
            button3.Text = "내 프로필";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(534, 51);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(84, 31);
            button4.TabIndex = 6;
            button4.Text = "검색";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(298, 51);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 27);
            textBox1.TabIndex = 7;
            // 
            // memchatListview
            // 
            memchatListview.Location = new Point(186, 89);
            memchatListview.Margin = new Padding(3, 4, 3, 4);
            memchatListview.Name = "memchatListview";
            memchatListview.Size = new Size(433, 884);
            memchatListview.TabIndex = 8;
            memchatListview.UseCompatibleStateImageBehavior = false;
            memchatListview.View = View.Details;
            memchatListview.MouseClick += memchatListview_MouseClick;
            // 
            // BtnMkChat
            // 
            BtnMkChat.Location = new Point(26, 427);
            BtnMkChat.Margin = new Padding(3, 4, 3, 4);
            BtnMkChat.Name = "BtnMkChat";
            BtnMkChat.Size = new Size(125, 71);
            BtnMkChat.TabIndex = 9;
            BtnMkChat.Text = "채팅방 만들기";
            BtnMkChat.UseVisualStyleBackColor = true;
            BtnMkChat.Click += BtnMkChat_Click;
            // 
            // MemchatList
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 991);
            Controls.Add(BtnMkChat);
            Controls.Add(memchatListview);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(BtnChtRmList);
            Controls.Add(BtnMemList);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MemchatList";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chatting";
            Load += MemchatList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Button BtnMemList;
        private Button BtnChtRmList;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private ListView memchatListview;
        private Button BtnMkChat;
    }
}