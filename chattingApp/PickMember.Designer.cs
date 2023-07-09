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
            this.PickMemList = new System.Windows.Forms.ListView();
            this.cck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memPos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memDept = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MakechatRm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.memID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // PickMemList
            // 
            this.PickMemList.CheckBoxes = true;
            this.PickMemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cck,
            this.memName,
            this.memPos,
            this.memDept,
            this.memID});
            this.PickMemList.HideSelection = false;
            this.PickMemList.Location = new System.Drawing.Point(12, 87);
            this.PickMemList.Name = "PickMemList";
            this.PickMemList.OwnerDraw = true;
            this.PickMemList.Size = new System.Drawing.Size(439, 589);
            this.PickMemList.TabIndex = 0;
            this.PickMemList.UseCompatibleStateImageBehavior = false;
            this.PickMemList.View = System.Windows.Forms.View.Details;
            this.PickMemList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.PickMemList_ColumnClick);
            this.PickMemList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.PickMemList_DrawColumnHeader);
            this.PickMemList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.PickMemList_DrawItem);
            this.PickMemList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.PickMemList_DrawSubItem);
            // 
            // cck
            // 
            this.cck.Text = "";
            this.cck.Width = 30;
            // 
            // memName
            // 
            this.memName.Text = "이름";
            this.memName.Width = 120;
            // 
            // memPos
            // 
            this.memPos.Text = "직책";
            this.memPos.Width = 120;
            // 
            // memDept
            // 
            this.memDept.Text = "부서";
            this.memDept.Width = 120;
            // 
            // MakechatRm
            // 
            this.MakechatRm.Location = new System.Drawing.Point(362, 12);
            this.MakechatRm.Name = "MakechatRm";
            this.MakechatRm.Size = new System.Drawing.Size(89, 37);
            this.MakechatRm.TabIndex = 1;
            this.MakechatRm.Text = "채팅생성";
            this.MakechatRm.UseVisualStyleBackColor = true;
            this.MakechatRm.Click += new System.EventHandler(this.MakechatRm_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(362, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "검색";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 25);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "대화 상대 초대하기";
            // 
            // memID
            // 
            this.memID.Text = "ID";
            this.memID.Width = 0;
            // 
            // PickMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 688);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MakechatRm);
            this.Controls.Add(this.PickMemList);
            this.Name = "PickMember";
            this.Text = "PickMember";
            this.Load += new System.EventHandler(this.PickMember_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView PickMemList;
        private System.Windows.Forms.Button MakechatRm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader memName;
        private System.Windows.Forms.ColumnHeader memPos;
        private System.Windows.Forms.ColumnHeader memDept;
        private System.Windows.Forms.ColumnHeader cck;
        private System.Windows.Forms.ColumnHeader memID;
    }
}