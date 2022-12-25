using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Pdf.Exporting.XPS.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paragraph = Spire.Doc.Documents.Paragraph;

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

            Paragraph originalParagraph=null;


            TextSelection skillsSelection = document.FindString("<edu>", true, true);
            if (skillsSelection != null)
            {
                TextRange text = skillsSelection.GetAsOneRange();
                originalParagraph = text.OwnerParagraph;
            }


            // Get the paragraph to be cloned
            // originalParagraph = document.Sections[0].Paragraphs[15];

            MessageBox.Show(document.Sections[0].Paragraphs.IndexOf(originalParagraph).ToString());
            // Clone the paragraph
            Paragraph clonedParagraph = (Paragraph)originalParagraph.Clone();
            clonedParagraph.Replace("#spec#", "Diploma in Graphics Engineering", false, false);
            // Add the cloned paragraph to the document
            document.Sections[0].Paragraphs.Insert(15, clonedParagraph);

            document.Sections[0].Body.Paragraphs.Remove(originalParagraph);



            // Save the document
            document.SaveToFile("C:\\Users\\anike\\OneDrive\\Desktop\\Resumeout.docx", FileFormat.Docx);
        }
    }
}
