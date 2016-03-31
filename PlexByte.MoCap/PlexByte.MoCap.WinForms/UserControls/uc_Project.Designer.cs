namespace PlexByte.MoCap.WinForms.UserControls
{
    partial class uc_Project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Project));
            this.label1 = new System.Windows.Forms.Label();
            this.gbx_ProjectSettings = new System.Windows.Forms.GroupBox();
            this.dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_EnableSurvey = new System.Windows.Forms.CheckBox();
            this.cbx_EnableBalance = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl_Countdown = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ChangeOwner = new System.Windows.Forms.Button();
            this.tbx_Owner = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_Description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Title = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_Tasks = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Budget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentCosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_Surveys = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserInSurvey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbx_ProjectActivity = new System.Windows.Forms.GroupBox();
            this.dtp_Modified = new System.Windows.Forms.DateTimePicker();
            this.tbx_CreatedBy = new System.Windows.Forms.TextBox();
            this.dtp_Created = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.tbx_ModifiedBy = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.btn_InviteUser = new System.Windows.Forms.Button();
            this.lbl_Id = new System.Windows.Forms.Label();
            this.gbx_ProjectSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tasks)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Surveys)).BeginInit();
            this.gbx_ProjectActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // gbx_ProjectSettings
            // 
            this.gbx_ProjectSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_ProjectSettings.Controls.Add(this.lbl_Id);
            this.gbx_ProjectSettings.Controls.Add(this.dtp_EndDate);
            this.gbx_ProjectSettings.Controls.Add(this.dtp_StartDate);
            this.gbx_ProjectSettings.Controls.Add(this.label8);
            this.gbx_ProjectSettings.Controls.Add(this.cbx_EnableSurvey);
            this.gbx_ProjectSettings.Controls.Add(this.cbx_EnableBalance);
            this.gbx_ProjectSettings.Controls.Add(this.label7);
            this.gbx_ProjectSettings.Controls.Add(this.label6);
            this.gbx_ProjectSettings.Controls.Add(this.label22);
            this.gbx_ProjectSettings.Controls.Add(this.lbl_Countdown);
            this.gbx_ProjectSettings.Controls.Add(this.label4);
            this.gbx_ProjectSettings.Controls.Add(this.btn_ChangeOwner);
            this.gbx_ProjectSettings.Controls.Add(this.tbx_Owner);
            this.gbx_ProjectSettings.Controls.Add(this.label3);
            this.gbx_ProjectSettings.Controls.Add(this.tbx_Description);
            this.gbx_ProjectSettings.Controls.Add(this.label2);
            this.gbx_ProjectSettings.Controls.Add(this.tbx_Title);
            this.gbx_ProjectSettings.Controls.Add(this.label1);
            this.gbx_ProjectSettings.Location = new System.Drawing.Point(14, 7);
            this.gbx_ProjectSettings.Margin = new System.Windows.Forms.Padding(4);
            this.gbx_ProjectSettings.Name = "gbx_ProjectSettings";
            this.gbx_ProjectSettings.Padding = new System.Windows.Forms.Padding(4);
            this.gbx_ProjectSettings.Size = new System.Drawing.Size(643, 145);
            this.gbx_ProjectSettings.TabIndex = 1;
            this.gbx_ProjectSettings.TabStop = false;
            this.gbx_ProjectSettings.Text = "Settings";
            // 
            // dtp_EndDate
            // 
            this.dtp_EndDate.CustomFormat = "ddd dd MMM yyyy        HH:mm:ss";
            this.dtp_EndDate.Enabled = false;
            this.dtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndDate.Location = new System.Drawing.Point(92, 76);
            this.dtp_EndDate.Name = "dtp_EndDate";
            this.dtp_EndDate.Size = new System.Drawing.Size(219, 22);
            this.dtp_EndDate.TabIndex = 68;
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.CustomFormat = "ddd dd MMM yyyy        HH:mm:ss";
            this.dtp_StartDate.Enabled = false;
            this.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_StartDate.Location = new System.Drawing.Point(92, 48);
            this.dtp_StartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(219, 22);
            this.dtp_StartDate.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 53);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 66;
            this.label8.Text = "Start Date:";
            // 
            // cbx_EnableSurvey
            // 
            this.cbx_EnableSurvey.AutoSize = true;
            this.cbx_EnableSurvey.Checked = true;
            this.cbx_EnableSurvey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_EnableSurvey.Enabled = false;
            this.cbx_EnableSurvey.Location = new System.Drawing.Point(613, 114);
            this.cbx_EnableSurvey.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_EnableSurvey.Name = "cbx_EnableSurvey";
            this.cbx_EnableSurvey.Size = new System.Drawing.Size(18, 17);
            this.cbx_EnableSurvey.TabIndex = 65;
            this.cbx_EnableSurvey.UseVisualStyleBackColor = true;
            // 
            // cbx_EnableBalance
            // 
            this.cbx_EnableBalance.AutoSize = true;
            this.cbx_EnableBalance.Checked = true;
            this.cbx_EnableBalance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_EnableBalance.Enabled = false;
            this.cbx_EnableBalance.Location = new System.Drawing.Point(453, 114);
            this.cbx_EnableBalance.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_EnableBalance.Name = "cbx_EnableBalance";
            this.cbx_EnableBalance.Size = new System.Drawing.Size(18, 17);
            this.cbx_EnableBalance.TabIndex = 64;
            this.cbx_EnableBalance.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 113);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 63;
            this.label7.Text = "Enable Survey:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 60;
            this.label6.Text = "Enable Balance:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 84);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 17);
            this.label22.TabIndex = 58;
            this.label22.Text = "End Date:";
            // 
            // lbl_Countdown
            // 
            this.lbl_Countdown.AutoSize = true;
            this.lbl_Countdown.Location = new System.Drawing.Point(424, 81);
            this.lbl_Countdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Countdown.Name = "lbl_Countdown";
            this.lbl_Countdown.Size = new System.Drawing.Size(110, 17);
            this.lbl_Countdown.TabIndex = 57;
            this.lbl_Countdown.Text = "000d:00h:00min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Countdown:";
            // 
            // btn_ChangeOwner
            // 
            this.btn_ChangeOwner.Enabled = false;
            this.btn_ChangeOwner.Location = new System.Drawing.Point(266, 107);
            this.btn_ChangeOwner.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ChangeOwner.Name = "btn_ChangeOwner";
            this.btn_ChangeOwner.Size = new System.Drawing.Size(45, 28);
            this.btn_ChangeOwner.TabIndex = 6;
            this.btn_ChangeOwner.Text = "=>";
            this.btn_ChangeOwner.UseVisualStyleBackColor = true;
            // 
            // tbx_Owner
            // 
            this.tbx_Owner.Enabled = false;
            this.tbx_Owner.Location = new System.Drawing.Point(92, 110);
            this.tbx_Owner.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Owner.Name = "tbx_Owner";
            this.tbx_Owner.Size = new System.Drawing.Size(160, 22);
            this.tbx_Owner.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Owner:";
            // 
            // tbx_Description
            // 
            this.tbx_Description.Enabled = false;
            this.tbx_Description.Location = new System.Drawing.Point(427, 18);
            this.tbx_Description.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Description.Multiline = true;
            this.tbx_Description.Name = "tbx_Description";
            this.tbx_Description.Size = new System.Drawing.Size(204, 53);
            this.tbx_Description.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // tbx_Title
            // 
            this.tbx_Title.Enabled = false;
            this.tbx_Title.Location = new System.Drawing.Point(92, 18);
            this.tbx_Title.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Title.Name = "tbx_Title";
            this.tbx_Title.Size = new System.Drawing.Size(219, 22);
            this.tbx_Title.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgv_Tasks);
            this.groupBox2.Location = new System.Drawing.Point(14, 267);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(643, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tasks";
            // 
            // dgv_Tasks
            // 
            this.dgv_Tasks.AllowUserToAddRows = false;
            this.dgv_Tasks.AllowUserToDeleteRows = false;
            this.dgv_Tasks.AllowUserToOrderColumns = true;
            this.dgv_Tasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Tasks.ColumnHeadersHeight = 20;
            this.dgv_Tasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Tasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.DueDate,
            this.Duration,
            this.Budget,
            this.CurrentCosts,
            this.CurrentDuration,
            this.Owner,
            this.Progress});
            this.dgv_Tasks.Location = new System.Drawing.Point(8, 24);
            this.dgv_Tasks.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Tasks.MultiSelect = false;
            this.dgv_Tasks.Name = "dgv_Tasks";
            this.dgv_Tasks.ReadOnly = true;
            this.dgv_Tasks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Tasks.RowHeadersVisible = false;
            this.dgv_Tasks.RowTemplate.Height = 15;
            this.dgv_Tasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Tasks.ShowCellErrors = false;
            this.dgv_Tasks.ShowCellToolTips = false;
            this.dgv_Tasks.ShowEditingIcon = false;
            this.dgv_Tasks.ShowRowErrors = false;
            this.dgv_Tasks.Size = new System.Drawing.Size(623, 75);
            this.dgv_Tasks.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 67;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 68;
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Width = 67;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 68;
            // 
            // Budget
            // 
            this.Budget.HeaderText = "Budget";
            this.Budget.Name = "Budget";
            this.Budget.ReadOnly = true;
            this.Budget.Width = 67;
            // 
            // CurrentCosts
            // 
            this.CurrentCosts.HeaderText = "Current Costs";
            this.CurrentCosts.Name = "CurrentCosts";
            this.CurrentCosts.ReadOnly = true;
            this.CurrentCosts.Width = 68;
            // 
            // CurrentDuration
            // 
            this.CurrentDuration.HeaderText = "Current Duration";
            this.CurrentDuration.Name = "CurrentDuration";
            this.CurrentDuration.ReadOnly = true;
            this.CurrentDuration.Width = 67;
            // 
            // Owner
            // 
            this.Owner.HeaderText = "Owner";
            this.Owner.Name = "Owner";
            this.Owner.ReadOnly = true;
            this.Owner.Width = 68;
            // 
            // Progress
            // 
            this.Progress.HeaderText = "Progress";
            this.Progress.Name = "Progress";
            this.Progress.ReadOnly = true;
            this.Progress.Width = 67;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgv_Surveys);
            this.groupBox3.Location = new System.Drawing.Point(14, 375);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(643, 116);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Surveys";
            // 
            // dgv_Surveys
            // 
            this.dgv_Surveys.AllowUserToAddRows = false;
            this.dgv_Surveys.AllowUserToDeleteRows = false;
            this.dgv_Surveys.AllowUserToOrderColumns = true;
            this.dgv_Surveys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Surveys.ColumnHeadersHeight = 20;
            this.dgv_Surveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Surveys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn8,
            this.UserInSurvey,
            this.UserCount,
            this.dataGridViewTextBoxColumn9});
            this.dgv_Surveys.Location = new System.Drawing.Point(8, 26);
            this.dgv_Surveys.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Surveys.MultiSelect = false;
            this.dgv_Surveys.Name = "dgv_Surveys";
            this.dgv_Surveys.ReadOnly = true;
            this.dgv_Surveys.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Surveys.RowHeadersVisible = false;
            this.dgv_Surveys.RowTemplate.Height = 15;
            this.dgv_Surveys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Surveys.ShowCellErrors = false;
            this.dgv_Surveys.ShowCellToolTips = false;
            this.dgv_Surveys.ShowEditingIcon = false;
            this.dgv_Surveys.ShowRowErrors = false;
            this.dgv_Surveys.Size = new System.Drawing.Size(623, 82);
            this.dgv_Surveys.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 67;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Title";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 85;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Due Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 78;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Owner";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 68;
            // 
            // UserInSurvey
            // 
            this.UserInSurvey.HeaderText = "User In Survey";
            this.UserInSurvey.Name = "UserInSurvey";
            this.UserInSurvey.ReadOnly = true;
            this.UserInSurvey.Width = 110;
            // 
            // UserCount
            // 
            this.UserCount.HeaderText = "User Voted";
            this.UserCount.Name = "UserCount";
            this.UserCount.ReadOnly = true;
            this.UserCount.Width = 89;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Progress (%)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 110;
            // 
            // gbx_ProjectActivity
            // 
            this.gbx_ProjectActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_ProjectActivity.Controls.Add(this.dtp_Modified);
            this.gbx_ProjectActivity.Controls.Add(this.tbx_CreatedBy);
            this.gbx_ProjectActivity.Controls.Add(this.dtp_Created);
            this.gbx_ProjectActivity.Controls.Add(this.label13);
            this.gbx_ProjectActivity.Controls.Add(this.tbx_ModifiedBy);
            this.gbx_ProjectActivity.Controls.Add(this.label12);
            this.gbx_ProjectActivity.Controls.Add(this.label15);
            this.gbx_ProjectActivity.Controls.Add(this.label14);
            this.gbx_ProjectActivity.Location = new System.Drawing.Point(14, 155);
            this.gbx_ProjectActivity.Margin = new System.Windows.Forms.Padding(4);
            this.gbx_ProjectActivity.Name = "gbx_ProjectActivity";
            this.gbx_ProjectActivity.Padding = new System.Windows.Forms.Padding(4);
            this.gbx_ProjectActivity.Size = new System.Drawing.Size(643, 78);
            this.gbx_ProjectActivity.TabIndex = 4;
            this.gbx_ProjectActivity.TabStop = false;
            this.gbx_ProjectActivity.Text = "Activity";
            // 
            // dtp_Modified
            // 
            this.dtp_Modified.CustomFormat = "ddd dd MMM yyyy        HH:mm";
            this.dtp_Modified.Enabled = false;
            this.dtp_Modified.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Modified.Location = new System.Drawing.Point(427, 46);
            this.dtp_Modified.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_Modified.Name = "dtp_Modified";
            this.dtp_Modified.Size = new System.Drawing.Size(204, 22);
            this.dtp_Modified.TabIndex = 26;
            // 
            // tbx_CreatedBy
            // 
            this.tbx_CreatedBy.Enabled = false;
            this.tbx_CreatedBy.Location = new System.Drawing.Point(92, 17);
            this.tbx_CreatedBy.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_CreatedBy.Name = "tbx_CreatedBy";
            this.tbx_CreatedBy.Size = new System.Drawing.Size(160, 22);
            this.tbx_CreatedBy.TabIndex = 23;
            // 
            // dtp_Created
            // 
            this.dtp_Created.CustomFormat = "ddd dd MMM yyyy        HH:mm";
            this.dtp_Created.Enabled = false;
            this.dtp_Created.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Created.Location = new System.Drawing.Point(427, 15);
            this.dtp_Created.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_Created.Name = "dtp_Created";
            this.dtp_Created.Size = new System.Drawing.Size(204, 22);
            this.dtp_Created.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 17);
            this.label13.TabIndex = 19;
            this.label13.Text = "Created by:";
            // 
            // tbx_ModifiedBy
            // 
            this.tbx_ModifiedBy.Enabled = false;
            this.tbx_ModifiedBy.Location = new System.Drawing.Point(92, 48);
            this.tbx_ModifiedBy.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_ModifiedBy.Name = "tbx_ModifiedBy";
            this.tbx_ModifiedBy.Size = new System.Drawing.Size(160, 22);
            this.tbx_ModifiedBy.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 51);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Modified by:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(334, 51);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 17);
            this.label15.TabIndex = 21;
            this.label15.Text = "at:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(334, 20);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 17);
            this.label14.TabIndex = 22;
            this.label14.Text = "at:";
            // 
            // btn_Update
            // 
            this.btn_Update.Enabled = false;
            this.btn_Update.Location = new System.Drawing.Point(166, 239);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(100, 28);
            this.btn_Update.TabIndex = 28;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(25, 239);
            this.btn_Create.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(100, 28);
            this.btn_Create.TabIndex = 27;
            this.btn_Create.Text = "New";
            this.btn_Create.UseVisualStyleBackColor = true;
            // 
            // btn_InviteUser
            // 
            this.btn_InviteUser.Enabled = false;
            this.btn_InviteUser.Location = new System.Drawing.Point(545, 239);
            this.btn_InviteUser.Name = "btn_InviteUser";
            this.btn_InviteUser.Size = new System.Drawing.Size(100, 28);
            this.btn_InviteUser.TabIndex = 29;
            this.btn_InviteUser.Text = "Invite User";
            this.btn_InviteUser.UseVisualStyleBackColor = true;
            // 
            // lbl_Id
            // 
            this.lbl_Id.AutoSize = true;
            this.lbl_Id.Location = new System.Drawing.Point(148, -14);
            this.lbl_Id.Name = "lbl_Id";
            this.lbl_Id.Size = new System.Drawing.Size(0, 17);
            this.lbl_Id.TabIndex = 30;
            this.lbl_Id.Visible = false;
            // 
            // uc_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 500);
            this.Controls.Add(this.btn_InviteUser);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.gbx_ProjectActivity);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbx_ProjectSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_Project";
            this.gbx_ProjectSettings.ResumeLayout(false);
            this.gbx_ProjectSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tasks)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Surveys)).EndInit();
            this.gbx_ProjectActivity.ResumeLayout(false);
            this.gbx_ProjectActivity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbx_ProjectSettings;
        private System.Windows.Forms.TextBox tbx_Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_Description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Owner;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbx_ProjectActivity;
        private System.Windows.Forms.DateTimePicker dtp_Modified;
        private System.Windows.Forms.TextBox tbx_CreatedBy;
        private System.Windows.Forms.DateTimePicker dtp_Created;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbx_ModifiedBy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentCosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budget;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridView dgv_Tasks;
        private System.Windows.Forms.DataGridView dgv_Surveys;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserInSurvey;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label lbl_Countdown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cbx_EnableSurvey;
        private System.Windows.Forms.CheckBox cbx_EnableBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_InviteUser;
        private System.Windows.Forms.Button btn_ChangeOwner;
        private System.Windows.Forms.DateTimePicker dtp_EndDate;
        private System.Windows.Forms.Label lbl_Id;
    }
}