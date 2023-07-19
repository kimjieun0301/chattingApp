namespace chattingApp
{
    partial class PickMember
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
            PickMemList = new ListView();
            cck = new ColumnHeader();
            memName = new ColumnHeader();
            memPos = new ColumnHeader();
            memDept = new ColumnHeader();
            memID = new ColumnHeader();
            MakechatRm = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            TxtChtNm = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // PickMemList
            // 
            PickMemList.CheckBoxes = true;
            PickMemList.Columns.AddRange(new ColumnHeader[] { cck, memName, memPos, memDept, memID });
            PickMemList.Location = new Point(14, 181);
            PickMemList.Margin = new Padding(3, 4, 3, 4);
            PickMemList.Name = "PickMemList";
            PickMemList.OwnerDraw = true;
            PickMemList.Size = new Size(493, 719);
            PickMemList.TabIndex = 0;
            PickMemList.UseCompatibleStateImageBehavior = false;
            PickMemList.View = View.Details;
            PickMemList.ColumnClick += PickMemList_ColumnClick;
            PickMemList.DrawColumnHeader += PickMemList_DrawColumnHeader;
            PickMemList.DrawItem += PickMemList_DrawItem;
            PickMemList.DrawSubItem += PickMemList_DrawSubItem;
            // 
            // cck
            // 
            cck.Text = "";
            cck.Width = 30;
            // 
            // memName
            // 
            memName.Text = "이름";
            memName.Width = 120;
            // 
            // memPos
            // 
            memPos.Text = "직책";
            memPos.Width = 120;
            // 
            // memDept
            // 
            memDept.Text = "부서";
            memDept.Width = 120;
            // 
            // memID
            // 
            memID.Text = "ID";
            memID.Width = 0;
            // 
            // MakechatRm
            // 
            MakechatRm.Location = new Point(407, 106);
            MakechatRm.Margin = new Padding(3, 4, 3, 4);
            MakechatRm.Name = "MakechatRm";
            MakechatRm.Size = new Size(100, 31);
            MakechatRm.TabIndex = 1;
            MakechatRm.Text = "채팅생성";
            MakechatRm.UseVisualStyleBackColor = true;
            MakechatRm.Click += MakechatRm_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(407, 142);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(100, 31);
            button2.TabIndex = 2;
            button2.Text = "검색";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(15, 142);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(386, 27);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("굴림", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 28);
            label1.Name = "label1";
            label1.Size = new Size(228, 25);
            label1.TabIndex = 4;
            label1.Text = "대화 상대 초대하기";
            // 
            // TxtChtNm
            // 
            TxtChtNm.Location = new Point(231, 108);
            TxtChtNm.Margin = new Padding(3, 4, 3, 4);
            TxtChtNm.Name = "TxtChtNm";
            TxtChtNm.Size = new Size(170, 27);
            TxtChtNm.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("굴림", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(128, 114);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 6;
            label2.Text = "채팅방 이름 :";
            // 
            // PickMember
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 917);
            Controls.Add(label2);
            Controls.Add(TxtChtNm);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(MakechatRm);
            Controls.Add(PickMemList);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PickMember";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "PickMember";
            Load += PickMember_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView PickMemList;
        private Button MakechatRm;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private ColumnHeader memName;
        private ColumnHeader memPos;
        private ColumnHeader memDept;
        private ColumnHeader cck;
        private ColumnHeader memID;
        private TextBox TxtChtNm;
        private Label label2;
    }
}