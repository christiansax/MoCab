namespace PlexByte.MoCap.WinForms.UserControls
{
    partial class uc_MenuBar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_MenuBar));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Task = new System.Windows.Forms.Button();
            this.btn_Project = new System.Windows.Forms.Button();
            this.btn_Survey = new System.Windows.Forms.Button();
            this.btn_Account = new System.Windows.Forms.Button();
            this.btn_Timeslice = new System.Windows.Forms.Button();
            this.btn_Expense = new System.Windows.Forms.Button();
            this.btn_User = new System.Windows.Forms.Button();
            this.btn_Vote = new System.Windows.Forms.Button();
            this.btn_SurveyOptions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Task
            // 
            this.btn_Task.Image = global::PlexByte.MoCap.WinForms.Properties.Resources.task1;
            this.btn_Task.Location = new System.Drawing.Point(78, 8);
            this.btn_Task.Name = "btn_Task";
            this.btn_Task.Size = new System.Drawing.Size(64, 64);
            this.btn_Task.TabIndex = 1;
            this.btn_Task.UseVisualStyleBackColor = true;
            this.btn_Task.MouseEnter += new System.EventHandler(this.Task_MouseEnter);
            // 
            // btn_Project
            // 
            this.btn_Project.Image = ((System.Drawing.Image)(resources.GetObject("btn_Project.Image")));
            this.btn_Project.Location = new System.Drawing.Point(8, 8);
            this.btn_Project.Name = "btn_Project";
            this.btn_Project.Size = new System.Drawing.Size(64, 64);
            this.btn_Project.TabIndex = 2;
            this.btn_Project.UseVisualStyleBackColor = true;
            this.btn_Project.MouseEnter += new System.EventHandler(this.Project_MouseEnter);
            // 
            // btn_Survey
            // 
            this.btn_Survey.Image = global::PlexByte.MoCap.WinForms.Properties.Resources.survey;
            this.btn_Survey.Location = new System.Drawing.Point(156, 8);
            this.btn_Survey.Name = "btn_Survey";
            this.btn_Survey.Size = new System.Drawing.Size(64, 64);
            this.btn_Survey.TabIndex = 3;
            this.btn_Survey.UseVisualStyleBackColor = true;
            this.btn_Survey.MouseEnter += new System.EventHandler(this.Survey_MouseEnter);
            // 
            // btn_Account
            // 
            this.btn_Account.Image = global::PlexByte.MoCap.WinForms.Properties.Resources.account;
            this.btn_Account.Location = new System.Drawing.Point(374, 8);
            this.btn_Account.Name = "btn_Account";
            this.btn_Account.Size = new System.Drawing.Size(64, 64);
            this.btn_Account.TabIndex = 4;
            this.btn_Account.UseVisualStyleBackColor = true;
            this.btn_Account.MouseEnter += new System.EventHandler(this.Account_MouseEnter);
            // 
            // btn_Timeslice
            // 
            this.btn_Timeslice.Image = global::PlexByte.MoCap.WinForms.Properties.Resources.timeslice;
            this.btn_Timeslice.Location = new System.Drawing.Point(514, 8);
            this.btn_Timeslice.Name = "btn_Timeslice";
            this.btn_Timeslice.Size = new System.Drawing.Size(64, 64);
            this.btn_Timeslice.TabIndex = 5;
            this.btn_Timeslice.UseVisualStyleBackColor = true;
            this.btn_Timeslice.MouseEnter += new System.EventHandler(this.Timeslice_MouseEnter);
            // 
            // btn_Expense
            // 
            this.btn_Expense.Image = global::PlexByte.MoCap.WinForms.Properties.Resources.expense;
            this.btn_Expense.Location = new System.Drawing.Point(444, 8);
            this.btn_Expense.Name = "btn_Expense";
            this.btn_Expense.Size = new System.Drawing.Size(64, 64);
            this.btn_Expense.TabIndex = 6;
            this.btn_Expense.UseVisualStyleBackColor = true;
            this.btn_Expense.MouseEnter += new System.EventHandler(this.Expense_MouseEnter);
            // 
            // btn_User
            // 
            this.btn_User.Image = global::PlexByte.MoCap.WinForms.Properties.Resources.user;
            this.btn_User.Location = new System.Drawing.Point(592, 8);
            this.btn_User.Name = "btn_User";
            this.btn_User.Size = new System.Drawing.Size(64, 64);
            this.btn_User.TabIndex = 7;
            this.btn_User.UseVisualStyleBackColor = true;
            this.btn_User.MouseEnter += new System.EventHandler(this.User_MouseEnter);
            // 
            // btn_Vote
            // 
            this.btn_Vote.Image = global::PlexByte.MoCap.WinForms.Properties.Resources.vote;
            this.btn_Vote.Location = new System.Drawing.Point(296, 8);
            this.btn_Vote.Name = "btn_Vote";
            this.btn_Vote.Size = new System.Drawing.Size(64, 64);
            this.btn_Vote.TabIndex = 8;
            this.btn_Vote.UseVisualStyleBackColor = true;
            this.btn_Vote.MouseEnter += new System.EventHandler(this.Vote_MouseEnter);
            // 
            // btn_SurveyOptions
            // 
            this.btn_SurveyOptions.Image = global::PlexByte.MoCap.WinForms.Properties.Resources.surveyOption;
            this.btn_SurveyOptions.Location = new System.Drawing.Point(226, 8);
            this.btn_SurveyOptions.Name = "btn_SurveyOptions";
            this.btn_SurveyOptions.Size = new System.Drawing.Size(64, 64);
            this.btn_SurveyOptions.TabIndex = 9;
            this.btn_SurveyOptions.UseVisualStyleBackColor = true;
            this.btn_SurveyOptions.MouseEnter += new System.EventHandler(this.SurveyOptions_MouseEnter);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(584, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 64);
            this.label1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(366, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 64);
            this.label2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(148, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 64);
            this.label3.TabIndex = 12;
            // 
            // uc_MenuBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 81);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SurveyOptions);
            this.Controls.Add(this.btn_Vote);
            this.Controls.Add(this.btn_User);
            this.Controls.Add(this.btn_Expense);
            this.Controls.Add(this.btn_Timeslice);
            this.Controls.Add(this.btn_Account);
            this.Controls.Add(this.btn_Survey);
            this.Controls.Add(this.btn_Project);
            this.Controls.Add(this.btn_Task);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "uc_MenuBar";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_Task;
        private System.Windows.Forms.Button btn_Project;
        private System.Windows.Forms.Button btn_Survey;
        private System.Windows.Forms.Button btn_Account;
        private System.Windows.Forms.Button btn_Timeslice;
        private System.Windows.Forms.Button btn_Expense;
        private System.Windows.Forms.Button btn_User;
        private System.Windows.Forms.Button btn_Vote;
        private System.Windows.Forms.Button btn_SurveyOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
