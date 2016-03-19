namespace PlexByte.MoCap.WinForms.UserControls
{
    partial class uc_Overview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Overview));
            this.dgw_Recent = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupbox2 = new System.Windows.Forms.GroupBox();
            this.dgw_Project = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InteractionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewImageColumn();
            this.ModifiedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Recent)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupbox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Project)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw_Recent
            // 
            this.dgw_Recent.AllowUserToAddRows = false;
            this.dgw_Recent.AllowUserToDeleteRows = false;
            this.dgw_Recent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_Recent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Type,
            this.InteractionName,
            this.State,
            this.ModifiedDateTime});
            this.dgw_Recent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw_Recent.Location = new System.Drawing.Point(3, 16);
            this.dgw_Recent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgw_Recent.MultiSelect = false;
            this.dgw_Recent.Name = "dgw_Recent";
            this.dgw_Recent.ReadOnly = true;
            this.dgw_Recent.RowHeadersVisible = false;
            this.dgw_Recent.Size = new System.Drawing.Size(509, 203);
            this.dgw_Recent.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgw_Recent);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 222);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recently Changed Objects";
            // 
            // groupbox2
            // 
            this.groupbox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox2.Controls.Add(this.dgw_Project);
            this.groupbox2.Location = new System.Drawing.Point(4, 232);
            this.groupbox2.Name = "groupbox2";
            this.groupbox2.Size = new System.Drawing.Size(515, 222);
            this.groupbox2.TabIndex = 2;
            this.groupbox2.TabStop = false;
            this.groupbox2.Text = "Assigned Projects";
            // 
            // dgw_Project
            // 
            this.dgw_Project.AllowUserToAddRows = false;
            this.dgw_Project.AllowUserToDeleteRows = false;
            this.dgw_Project.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_Project.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectName,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn4});
            this.dgw_Project.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw_Project.Location = new System.Drawing.Point(3, 16);
            this.dgw_Project.Margin = new System.Windows.Forms.Padding(2);
            this.dgw_Project.MultiSelect = false;
            this.dgw_Project.Name = "dgw_Project";
            this.dgw_Project.ReadOnly = true;
            this.dgw_Project.RowHeadersVisible = false;
            this.dgw_Project.Size = new System.Drawing.Size(509, 203);
            this.dgw_Project.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 20;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 70;
            // 
            // InteractionName
            // 
            this.InteractionName.HeaderText = "Name";
            this.InteractionName.Name = "InteractionName";
            this.InteractionName.ReadOnly = true;
            this.InteractionName.Width = 150;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 50;
            // 
            // ModifiedDateTime
            // 
            this.ModifiedDateTime.HeaderText = "Modified";
            this.ModifiedDateTime.Name = "ModifiedDateTime";
            this.ModifiedDateTime.ReadOnly = true;
            // 
            // ProjectName
            // 
            this.ProjectName.HeaderText = "Id";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            this.ProjectName.Width = 20;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "State";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Modified";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // uc_Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 454);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.groupbox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "uc_Overview";
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Recent)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupbox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_Project)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgw_Recent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn InteractionName;
        private System.Windows.Forms.DataGridViewImageColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedDateTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupbox2;
        private System.Windows.Forms.DataGridView dgw_Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
