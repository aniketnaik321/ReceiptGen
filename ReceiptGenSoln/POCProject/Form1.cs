using Avalonia.Controls;
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

            List<Paragraph> originalParagraph=new List<Paragraph>();
            string tag = "<prj>";
            TextSelection[] skillsSelection = document.FindAllString("<prj>", true, true);


            // Search for the string
            //string searchString = "<prj>";
            //FindReplaceOptions options = new FindReplaceOptions();
            //options.MatchCase = true;
            //options.MatchWholeWord = true;
            //FindReplaceResult result = doc.Find(searchString, options);

            foreach (var item in skillsSelection)
            {
                TextRange text = item.GetAsOneRange();               
                originalParagraph.Add(text.OwnerParagraph);
                
            }                               
            

            // Get the paragraph to be cloned
            // originalParagraph = document.Sections[0].Paragraphs[15];

            // MessageBox.Show(document.Sections[0].Paragraphs.IndexOf(originalParagraph).ToString());
            // Clone the paragraph
           
            for (int i = 0; i < 5; i++)
            {
                List<Paragraph> clonedParagraphs = new List<Paragraph>();
                foreach (Paragraph paragraph in originalParagraph)
                {
                    clonedParagraphs.Add((Paragraph)paragraph.Clone());
                }
                clonedParagraphs.Reverse();
                foreach (Paragraph clonedParagraph in clonedParagraphs)
                {
                    clonedParagraph.Replace("#spec#", "Diploma in Graphics Engineering"+i, false, false);
                    clonedParagraph.Replace(tag, string.Empty, false, false);
                    // Add the cloned paragraph to the document
                    document.Sections[0].Paragraphs.Insert(15, clonedParagraph);
                }
            }
            
            foreach (var item in originalParagraph)
            {
                document.Sections[0].Body.Paragraphs.Remove(item);
            }
           ///

            // Save the document
            document.SaveToFile("C:\\Users\\anike\\OneDrive\\Desktop\\Resumeout.docx", FileFormat.Docx);
        }
    }
}
