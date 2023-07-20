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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            BtnMemList = new Button();
            BtnChtRmList = new Button();
            BtnMyProf = new Button();
            BtnSearch = new Button();
            tbxSearch = new TextBox();
            memchatListview = new ListView();
            BtnMkChat = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            lbSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.Font = new Font("굴림", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(26, 25);
            label1.Name = "label1";
            label1.Size = new Size(228, 88);
            label1.TabIndex = 1;
            label1.Text = "시간";
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
            // BtnMyProf
            // 
            BtnMyProf.Location = new Point(37, 329);
            BtnMyProf.Margin = new Padding(3, 4, 3, 4);
            BtnMyProf.Name = "BtnMyProf";
            BtnMyProf.Size = new Size(105, 31);
            BtnMyProf.TabIndex = 5;
            BtnMyProf.Text = "내 프로필";
            BtnMyProf.UseVisualStyleBackColor = true;
            BtnMyProf.Click += BtnMyProf_Click;
            // 
            // BtnSearch
            // 
            BtnSearch.Location = new Point(536, 84);
            BtnSearch.Margin = new Padding(3, 4, 3, 4);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(84, 31);
            BtnSearch.TabIndex = 6;
            BtnSearch.Text = "검색";
            BtnSearch.UseVisualStyleBackColor = true;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // tbxSearch
            // 
            tbxSearch.Location = new Point(299, 86);
            tbxSearch.Margin = new Padding(3, 4, 3, 4);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(230, 27);
            tbxSearch.TabIndex = 7;
            // 
            // memchatListview
            // 
            memchatListview.Location = new Point(186, 121);
            memchatListview.Margin = new Padding(3, 4, 3, 4);
            memchatListview.Name = "memchatListview";
            memchatListview.Size = new Size(433, 852);
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
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_;
            pictureBox1.Location = new Point(9, 875);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Location = new Point(193, 89);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(52, 20);
            lbSearch.TabIndex = 11;
            lbSearch.Text = "serach";
            // 
            // MemchatList
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 991);
            Controls.Add(lbSearch);
            Controls.Add(pictureBox1);
            Controls.Add(BtnMkChat);
            Controls.Add(memchatListview);
            Controls.Add(tbxSearch);
            Controls.Add(BtnSearch);
            Controls.Add(BtnMyProf);
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
            Text = "목록";
            FormClosing += MemchatList_FormClosing;
            Load += MemchatList_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Button BtnMemList;
        private Button BtnChtRmList;
        private Button BtnMyProf;
        private Button BtnSearch;
        private TextBox tbxSearch;
        private ListView memchatListview;
        private Button BtnMkChat;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private Label lbSearch;
    }
}