using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the document
            Document document = new Document();
            document.LoadFromFile("C:\\Users\\anike\\OneDrive\\Desktop\\Resume.docx");

            // Get the paragraph to be cloned
            Paragraph originalParagraph = document.Sections[0].Paragraphs[15];

            MessageBox.Show(document.Sections[0].Paragraphs.Count.ToString());
            // Clone the paragraph
            Paragraph clonedParagraph = (Paragraph)originalParagraph.Clone();

            // Add the cloned paragraph to the document
            document.Sections[0].Paragraphs.Insert(15,clonedParagraph);

            // Save the document
            document.SaveToFile("C:\\Users\\anike\\OneDrive\\Desktop\\Resumeout.docx", FileFormat.Docx);
        }
    }
}
