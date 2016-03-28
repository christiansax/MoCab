namespace PlexByte.MoCap.WinForms.UserControls
{
    partial class uc_Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Account));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_TotalCost = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.dgv_Tasks = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Budget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BudgetUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInvested = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_User = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseInProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInvestedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInvestedInProcent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tasks)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbx_TotalCost);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(833, 63);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // tbx_TotalCost
            // 
            this.tbx_TotalCost.Location = new System.Drawing.Point(119, 22);
            this.tbx_TotalCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_TotalCost.Name = "tbx_TotalCost";
            this.tbx_TotalCost.Size = new System.Drawing.Size(284, 22);
            this.tbx_TotalCost.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 22);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 54;
            this.label11.Text = "Total Cost:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_Update);
            this.groupBox2.Controls.Add(this.dgv_Tasks);
            this.groupBox2.Location = new System.Drawing.Point(16, 76);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(833, 238);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tasks";
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Update.Enabled = false;
            this.btn_Update.Location = new System.Drawing.Point(8, 194);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(133, 34);
            this.btn_Update.TabIndex = 29;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
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
            this.Owner,
            this.Budget,
            this.BudgetUsed,
            this.TimeInvested});
            this.dgv_Tasks.Location = new System.Drawing.Point(8, 26);
            this.dgv_Tasks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.dgv_Tasks.Size = new System.Drawing.Size(813, 160);
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
            this.Title.Width = 73;
            // 
            // Owner
            // 
            this.Owner.HeaderText = "Owner";
            this.Owner.Name = "Owner";
            this.Owner.ReadOnly = true;
            // 
            // Budget
            // 
            this.Budget.HeaderText = "Budget";
            this.Budget.Name = "Budget";
            this.Budget.ReadOnly = true;
            this.Budget.Width = 67;
            // 
            // BudgetUsed
            // 
            this.BudgetUsed.HeaderText = "Budget Used";
            this.BudgetUsed.Name = "BudgetUsed";
            this.BudgetUsed.ReadOnly = true;
            this.BudgetUsed.Width = 150;
            // 
            // TimeInvested
            // 
            this.TimeInvested.HeaderText = "Time invested";
            this.TimeInvested.Name = "TimeInvested";
            this.TimeInvested.ReadOnly = true;
            this.TimeInvested.Width = 150;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgv_User);
            this.groupBox3.Location = new System.Drawing.Point(16, 314);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(833, 222);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User";
            // 
            // dgv_User
            // 
            this.dgv_User.AllowUserToAddRows = false;
            this.dgv_User.AllowUserToDeleteRows = false;
            this.dgv_User.AllowUserToOrderColumns = true;
            this.dgv_User.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_User.ColumnHeadersHeight = 20;
            this.dgv_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.ExpenseInProject,
            this.TimeInvestedUser,
            this.TimeInvestedInProcent});
            this.dgv_User.Location = new System.Drawing.Point(8, 26);
            this.dgv_User.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_User.MultiSelect = false;
            this.dgv_User.Name = "dgv_User";
            this.dgv_User.ReadOnly = true;
            this.dgv_User.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_User.RowHeadersVisible = false;
            this.dgv_User.RowTemplate.Height = 15;
            this.dgv_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_User.ShowCellErrors = false;
            this.dgv_User.ShowCellToolTips = false;
            this.dgv_User.ShowEditingIcon = false;
            this.dgv_User.ShowRowErrors = false;
            this.dgv_User.Size = new System.Drawing.Size(813, 188);
            this.dgv_User.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "User";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Expense";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 67;
            // 
            // ExpenseInProject
            // 
            this.ExpenseInProject.HeaderText = "Expense in Project(%)";
            this.ExpenseInProject.Name = "ExpenseInProject";
            this.ExpenseInProject.ReadOnly = true;
            this.ExpenseInProject.Width = 200;
            // 
            // TimeInvestedUser
            // 
            this.TimeInvestedUser.HeaderText = "Time Invested";
            this.TimeInvestedUser.Name = "TimeInvestedUser";
            this.TimeInvestedUser.ReadOnly = true;
            this.TimeInvestedUser.Width = 90;
            // 
            // TimeInvestedInProcent
            // 
            this.TimeInvestedInProcent.HeaderText = "Time Invested (%)";
            this.TimeInvestedInProcent.Name = "TimeInvestedInProcent";
            this.TimeInvestedInProcent.ReadOnly = true;
            this.TimeInvestedInProcent.Width = 150;
            // 
            // uc_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 539);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "uc_Account";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tasks)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_TotalCost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_Tasks;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budget;
        private System.Windows.Forms.DataGridViewTextBoxColumn BudgetUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInvested;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInvestedInProcent;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInvestedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseInProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btn_Update;
    }
}