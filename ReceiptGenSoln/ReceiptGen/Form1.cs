using CrystalDecisions.CrystalReports.ViewerObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Color = System.Drawing.Color;

namespace ReceiptGen
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.WhiteSmoke;
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReceipt frmReceipt = new FrmReceipt();
            frmReceipt.MdiParent = this;
            frmReceipt.StartPosition = FormStartPosition.CenterParent;
            frmReceipt.WindowState= FormWindowState.Maximized;
            frmReceipt.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //   receiptToolStripMenuItem_Click(sender, e);

            //using (WordprocessingDocument doc = WordprocessingDocument.Open("document.docx", true))
            //{
            //    // Find the paragraph element to clone
            //    Paragraph originalParagraph = doc.MainDocumentPart.Document.Body.Descendants<Paragraph>().Where(p => p.InnerText == "Original paragraph").FirstOrDefault();
            //    if (originalParagraph != null)
            //    {
            //        // Clone the paragraph element
            //        XmlDocument xmlDoc = new XmlDocument();
            //        XmlElement clonedParagraph = (XmlElement)xmlDoc.ImportNode(originalParagraph.OuterXml, true);

            //        // Insert the cloned paragraph after the original
            //        originalParagraph.Sibling.InsertAfter(clonedParagraph, originalParagraph);

            //        // Save the modified document
            //        doc.Save();
            //    }
            //}



        }



        private void CloneParagraph() { 
        
        }


        private void ReplaceTextFromParagraph() {


            // Load the Word document
            using (WordprocessingDocument doc = WordprocessingDocument.Open("document.docx", true))
            {
                // Find the paragraph containing the text to replace
                Paragraph paragraph = doc.MainDocumentPart.Document.Body.Descendants<Paragraph>().Where(p => p.InnerText.Contains("Original text")).FirstOrDefault();
                if (paragraph != null)
                {
                    // Find the Text element within the paragraph
                    Text textToReplace = paragraph.Descendants<Text>().Where(t => t.Text.Contains("Original text")).FirstOrDefault();
                    if (textToReplace != null)
                    {
                        // Replace the text
                        textToReplace.Text = "Replacement text";
                    }
                }
            }
        }






    }
}
