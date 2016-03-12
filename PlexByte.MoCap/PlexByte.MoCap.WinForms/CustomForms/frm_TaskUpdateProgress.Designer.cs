namespace PlexByte.MoCap.WinForms.CustomForms
{
    partial class frm_TaskUpdateProgress
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
            this.label1 = new System.Windows.Forms.Label();
            this.num_Progress = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.num_Time = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_UpdateOnTime = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.num_Value = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Invoice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Progress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Value)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Progress:";
            // 
            // num_Progress
            // 
            this.num_Progress.Location = new System.Drawing.Point(84, 46);
            this.num_Progress.Name = "num_Progress";
            this.num_Progress.Size = new System.Drawing.Size(68, 20);
            this.num_Progress.TabIndex = 1;
            this.num_Progress.ValueChanged += new System.EventHandler(this.num_Progress_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Time:";
            // 
            // num_Time
            // 
            this.num_Time.Location = new System.Drawing.Point(84, 72);
            this.num_Time.Name = "num_Time";
            this.num_Time.Size = new System.Drawing.Size(68, 20);
            this.num_Time.TabIndex = 4;
            this.num_Time.ValueChanged += new System.EventHandler(this.num_Time_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "min";
            // 
            // cbx_UpdateOnTime
            // 
            this.cbx_UpdateOnTime.AutoSize = true;
            this.cbx_UpdateOnTime.Location = new System.Drawing.Point(84, 98);
            this.cbx_UpdateOnTime.Name = "cbx_UpdateOnTime";
            this.cbx_UpdateOnTime.Size = new System.Drawing.Size(162, 17);
            this.cbx_UpdateOnTime.TabIndex = 6;
            this.cbx_UpdateOnTime.Text = "Update Progress accordingly";
            this.cbx_UpdateOnTime.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Task:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "lbl_Task";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Project:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "lbl_Project";
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.Location = new System.Drawing.Point(261, 69);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 11;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            // 
            // btn_Update
            // 
            this.btn_Update.Enabled = false;
            this.btn_Update.Location = new System.Drawing.Point(261, 43);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 12;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Expense:";
            // 
            // num_Value
            // 
            this.num_Value.DecimalPlaces = 2;
            this.num_Value.Location = new System.Drawing.Point(84, 121);
            this.num_Value.Name = "num_Value";
            this.num_Value.Size = new System.Drawing.Size(68, 20);
            this.num_Value.TabIndex = 14;
            this.num_Value.ValueChanged += new System.EventHandler(this.num_Value_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "$";
            // 
            // btn_Invoice
            // 
            this.btn_Invoice.Enabled = false;
            this.btn_Invoice.Location = new System.Drawing.Point(261, 118);
            this.btn_Invoice.Name = "btn_Invoice";
            this.btn_Invoice.Size = new System.Drawing.Size(75, 23);
            this.btn_Invoice.TabIndex = 16;
            this.btn_Invoice.Text = "Invoice";
            this.btn_Invoice.UseVisualStyleBackColor = true;
            // 
            // frm_TaskUpdateProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 159);
            this.Controls.Add(this.btn_Invoice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.num_Value);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_UpdateOnTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.num_Time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_Progress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_TaskUpdateProgress";
            this.Text = "Update Task";
            ((System.ComponentModel.ISupportInitialize)(this.num_Progress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_Progress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbx_UpdateOnTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_Value;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Invoice;
    }
}