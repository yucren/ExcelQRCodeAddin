namespace ExcelQRCodeAddin.Tools
{
    partial class DbConnForm
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
            this.ServiceAddTb = new System.Windows.Forms.TextBox();
            this.DbCbox = new System.Windows.Forms.ComboBox();
            this.UidTB = new System.Windows.Forms.TextBox();
            this.PwdTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.用户名 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TestBtn = new System.Windows.Forms.Button();
            this.ComfirmBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServiceAddTb
            // 
            this.ServiceAddTb.Location = new System.Drawing.Point(126, 39);
            this.ServiceAddTb.Name = "ServiceAddTb";
            this.ServiceAddTb.Size = new System.Drawing.Size(121, 21);
            this.ServiceAddTb.TabIndex = 0;
            // 
            // DbCbox
            // 
            this.DbCbox.FormattingEnabled = true;
            this.DbCbox.Location = new System.Drawing.Point(126, 162);
            this.DbCbox.Name = "DbCbox";
            this.DbCbox.Size = new System.Drawing.Size(121, 20);
            this.DbCbox.TabIndex = 1;
            // 
            // UidTB
            // 
            this.UidTB.Location = new System.Drawing.Point(126, 85);
            this.UidTB.Name = "UidTB";
            this.UidTB.Size = new System.Drawing.Size(121, 21);
            this.UidTB.TabIndex = 2;
            // 
            // PwdTb
            // 
            this.PwdTb.Location = new System.Drawing.Point(126, 126);
            this.PwdTb.Name = "PwdTb";
            this.PwdTb.PasswordChar = '*';
            this.PwdTb.Size = new System.Drawing.Size(121, 21);
            this.PwdTb.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "服务器地址";
            // 
            // 用户名
            // 
            this.用户名.AutoSize = true;
            this.用户名.Location = new System.Drawing.Point(55, 88);
            this.用户名.Name = "用户名";
            this.用户名.Size = new System.Drawing.Size(41, 12);
            this.用户名.TabIndex = 4;
            this.用户名.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "数据库";
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(146, 200);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(75, 23);
            this.TestBtn.TabIndex = 5;
            this.TestBtn.Text = "测试连接";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // ComfirmBtn
            // 
            this.ComfirmBtn.Location = new System.Drawing.Point(146, 229);
            this.ComfirmBtn.Name = "ComfirmBtn";
            this.ComfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ComfirmBtn.TabIndex = 6;
            this.ComfirmBtn.Text = "确认";
            this.ComfirmBtn.UseVisualStyleBackColor = true;
            // 
            // DbConnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 278);
            this.Controls.Add(this.ComfirmBtn);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.用户名);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PwdTb);
            this.Controls.Add(this.UidTB);
            this.Controls.Add(this.DbCbox);
            this.Controls.Add(this.ServiceAddTb);
            this.Name = "DbConnForm";
            this.Text = "DbConnForm";
            this.Load += new System.EventHandler(this.DbConnForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServiceAddTb;
        private System.Windows.Forms.ComboBox DbCbox;
        private System.Windows.Forms.TextBox UidTB;
        private System.Windows.Forms.TextBox PwdTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 用户名;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.Button ComfirmBtn;
    }
}