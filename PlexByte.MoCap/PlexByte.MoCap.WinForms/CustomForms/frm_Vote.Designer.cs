namespace PlexByte.MoCap.WinForms.CustomForms
{
    partial class frm_Vote
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Options = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Survey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_User = new System.Windows.Forms.TextBox();
            this.btn_Vote = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_Vote);
            this.groupBox1.Controls.Add(this.tbx_User);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbx_Survey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbx_Options);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Option:";
            // 
            // cbx_Options
            // 
            this.cbx_Options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Options.FormattingEnabled = true;
            this.cbx_Options.Location = new System.Drawing.Point(87, 20);
            this.cbx_Options.Name = "cbx_Options";
            this.cbx_Options.Size = new System.Drawing.Size(214, 21);
            this.cbx_Options.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Survey:";
            // 
            // tbx_Survey
            // 
            this.tbx_Survey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Survey.Location = new System.Drawing.Point(87, 48);
            this.tbx_Survey.Name = "tbx_Survey";
            this.tbx_Survey.Size = new System.Drawing.Size(214, 20);
            this.tbx_Survey.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User:";
            // 
            // tbx_User
            // 
            this.tbx_User.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_User.Enabled = false;
            this.tbx_User.Location = new System.Drawing.Point(87, 75);
            this.tbx_User.Name = "tbx_User";
            this.tbx_User.Size = new System.Drawing.Size(214, 20);
            this.tbx_User.TabIndex = 5;
            // 
            // btn_Vote
            // 
            this.btn_Vote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Vote.Location = new System.Drawing.Point(226, 101);
            this.btn_Vote.Name = "btn_Vote";
            this.btn_Vote.Size = new System.Drawing.Size(75, 23);
            this.btn_Vote.TabIndex = 6;
            this.btn_Vote.Text = "Vote!";
            this.btn_Vote.UseVisualStyleBackColor = true;
            this.btn_Vote.Click += new System.EventHandler(this.btn_Vote_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_Vote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 168);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_Vote";
            this.Text = "Vote";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_User;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Survey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_Options;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Vote;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}