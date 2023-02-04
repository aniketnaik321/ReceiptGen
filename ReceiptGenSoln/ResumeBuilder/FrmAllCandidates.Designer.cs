namespace ResumeBuilder
{
    partial class FrmAllCandidates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvCandidateDetails = new System.Windows.Forms.DataGridView();
            this.btnExportTOPDF = new System.Windows.Forms.Button();
            this.btnExportToDocX = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidateDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Highlight;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1125, 62);
            this.label9.TabIndex = 70;
            this.label9.Text = "CANDIDATE LIST";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCandidateDetails
            // 
            this.dgvCandidateDetails.AllowUserToAddRows = false;
            this.dgvCandidateDetails.AllowUserToDeleteRows = false;
            this.dgvCandidateDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCandidateDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCandidateDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandidateDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column6,
            this.Column3,
            this.Column4,
            this.Column2,
            this.Column1,
            this.Column5});
            this.dgvCandidateDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCandidateDetails.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgvCandidateDetails.Location = new System.Drawing.Point(0, 62);
            this.dgvCandidateDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCandidateDetails.Name = "dgvCandidateDetails";
            this.dgvCandidateDetails.ReadOnly = true;
            this.dgvCandidateDetails.RowHeadersWidth = 51;
            this.dgvCandidateDetails.RowTemplate.Height = 24;
            this.dgvCandidateDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCandidateDetails.Size = new System.Drawing.Size(1125, 747);
            this.dgvCandidateDetails.TabIndex = 71;
            this.dgvCandidateDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCandidateDetails_CellContentClick);
            // 
            // btnExportTOPDF
            // 
            this.btnExportTOPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportTOPDF.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportTOPDF.FlatAppearance.BorderSize = 0;
            this.btnExportTOPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportTOPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportTOPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportTOPDF.Location = new System.Drawing.Point(412, 13);
            this.btnExportTOPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportTOPDF.Name = "btnExportTOPDF";
            this.btnExportTOPDF.Size = new System.Drawing.Size(177, 36);
            this.btnExportTOPDF.TabIndex = 72;
            this.btnExportTOPDF.Text = "&EXPORT AS PDF";
            this.btnExportTOPDF.UseVisualStyleBackColor = false;
            // 
            // btnExportToDocX
            // 
            this.btnExportToDocX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToDocX.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportToDocX.FlatAppearance.BorderSize = 0;
            this.btnExportToDocX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToDocX.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToDocX.ForeColor = System.Drawing.Color.White;
            this.btnExportToDocX.Location = new System.Drawing.Point(596, 13);
            this.btnExportToDocX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportToDocX.Name = "btnExportToDocX";
            this.btnExportToDocX.Size = new System.Drawing.Size(176, 36);
            this.btnExportToDocX.TabIndex = 72;
            this.btnExportToDocX.Text = "E&XPORT AS DOCX";
            this.btnExportToDocX.UseVisualStyleBackColor = false;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseForm.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCloseForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::ResumeBuilder.Properties.Resources.icons8_cancel_30;
            this.btnCloseForm.Location = new System.Drawing.Point(1069, 0);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(56, 59);
            this.btnCloseForm.TabIndex = 73;
            this.btnCloseForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(855, 13);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(176, 36);
            this.btnNew.TabIndex = 72;
            this.btnNew.Text = "&NEW CANDIDATE";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Candidate Name";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Contact No.";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(1);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Address";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Email";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "edit";
            this.Column1.ToolTipText = "edit";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 50;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.HeaderText = "";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Text = "resume";
            this.Column5.UseColumnTextForButtonValue = true;
            this.Column5.Width = 56;
            // 
            // FrmAllCandidates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 809);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnExportToDocX);
            this.Controls.Add(this.btnExportTOPDF);
            this.Controls.Add(this.dgvCandidateDetails);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAllCandidates";
            this.Text = "Candidates";
            this.Load += new System.EventHandler(this.FrmAllCandidates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidateDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCandidateDetails;
        private System.Windows.Forms.Button btnExportTOPDF;
        private System.Windows.Forms.Button btnExportToDocX;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}