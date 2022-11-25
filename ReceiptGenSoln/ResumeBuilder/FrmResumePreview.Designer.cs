namespace ResumeBuilder
{
    partial class FrmResumePreview
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
            this.PreviewPanel = new System.Windows.Forms.Panel();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportDocx = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // PreviewPanel
            // 
            this.PreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewPanel.BackColor = System.Drawing.Color.White;
            this.PreviewPanel.Location = new System.Drawing.Point(4, 43);
            this.PreviewPanel.Name = "PreviewPanel";
            this.PreviewPanel.Size = new System.Drawing.Size(792, 407);
            this.PreviewPanel.TabIndex = 0;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Location = new System.Drawing.Point(12, 3);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(150, 34);
            this.btnExportPDF.TabIndex = 2;
            this.btnExportPDF.Text = "&Export PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnExportDocx
            // 
            this.btnExportDocx.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportDocx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportDocx.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportDocx.ForeColor = System.Drawing.Color.White;
            this.btnExportDocx.Location = new System.Drawing.Point(168, 3);
            this.btnExportDocx.Name = "btnExportDocx";
            this.btnExportDocx.Size = new System.Drawing.Size(150, 34);
            this.btnExportDocx.TabIndex = 2;
            this.btnExportDocx.Text = "E&xport DOCX";
            this.btnExportDocx.UseVisualStyleBackColor = false;
            this.btnExportDocx.Click += new System.EventHandler(this.btnExportDocx_Click);
            // 
            // FrmResumePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportDocx);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.PreviewPanel);
            this.Name = "FrmResumePreview";
            this.Text = "Resume Preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmResumePreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PreviewPanel;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportDocx;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}