namespace PlexByte.MoCap.WinForms.UserControls
{
    partial class uc_Survey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Survey));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_ModifiedAt = new System.Windows.Forms.DateTimePicker();
            this.dtp_CreatedAt = new System.Windows.Forms.DateTimePicker();
            this.tbx_ModifiedBy = new System.Windows.Forms.TextBox();
            this.tbx_CreatedBy = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp_DueDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_Id = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_CreateOptions = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lsv_VoteOverview = new System.Windows.Forms.ListView();
            this.tbx_Description = new System.Windows.Forms.TextBox();
            this.tbx_State = new System.Windows.Forms.TextBox();
            this.tbx_SurveyVoteCount = new System.Windows.Forms.TextBox();
            this.tbx_SurveyTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Vote = new System.Windows.Forms.Button();
            this.lv_Otions = new System.Windows.Forms.ListView();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.cbx_Project = new System.Windows.Forms.ComboBox();
            this.num_VotesPerUser = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_InteractionId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_VotesPerUser)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtp_ModifiedAt);
            this.groupBox1.Controls.Add(this.dtp_CreatedAt);
            this.groupBox1.Controls.Add(this.tbx_ModifiedBy);
            this.groupBox1.Controls.Add(this.tbx_CreatedBy);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 75);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activity";
            // 
            // dtp_ModifiedAt
            // 
            this.dtp_ModifiedAt.CustomFormat = "ddd dd MMM yyyy        HH:mm";
            this.dtp_ModifiedAt.Enabled = false;
            this.dtp_ModifiedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ModifiedAt.Location = new System.Drawing.Point(416, 45);
            this.dtp_ModifiedAt.Name = "dtp_ModifiedAt";
            this.dtp_ModifiedAt.Size = new System.Drawing.Size(201, 20);
            this.dtp_ModifiedAt.TabIndex = 18;
            // 
            // dtp_CreatedAt
            // 
            this.dtp_CreatedAt.CustomFormat = "ddd dd MMM yyyy        HH:mm";
            this.dtp_CreatedAt.Enabled = false;
            this.dtp_CreatedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_CreatedAt.Location = new System.Drawing.Point(416, 19);
            this.dtp_CreatedAt.Name = "dtp_CreatedAt";
            this.dtp_CreatedAt.Size = new System.Drawing.Size(201, 20);
            this.dtp_CreatedAt.TabIndex = 17;
            // 
            // tbx_ModifiedBy
            // 
            this.tbx_ModifiedBy.Enabled = false;
            this.tbx_ModifiedBy.Location = new System.Drawing.Point(89, 45);
            this.tbx_ModifiedBy.Name = "tbx_ModifiedBy";
            this.tbx_ModifiedBy.Size = new System.Drawing.Size(178, 20);
            this.tbx_ModifiedBy.TabIndex = 15;
            // 
            // tbx_CreatedBy
            // 
            this.tbx_CreatedBy.Enabled = false;
            this.tbx_CreatedBy.Location = new System.Drawing.Point(89, 19);
            this.tbx_CreatedBy.Name = "tbx_CreatedBy";
            this.tbx_CreatedBy.Size = new System.Drawing.Size(178, 20);
            this.tbx_CreatedBy.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(332, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "at:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(332, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "at:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Modified by:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Created by:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Description:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbl_InteractionId);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.num_VotesPerUser);
            this.groupBox2.Controls.Add(this.cbx_Project);
            this.groupBox2.Controls.Add(this.dtp_DueDate);
            this.groupBox2.Controls.Add(this.dtp_End);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dtp_Start);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbl_Id);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btn_CreateOptions);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lsv_VoteOverview);
            this.groupBox2.Controls.Add(this.tbx_Description);
            this.groupBox2.Controls.Add(this.tbx_State);
            this.groupBox2.Controls.Add(this.tbx_SurveyVoteCount);
            this.groupBox2.Controls.Add(this.tbx_SurveyTitle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 259);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Survey Details:";
            // 
            // dtp_DueDate
            // 
            this.dtp_DueDate.Location = new System.Drawing.Point(89, 97);
            this.dtp_DueDate.Name = "dtp_DueDate";
            this.dtp_DueDate.Size = new System.Drawing.Size(178, 20);
            this.dtp_DueDate.TabIndex = 45;
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = "";
            this.dtp_End.Location = new System.Drawing.Point(416, 123);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(201, 20);
            this.dtp_End.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(319, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "End:";
            // 
            // dtp_Start
            // 
            this.dtp_Start.CustomFormat = "";
            this.dtp_Start.Location = new System.Drawing.Point(89, 123);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(178, 20);
            this.dtp_Start.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Start:";
            // 
            // lbl_Id
            // 
            this.lbl_Id.AutoSize = true;
            this.lbl_Id.Location = new System.Drawing.Point(86, 230);
            this.lbl_Id.Name = "lbl_Id";
            this.lbl_Id.Size = new System.Drawing.Size(0, 13);
            this.lbl_Id.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Id:";
            // 
            // btn_CreateOptions
            // 
            this.btn_CreateOptions.Location = new System.Drawing.Point(495, 225);
            this.btn_CreateOptions.Name = "btn_CreateOptions";
            this.btn_CreateOptions.Size = new System.Drawing.Size(122, 23);
            this.btn_CreateOptions.TabIndex = 38;
            this.btn_CreateOptions.Text = "Create Options";
            this.btn_CreateOptions.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Vote Overview:";
            // 
            // lsv_VoteOverview
            // 
            this.lsv_VoteOverview.Location = new System.Drawing.Point(89, 153);
            this.lsv_VoteOverview.Name = "lsv_VoteOverview";
            this.lsv_VoteOverview.Size = new System.Drawing.Size(528, 65);
            this.lsv_VoteOverview.TabIndex = 33;
            this.lsv_VoteOverview.UseCompatibleStateImageBehavior = false;
            this.lsv_VoteOverview.View = System.Windows.Forms.View.List;
            // 
            // tbx_Description
            // 
            this.tbx_Description.Location = new System.Drawing.Point(416, 19);
            this.tbx_Description.Multiline = true;
            this.tbx_Description.Name = "tbx_Description";
            this.tbx_Description.Size = new System.Drawing.Size(201, 46);
            this.tbx_Description.TabIndex = 30;
            // 
            // tbx_State
            // 
            this.tbx_State.Location = new System.Drawing.Point(89, 71);
            this.tbx_State.Name = "tbx_State";
            this.tbx_State.Size = new System.Drawing.Size(178, 20);
            this.tbx_State.TabIndex = 28;
            // 
            // tbx_SurveyVoteCount
            // 
            this.tbx_SurveyVoteCount.Location = new System.Drawing.Point(89, 45);
            this.tbx_SurveyVoteCount.Name = "tbx_SurveyVoteCount";
            this.tbx_SurveyVoteCount.Size = new System.Drawing.Size(178, 20);
            this.tbx_SurveyVoteCount.TabIndex = 27;
            // 
            // tbx_SurveyTitle
            // 
            this.tbx_SurveyTitle.Location = new System.Drawing.Point(89, 19);
            this.tbx_SurveyTitle.Name = "tbx_SurveyTitle";
            this.tbx_SurveyTitle.Size = new System.Drawing.Size(178, 20);
            this.tbx_SurveyTitle.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Project:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Due Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "State:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Votes per User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Votes:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_Vote);
            this.groupBox3.Controls.Add(this.lv_Otions);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 358);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(625, 83);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Voting:";
            // 
            // btn_Vote
            // 
            this.btn_Vote.Location = new System.Drawing.Point(9, 19);
            this.btn_Vote.Name = "btn_Vote";
            this.btn_Vote.Size = new System.Drawing.Size(75, 23);
            this.btn_Vote.TabIndex = 20;
            this.btn_Vote.Text = "Vote";
            this.btn_Vote.UseVisualStyleBackColor = true;
            // 
            // lv_Otions
            // 
            this.lv_Otions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_Otions.CheckBoxes = true;
            this.lv_Otions.HideSelection = false;
            this.lv_Otions.HoverSelection = true;
            this.lv_Otions.Location = new System.Drawing.Point(89, 19);
            this.lv_Otions.MultiSelect = false;
            this.lv_Otions.Name = "lv_Otions";
            this.lv_Otions.Size = new System.Drawing.Size(528, 51);
            this.lv_Otions.TabIndex = 19;
            this.lv_Otions.UseCompatibleStateImageBehavior = false;
            this.lv_Otions.View = System.Windows.Forms.View.List;
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(554, 447);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_Edit.TabIndex = 21;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(21, 447);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(75, 23);
            this.btn_New.TabIndex = 22;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            // 
            // cbx_Project
            // 
            this.cbx_Project.FormattingEnabled = true;
            this.cbx_Project.Location = new System.Drawing.Point(416, 97);
            this.cbx_Project.Name = "cbx_Project";
            this.cbx_Project.Size = new System.Drawing.Size(201, 21);
            this.cbx_Project.TabIndex = 46;
            this.cbx_Project.SelectedIndexChanged += new System.EventHandler(this.cbx_Project_SelectedIndexChanged);
            // 
            // num_VotesPerUser
            // 
            this.num_VotesPerUser.Location = new System.Drawing.Point(416, 71);
            this.num_VotesPerUser.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_VotesPerUser.Name = "num_VotesPerUser";
            this.num_VotesPerUser.Size = new System.Drawing.Size(201, 20);
            this.num_VotesPerUser.TabIndex = 47;
            this.num_VotesPerUser.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(248, 230);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 13);
            this.label16.TabIndex = 48;
            this.label16.Text = "InteractionId:";
            // 
            // lbl_InteractionId
            // 
            this.lbl_InteractionId.AutoSize = true;
            this.lbl_InteractionId.Location = new System.Drawing.Point(345, 230);
            this.lbl_InteractionId.Name = "lbl_InteractionId";
            this.lbl_InteractionId.Size = new System.Drawing.Size(0, 13);
            this.lbl_InteractionId.TabIndex = 49;
            // 
            // uc_Survey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 479);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "uc_Survey";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_VotesPerUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtp_ModifiedAt;
        private System.Windows.Forms.DateTimePicker dtp_CreatedAt;
        private System.Windows.Forms.TextBox tbx_ModifiedBy;
        private System.Windows.Forms.TextBox tbx_CreatedBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Vote;
        private System.Windows.Forms.ListView lv_Otions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lsv_VoteOverview;
        private System.Windows.Forms.TextBox tbx_Description;
        private System.Windows.Forms.TextBox tbx_State;
        private System.Windows.Forms.TextBox tbx_SurveyVoteCount;
        private System.Windows.Forms.TextBox tbx_SurveyTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_CreateOptions;
        private System.Windows.Forms.Label lbl_Id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_DueDate;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.ComboBox cbx_Project;
        private System.Windows.Forms.NumericUpDown num_VotesPerUser;
        private System.Windows.Forms.Label lbl_InteractionId;
        private System.Windows.Forms.Label label16;
    }
}
