namespace chattingApp
{
    partial class MemProf
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
            tbxMemDept = new TextBox();
            tbxMemPos = new TextBox();
            tbxMemId = new TextBox();
            tbxMemEmail = new TextBox();
            tbxMemName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tbxMemDept
            // 
            tbxMemDept.Location = new Point(287, 588);
            tbxMemDept.Margin = new Padding(3, 4, 3, 4);
            tbxMemDept.Name = "tbxMemDept";
            tbxMemDept.ReadOnly = true;
            tbxMemDept.Size = new Size(148, 27);
            tbxMemDept.TabIndex = 25;
            // 
            // tbxMemPos
            // 
            tbxMemPos.Location = new Point(287, 516);
            tbxMemPos.Margin = new Padding(3, 4, 3, 4);
            tbxMemPos.Name = "tbxMemPos";
            tbxMemPos.ReadOnly = true;
            tbxMemPos.Size = new Size(148, 27);
            tbxMemPos.TabIndex = 24;
            // 
            // tbxMemId
            // 
            tbxMemId.Location = new Point(287, 448);
            tbxMemId.Margin = new Padding(3, 4, 3, 4);
            tbxMemId.Name = "tbxMemId";
            tbxMemId.ReadOnly = true;
            tbxMemId.Size = new Size(148, 27);
            tbxMemId.TabIndex = 22;
            // 
            // tbxMemEmail
            // 
            tbxMemEmail.Location = new Point(287, 371);
            tbxMemEmail.Margin = new Padding(3, 4, 3, 4);
            tbxMemEmail.Name = "tbxMemEmail";
            tbxMemEmail.ReadOnly = true;
            tbxMemEmail.Size = new Size(148, 27);
            tbxMemEmail.TabIndex = 21;
            // 
            // tbxMemName
            // 
            tbxMemName.Location = new Point(287, 303);
            tbxMemName.Margin = new Padding(3, 4, 3, 4);
            tbxMemName.Name = "tbxMemName";
            tbxMemName.ReadOnly = true;
            tbxMemName.Size = new Size(148, 27);
            tbxMemName.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(158, 591);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 19;
            label7.Text = "부서";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("굴림", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(36, 40);
            label6.Name = "label6";
            label6.Size = new Size(117, 34);
            label6.TabIndex = 18;
            label6.Text = "프로필";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(158, 519);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 17;
            label4.Text = "직책";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 452);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 15;
            label3.Text = "아이디";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(158, 375);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 14;
            label2.Text = "이메일";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 307);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 13;
            label1.Text = "이름";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_;
            pictureBox1.Location = new Point(348, 856);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(272, 123);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // MemProf
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 991);
            Controls.Add(pictureBox1);
            Controls.Add(tbxMemDept);
            Controls.Add(tbxMemPos);
            Controls.Add(tbxMemId);
            Controls.Add(tbxMemEmail);
            Controls.Add(tbxMemName);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MemProf";
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "프로필";
            Load += MemProf_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxMemDept;
        private TextBox tbxMemPos;
        private TextBox tbxMemId;
        private TextBox tbxMemEmail;
        private TextBox tbxMemName;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
    }
}