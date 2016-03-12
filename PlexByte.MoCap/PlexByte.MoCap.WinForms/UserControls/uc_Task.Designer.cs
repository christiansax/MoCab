namespace PlexByte.MoCap.WinForms.UserControls
{
    partial class uc_Task
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Task));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtp_Modified = new System.Windows.Forms.DateTimePicker();
            this.dtp_Created = new System.Windows.Forms.DateTimePicker();
            this.tbx_ModifiedBy = new System.Windows.Forms.TextBox();
            this.tbx_CreatedBy = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgw_Subtasks = new System.Windows.Forms.DataGridView();
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
            this.pbr_Progress = new System.Windows.Forms.ProgressBar();
            this.btn_ChangeOwner = new System.Windows.Forms.Button();
            this.tbx_Owner = new System.Windows.Forms.TextBox();
            this.tbx_Description = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.num_Priority = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.num_EffortsMin = new System.Windows.Forms.NumericUpDown();
            this.num_EffortsHours = new System.Windows.Forms.NumericUpDown();
            this.dtp_DueDate = new System.Windows.Forms.DateTimePicker();
            this.tbx_ProjectName = new System.Windows.Forms.TextBox();
            this.cbx_IsToDo = new System.Windows.Forms.CheckBox();
            this.tbx_Title = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.num_TotalCosts = new System.Windows.Forms.NumericUpDown();
            this.num_Budget = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Subtasks)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Priority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_EffortsMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_EffortsHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_TotalCosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Budget)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.dtp_Modified);
            this.groupBox1.Controls.Add(this.dtp_Created);
            this.groupBox1.Controls.Add(this.tbx_ModifiedBy);
            this.groupBox1.Controls.Add(this.tbx_CreatedBy);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(12, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 115);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activity";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(542, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "Subtask";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(276, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dtp_Modified
            // 
            this.dtp_Modified.CustomFormat = "ddd dd MMM yyyy        HH:mm";
            this.dtp_Modified.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Modified.Location = new System.Drawing.Point(416, 45);
            this.dtp_Modified.Name = "dtp_Modified";
            this.dtp_Modified.Size = new System.Drawing.Size(201, 20);
            this.dtp_Modified.TabIndex = 18;
            // 
            // dtp_Created
            // 
            this.dtp_Created.CustomFormat = "ddd dd MMM yyyy        HH:mm";
            this.dtp_Created.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Created.Location = new System.Drawing.Point(416, 19);
            this.dtp_Created.Name = "dtp_Created";
            this.dtp_Created.Size = new System.Drawing.Size(201, 20);
            this.dtp_Created.TabIndex = 17;
            // 
            // tbx_ModifiedBy
            // 
            this.tbx_ModifiedBy.Location = new System.Drawing.Point(89, 45);
            this.tbx_ModifiedBy.Name = "tbx_ModifiedBy";
            this.tbx_ModifiedBy.Size = new System.Drawing.Size(133, 20);
            this.tbx_ModifiedBy.TabIndex = 15;
            // 
            // tbx_CreatedBy
            // 
            this.tbx_CreatedBy.Location = new System.Drawing.Point(89, 19);
            this.tbx_CreatedBy.Name = "tbx_CreatedBy";
            this.tbx_CreatedBy.Size = new System.Drawing.Size(133, 20);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgw_Subtasks);
            this.groupBox2.Location = new System.Drawing.Point(12, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 167);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sub Tasks";
            // 
            // dgw_Subtasks
            // 
            this.dgw_Subtasks.AllowUserToAddRows = false;
            this.dgw_Subtasks.AllowUserToDeleteRows = false;
            this.dgw_Subtasks.AllowUserToOrderColumns = true;
            this.dgw_Subtasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_Subtasks.ColumnHeadersHeight = 20;
            this.dgw_Subtasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgw_Subtasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.DueDate,
            this.Duration,
            this.Budget,
            this.CurrentCosts,
            this.CurrentDuration,
            this.Owner,
            this.Progress});
            this.dgw_Subtasks.Location = new System.Drawing.Point(9, 20);
            this.dgw_Subtasks.MultiSelect = false;
            this.dgw_Subtasks.Name = "dgw_Subtasks";
            this.dgw_Subtasks.ReadOnly = true;
            this.dgw_Subtasks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgw_Subtasks.RowHeadersVisible = false;
            this.dgw_Subtasks.RowTemplate.Height = 15;
            this.dgw_Subtasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_Subtasks.ShowCellErrors = false;
            this.dgw_Subtasks.ShowCellToolTips = false;
            this.dgw_Subtasks.ShowEditingIcon = false;
            this.dgw_Subtasks.ShowRowErrors = false;
            this.dgw_Subtasks.Size = new System.Drawing.Size(610, 141);
            this.dgw_Subtasks.TabIndex = 0;
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
            this.groupBox3.Controls.Add(this.num_Budget);
            this.groupBox3.Controls.Add(this.num_TotalCosts);
            this.groupBox3.Controls.Add(this.pbr_Progress);
            this.groupBox3.Controls.Add(this.btn_ChangeOwner);
            this.groupBox3.Controls.Add(this.tbx_Owner);
            this.groupBox3.Controls.Add(this.tbx_Description);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.num_Priority);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.num_EffortsMin);
            this.groupBox3.Controls.Add(this.num_EffortsHours);
            this.groupBox3.Controls.Add(this.dtp_DueDate);
            this.groupBox3.Controls.Add(this.tbx_ProjectName);
            this.groupBox3.Controls.Add(this.cbx_IsToDo);
            this.groupBox3.Controls.Add(this.tbx_Title);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(625, 183);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // pbr_Progress
            // 
            this.pbr_Progress.Location = new System.Drawing.Point(416, 124);
            this.pbr_Progress.Name = "pbr_Progress";
            this.pbr_Progress.Size = new System.Drawing.Size(201, 20);
            this.pbr_Progress.TabIndex = 52;
            // 
            // btn_ChangeOwner
            // 
            this.btn_ChangeOwner.Location = new System.Drawing.Point(583, 95);
            this.btn_ChangeOwner.Name = "btn_ChangeOwner";
            this.btn_ChangeOwner.Size = new System.Drawing.Size(34, 23);
            this.btn_ChangeOwner.TabIndex = 51;
            this.btn_ChangeOwner.Text = "=>";
            this.btn_ChangeOwner.UseVisualStyleBackColor = true;
            // 
            // tbx_Owner
            // 
            this.tbx_Owner.Location = new System.Drawing.Point(416, 97);
            this.tbx_Owner.Name = "tbx_Owner";
            this.tbx_Owner.Size = new System.Drawing.Size(161, 20);
            this.tbx_Owner.TabIndex = 50;
            // 
            // tbx_Description
            // 
            this.tbx_Description.Location = new System.Drawing.Point(416, 22);
            this.tbx_Description.Multiline = true;
            this.tbx_Description.Name = "tbx_Description";
            this.tbx_Description.Size = new System.Drawing.Size(201, 67);
            this.tbx_Description.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(324, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Total Costs:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(324, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Progress:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Owner:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Description:";
            // 
            // num_Priority
            // 
            this.num_Priority.Location = new System.Drawing.Point(243, 48);
            this.num_Priority.Name = "num_Priority";
            this.num_Priority.Size = new System.Drawing.Size(60, 20);
            this.num_Priority.TabIndex = 44;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(280, 128);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "min";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(155, 128);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "h";
            // 
            // num_EffortsMin
            // 
            this.num_EffortsMin.Location = new System.Drawing.Point(214, 126);
            this.num_EffortsMin.Name = "num_EffortsMin";
            this.num_EffortsMin.Size = new System.Drawing.Size(60, 20);
            this.num_EffortsMin.TabIndex = 40;
            // 
            // num_EffortsHours
            // 
            this.num_EffortsHours.Location = new System.Drawing.Point(89, 126);
            this.num_EffortsHours.Name = "num_EffortsHours";
            this.num_EffortsHours.Size = new System.Drawing.Size(60, 20);
            this.num_EffortsHours.TabIndex = 39;
            // 
            // dtp_DueDate
            // 
            this.dtp_DueDate.CustomFormat = "ddd dd MMM yyyy        HH:mm:ss";
            this.dtp_DueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DueDate.Location = new System.Drawing.Point(89, 100);
            this.dtp_DueDate.Name = "dtp_DueDate";
            this.dtp_DueDate.Size = new System.Drawing.Size(214, 20);
            this.dtp_DueDate.TabIndex = 38;
            // 
            // tbx_ProjectName
            // 
            this.tbx_ProjectName.Location = new System.Drawing.Point(89, 74);
            this.tbx_ProjectName.Name = "tbx_ProjectName";
            this.tbx_ProjectName.Size = new System.Drawing.Size(214, 20);
            this.tbx_ProjectName.TabIndex = 37;
            // 
            // cbx_IsToDo
            // 
            this.cbx_IsToDo.AutoSize = true;
            this.cbx_IsToDo.Location = new System.Drawing.Point(89, 50);
            this.cbx_IsToDo.Name = "cbx_IsToDo";
            this.cbx_IsToDo.Size = new System.Drawing.Size(15, 14);
            this.cbx_IsToDo.TabIndex = 36;
            this.cbx_IsToDo.UseVisualStyleBackColor = true;
            // 
            // tbx_Title
            // 
            this.tbx_Title.Location = new System.Drawing.Point(89, 22);
            this.tbx_Title.Name = "tbx_Title";
            this.tbx_Title.Size = new System.Drawing.Size(214, 20);
            this.tbx_Title.TabIndex = 35;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 155);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 13);
            this.label20.TabIndex = 34;
            this.label20.Text = "Budget:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 13);
            this.label21.TabIndex = 33;
            this.label21.Text = "Duration:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 102);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 13);
            this.label22.TabIndex = 32;
            this.label22.Text = "Due Date:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 77);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 13);
            this.label23.TabIndex = 31;
            this.label23.Text = "Project:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(184, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "Priority:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 50);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(51, 13);
            this.label25.TabIndex = 29;
            this.label25.Text = "Is To-Do:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 25);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 13);
            this.label26.TabIndex = 28;
            this.label26.Text = "Title:";
            // 
            // num_TotalCosts
            // 
            this.num_TotalCosts.DecimalPlaces = 2;
            this.num_TotalCosts.Location = new System.Drawing.Point(416, 152);
            this.num_TotalCosts.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num_TotalCosts.Name = "num_TotalCosts";
            this.num_TotalCosts.Size = new System.Drawing.Size(201, 20);
            this.num_TotalCosts.TabIndex = 54;
            // 
            // num_Budget
            // 
            this.num_Budget.DecimalPlaces = 2;
            this.num_Budget.Location = new System.Drawing.Point(89, 152);
            this.num_Budget.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num_Budget.Name = "num_Budget";
            this.num_Budget.Size = new System.Drawing.Size(214, 20);
            this.num_Budget.TabIndex = 55;
            // 
            // uc_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 510);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "uc_Task";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Subtasks)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Priority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_EffortsMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_EffortsHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_TotalCosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Budget)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtp_Modified;
        private System.Windows.Forms.DateTimePicker dtp_Created;
        private System.Windows.Forms.TextBox tbx_ModifiedBy;
        private System.Windows.Forms.TextBox tbx_CreatedBy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgw_Subtasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budget;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentCosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Progress;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar pbr_Progress;
        private System.Windows.Forms.Button btn_ChangeOwner;
        private System.Windows.Forms.TextBox tbx_Owner;
        private System.Windows.Forms.TextBox tbx_Description;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown num_Priority;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown num_EffortsMin;
        private System.Windows.Forms.NumericUpDown num_EffortsHours;
        private System.Windows.Forms.DateTimePicker dtp_DueDate;
        private System.Windows.Forms.TextBox tbx_ProjectName;
        private System.Windows.Forms.CheckBox cbx_IsToDo;
        private System.Windows.Forms.TextBox tbx_Title;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown num_TotalCosts;
        private System.Windows.Forms.NumericUpDown num_Budget;
    }
}
