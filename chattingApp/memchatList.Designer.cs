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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.memchatListview = new System.Windows.Forms.ListView();
            this.memId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memPos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memDept = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnMkChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "친구";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "친구목록";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "채팅방목록";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(33, 247);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "내 프로필";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(475, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "검색";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(264, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 25);
            this.textBox1.TabIndex = 7;
            // 
            // memchatListview
            // 
            this.memchatListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.memId,
            this.memName,
            this.memPos,
            this.memDept});
            this.memchatListview.HideSelection = false;
            this.memchatListview.Location = new System.Drawing.Point(165, 67);
            this.memchatListview.Name = "memchatListview";
            this.memchatListview.Size = new System.Drawing.Size(385, 664);
            this.memchatListview.TabIndex = 8;
            this.memchatListview.UseCompatibleStateImageBehavior = false;
            this.memchatListview.View = System.Windows.Forms.View.Details;
            // 
            // memId
            // 
            this.memId.DisplayIndex = 3;
            this.memId.Text = "Id";
            this.memId.Width = 0;
            // 
            // memName
            // 
            this.memName.DisplayIndex = 0;
            this.memName.Text = "이름";
            this.memName.Width = 100;
            // 
            // memPos
            // 
            this.memPos.DisplayIndex = 1;
            this.memPos.Text = "직책";
            this.memPos.Width = 100;
            // 
            // memDept
            // 
            this.memDept.DisplayIndex = 2;
            this.memDept.Text = "부서";
            this.memDept.Width = 100;
            // 
            // BtnMkChat
            // 
            this.BtnMkChat.Location = new System.Drawing.Point(23, 320);
            this.BtnMkChat.Name = "BtnMkChat";
            this.BtnMkChat.Size = new System.Drawing.Size(111, 53);
            this.BtnMkChat.TabIndex = 9;
            this.BtnMkChat.Text = "채팅방 만들기";
            this.BtnMkChat.UseVisualStyleBackColor = true;
            this.BtnMkChat.Click += new System.EventHandler(this.BtnMkChat_Click);
            // 
            // MemchatList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 743);
            this.Controls.Add(this.BtnMkChat);
            this.Controls.Add(this.memchatListview);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MemchatList";
            this.Text = "Chatting";
            this.Load += new System.EventHandler(this.MemchatList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView memchatListview;
        private System.Windows.Forms.ColumnHeader memName;
        private System.Windows.Forms.ColumnHeader memPos;
        private System.Windows.Forms.ColumnHeader memDept;
        private System.Windows.Forms.ColumnHeader memId;
        private System.Windows.Forms.Button BtnMkChat;
    }
}