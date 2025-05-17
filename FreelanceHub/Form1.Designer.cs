namespace FreelanceHub
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            texttBoxEmail = new TextBox();
            texttBoxPassword = new TextBox();
            checkBox1 = new CheckBox();
            btnSing_up = new Button();
            btnSign_in = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // texttBoxEmail
            // 
            texttBoxEmail.Location = new Point(14, 59);
            texttBoxEmail.Margin = new Padding(3, 4, 3, 4);
            texttBoxEmail.Name = "texttBoxEmail";
            texttBoxEmail.Size = new Size(246, 27);
            texttBoxEmail.TabIndex = 0;
            // 
            // texttBoxPassword
            // 
            texttBoxPassword.Location = new Point(279, 59);
            texttBoxPassword.Margin = new Padding(3, 4, 3, 4);
            texttBoxPassword.Name = "texttBoxPassword";
            texttBoxPassword.PasswordChar = '⚫';
            texttBoxPassword.Size = new Size(246, 27);
            texttBoxPassword.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(545, 61);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(95, 24);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Показать";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btnSing_up
            // 
            btnSing_up.Location = new Point(279, 500);
            btnSing_up.Margin = new Padding(3, 4, 3, 4);
            btnSing_up.Name = "btnSing_up";
            btnSing_up.Size = new Size(247, 31);
            btnSing_up.TabIndex = 3;
            btnSing_up.Text = "Sign up";
            btnSing_up.UseVisualStyleBackColor = true;
            btnSing_up.Click += btnSing_up_Click;
            // 
            // btnSign_in
            // 
            btnSign_in.Location = new Point(14, 500);
            btnSign_in.Margin = new Padding(3, 4, 3, 4);
            btnSign_in.Name = "btnSign_in";
            btnSign_in.Size = new Size(247, 31);
            btnSign_in.TabIndex = 4;
            btnSign_in.Text = "Sign in";
            btnSign_in.UseVisualStyleBackColor = true;
            btnSign_in.Click += btnSign_in_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 19);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 5;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(279, 19);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSign_in);
            Controls.Add(btnSing_up);
            Controls.Add(checkBox1);
            Controls.Add(texttBoxPassword);
            Controls.Add(texttBoxEmail);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox texttBoxEmail;
        private TextBox texttBoxPassword;
        private CheckBox checkBox1;
        private Button btnSing_up;
        private Button btnSign_in;
        private Label label1;
        private Label label2;
    }
}
