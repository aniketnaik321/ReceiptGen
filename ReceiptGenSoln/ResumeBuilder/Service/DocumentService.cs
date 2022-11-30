using Aspose.Words.Saving;
//using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using ResumeBuilder.DTO;
using ResumeBuilder.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Series = Xceed.Document.NET.Series;

namespace ResumeBuilder.Service
{
    public class DocumentService
    {

        IEntityOperations<DtoPlaceholder> _placeHolders;
        public DocumentService() { 
        _placeHolders=new EntityOperations<DtoPlaceholder>();
        }

        [Obsolete]
        public MemoryStream FillupTemplate(
            string templatePath, 
            int templateId,
            ResumeDataWrapper data,
            out MemoryStream doc) {

            string pdfPath=string.Empty;
            Aspose.Words.Document document1;
            PdfSaveOptions pso = new PdfSaveOptions();
            pso.Compliance = PdfCompliance.Pdf17;
            MemoryStream resultStream=new MemoryStream ();
            doc = new MemoryStream ();
            var document = DocX.Load(templatePath);
            
                foreach (var substituted in _placeHolders.GetList())
                {
                switch (substituted.Type) {

                    case "List":
                        var bulletedList = document.AddList("First list item", 0, ListItemType.Bulleted);
                        document.AddListItem(bulletedList, "Second list item");
                        List<Paragraph> actualListData = bulletedList.Items;

                        foreach (var paragraph in document.Paragraphs)
                            if (paragraph.Text.Contains(substituted.Placeholder))
                            {
                                foreach (var listParagraph in actualListData)
                                    paragraph.InsertListBeforeSelf(bulletedList);
                                document.ReplaceText(substituted.Placeholder,string.Empty);
                            }

                        break;

                    case "Chart":

                       
                        //c.AddLegend(ChartLegendPosition.Left, false);
                        // Create the data.
                       
                        break;
                    case "Default":
                        document.ReplaceText(substituted.Placeholder,
                        EtyService.GetPropValue(data.resumeData, substituted.Field));
                        break;
                }
                      
                }
            var c = new BarChart();
            var canada = new List<ChartData>()
                            {
                              new ChartData() { Category = "Food", Expenses = 100 },
                              new ChartData() { Category = "Housing", Expenses = 120 },
                              new ChartData() { Category = "Transportation", Expenses = 140 },
                              new ChartData() { Category = "Health Care", Expenses = 150 }
                            };

            // Insert chart into document
            document.InsertParagraph("Expenses(M$) for selected categories per country").FontSize(15).SpacingAfter(10d);
            document.InsertChart(c);

            // Save this document to disk.
            //document.SaveAs(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.docx");
            // Aspose.Words.Document document1 = new Aspose.Words.Document(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.docx");

            using (MemoryStream ms = new MemoryStream()) { 
                    document.SaveAs(ms);
                    document.SaveAs(doc);
                    document1=new Aspose.Words.Document(ms);
                    document1.Save(resultStream,pso);
                }
              
                // Provide PDFSaveOption compliance to PDF17
                // or just convert without SaveOptions
               
                //document1.Save(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.pdf", pso);
                return resultStream;
            
        }
    }
}
