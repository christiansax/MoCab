namespace PlexByte.MoCap.WinForms.UserControls
{
    partial class uc_User
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_Birthdate = new System.Windows.Forms.DateTimePicker();
            this.tbx_Password = new System.Windows.Forms.MaskedTextBox();
            this.dtp_Modified = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_Created = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_Email = new System.Windows.Forms.TextBox();
            this.tbx_UserName = new System.Windows.Forms.TextBox();
            this.tbx_LastName = new System.Windows.Forms.TextBox();
            this.tbx_FirstName = new System.Windows.Forms.TextBox();
            this.tbx_MiddleName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtp_Birthdate);
            this.groupBox1.Controls.Add(this.tbx_Password);
            this.groupBox1.Controls.Add(this.dtp_Modified);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtp_Created);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbx_Email);
            this.groupBox1.Controls.Add(this.tbx_UserName);
            this.groupBox1.Controls.Add(this.tbx_LastName);
            this.groupBox1.Controls.Add(this.tbx_FirstName);
            this.groupBox1.Controls.Add(this.tbx_MiddleName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_Id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // dtp_Birthdate
            // 
            this.dtp_Birthdate.CustomFormat = "ddd dd MMM yyyy";
            this.dtp_Birthdate.Enabled = false;
            this.dtp_Birthdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Birthdate.Location = new System.Drawing.Point(358, 97);
            this.dtp_Birthdate.Name = "dtp_Birthdate";
            this.dtp_Birthdate.Size = new System.Drawing.Size(166, 20);
            this.dtp_Birthdate.TabIndex = 8;
            // 
            // tbx_Password
            // 
            this.tbx_Password.Location = new System.Drawing.Point(358, 45);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.PasswordChar = '*';
            this.tbx_Password.Size = new System.Drawing.Size(166, 20);
            this.tbx_Password.TabIndex = 6;
            // 
            // dtp_Modified
            // 
            this.dtp_Modified.CustomFormat = "ddd dd MMM yyyy  HH:mm";
            this.dtp_Modified.Enabled = false;
            this.dtp_Modified.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Modified.Location = new System.Drawing.Point(358, 124);
            this.dtp_Modified.Name = "dtp_Modified";
            this.dtp_Modified.Size = new System.Drawing.Size(166, 20);
            this.dtp_Modified.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Modified:";
            // 
            // dtp_Created
            // 
            this.dtp_Created.CustomFormat = "ddd dd MMM yyyy  HH:mm";
            this.dtp_Created.Enabled = false;
            this.dtp_Created.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Created.Location = new System.Drawing.Point(88, 124);
            this.dtp_Created.Name = "dtp_Created";
            this.dtp_Created.Size = new System.Drawing.Size(166, 20);
            this.dtp_Created.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Created:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "BirthDate:";
            // 
            // tbx_Email
            // 
            this.tbx_Email.Enabled = false;
            this.tbx_Email.Location = new System.Drawing.Point(358, 71);
            this.tbx_Email.Name = "tbx_Email";
            this.tbx_Email.Size = new System.Drawing.Size(166, 20);
            this.tbx_Email.TabIndex = 7;
            // 
            // tbx_UserName
            // 
            this.tbx_UserName.Location = new System.Drawing.Point(358, 19);
            this.tbx_UserName.Name = "tbx_UserName";
            this.tbx_UserName.Size = new System.Drawing.Size(166, 20);
            this.tbx_UserName.TabIndex = 5;
            // 
            // tbx_LastName
            // 
            this.tbx_LastName.Enabled = false;
            this.tbx_LastName.Location = new System.Drawing.Point(88, 97);
            this.tbx_LastName.Name = "tbx_LastName";
            this.tbx_LastName.Size = new System.Drawing.Size(166, 20);
            this.tbx_LastName.TabIndex = 4;
            // 
            // tbx_FirstName
            // 
            this.tbx_FirstName.Enabled = false;
            this.tbx_FirstName.Location = new System.Drawing.Point(88, 45);
            this.tbx_FirstName.Name = "tbx_FirstName";
            this.tbx_FirstName.Size = new System.Drawing.Size(166, 20);
            this.tbx_FirstName.TabIndex = 2;
            // 
            // tbx_MiddleName
            // 
            this.tbx_MiddleName.Enabled = false;
            this.tbx_MiddleName.Location = new System.Drawing.Point(88, 71);
            this.tbx_MiddleName.Name = "tbx_MiddleName";
            this.tbx_MiddleName.Size = new System.Drawing.Size(166, 20);
            this.tbx_MiddleName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Id:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Middle Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // tbx_Id
            // 
            this.tbx_Id.Enabled = false;
            this.tbx_Id.Location = new System.Drawing.Point(88, 19);
            this.tbx_Id.Name = "tbx_Id";
            this.tbx_Id.Size = new System.Drawing.Size(166, 20);
            this.tbx_Id.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(13, 172);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(75, 23);
            this.btn_New.TabIndex = 12;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(453, 172);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 11;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            // 
            // btn_Edit
            // 
            this.btn_Edit.AllowDrop = true;
            this.btn_Edit.Location = new System.Drawing.Point(237, 172);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_Edit.TabIndex = 13;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Visible = false;
            // 
            // uc_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 203);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "uc_User";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_Id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_Created;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_Email;
        private System.Windows.Forms.TextBox tbx_UserName;
        private System.Windows.Forms.TextBox tbx_LastName;
        private System.Windows.Forms.TextBox tbx_FirstName;
        private System.Windows.Forms.TextBox tbx_MiddleName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_Modified;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.MaskedTextBox tbx_Password;
        private System.Windows.Forms.DateTimePicker dtp_Birthdate;
    }
}
