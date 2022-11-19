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
            this.btnAddEducation = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // btnAddEducation
            // 
            this.btnAddEducation.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddEducation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEducation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEducation.ForeColor = System.Drawing.Color.White;
            this.btnAddEducation.Image = global::ResumeBuilder.Properties.Resources.download;
            this.btnAddEducation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEducation.Location = new System.Drawing.Point(12, 3);
            this.btnAddEducation.Name = "btnAddEducation";
            this.btnAddEducation.Size = new System.Drawing.Size(150, 34);
            this.btnAddEducation.TabIndex = 2;
            this.btnAddEducation.Text = "&Export PDF";
            this.btnAddEducation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddEducation.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::ResumeBuilder.Properties.Resources.download;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(168, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "E&xport DOCX";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FrmResumePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddEducation);
            this.Controls.Add(this.PreviewPanel);
            this.Name = "FrmResumePreview";
            this.Text = "Resume Preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmResumePreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PreviewPanel;
        private System.Windows.Forms.Button btnAddEducation;
        private System.Windows.Forms.Button button1;
    }
}