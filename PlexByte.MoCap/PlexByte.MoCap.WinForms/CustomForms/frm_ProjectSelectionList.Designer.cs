namespace PlexByte.MoCap.WinForms.CustomForms
{
    partial class frm_ProjectSelectionList
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
            this.dgw_Projects = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Projects)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgw_Projects);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 218);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Projects";
            // 
            // dgw_Projects
            // 
            this.dgw_Projects.AllowUserToAddRows = false;
            this.dgw_Projects.AllowUserToDeleteRows = false;
            this.dgw_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_Projects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_Projects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ProjectName,
            this.State,
            this.StartDate,
            this.EndDate});
            this.dgw_Projects.Location = new System.Drawing.Point(7, 20);
            this.dgw_Projects.MultiSelect = false;
            this.dgw_Projects.Name = "dgw_Projects";
            this.dgw_Projects.ReadOnly = true;
            this.dgw_Projects.RowHeadersVisible = false;
            this.dgw_Projects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_Projects.Size = new System.Drawing.Size(593, 192);
            this.dgw_Projects.TabIndex = 0;
            this.dgw_Projects.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgw_Projects_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 238);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(630, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // ProjectName
            // 
            this.ProjectName.HeaderText = "Name";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "End Date";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // frm_ProjectSelectionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 260);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_ProjectSelectionList";
            this.Text = "Project List";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Projects)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgw_Projects;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
    }
}