namespace chattingApp
{
    partial class MemberJoin
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            btnJoin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 211);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 0;
            label1.Text = "이름";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(159, 279);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "이메일";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(159, 356);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 2;
            label3.Text = "아이디";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(159, 520);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 4;
            label4.Text = "직책";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(159, 443);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 3;
            label5.Text = "비밀번호";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("굴림", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(35, 33);
            label6.Name = "label6";
            label6.Size = new Size(151, 34);
            label6.TabIndex = 5;
            label6.Text = "회원가입";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(159, 592);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 6;
            label7.Text = "부서";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(288, 207);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 27);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(288, 275);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(148, 27);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(288, 352);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(148, 27);
            textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(288, 439);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(148, 27);
            textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(288, 516);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(148, 27);
            textBox5.TabIndex = 11;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(288, 588);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(148, 27);
            textBox6.TabIndex = 12;
            // 
            // btnJoin
            // 
            btnJoin.Location = new Point(288, 731);
            btnJoin.Margin = new Padding(3, 4, 3, 4);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(84, 31);
            btnJoin.TabIndex = 13;
            btnJoin.Text = "가입";
            btnJoin.UseVisualStyleBackColor = true;
            btnJoin.Click += btnJoin_Click;
            // 
            // MemberJoin
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 991);
            Controls.Add(btnJoin);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MemberJoin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "회원가입";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button btnJoin;
    }
}