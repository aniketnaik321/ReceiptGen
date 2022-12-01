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

        
        public MemoryStream FillupTemplate(
            string templatePath, 
            int templateId,
            ResumeDataWrapper data,
            out MemoryStream doc) {

            string pdfPath=string.Empty;
            Spire.Doc.Document document1;
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
           
                foreach (var p in document.Paragraphs)
                {
                    // Gets the paragraph's charts.
                  //  var charts = p.Charts;
                    //if (charts.Count > 0)
                    //{
                    //    // Gets the first chart's first serie's values (in Y).
                    //    var numbers = charts[0].Series[0].Values;
                    //    // Modify the third value from 2 to 6.
                    //    numbers[2] = "6";
                    //    // Add a new value.
                    //    numbers.Add("3");
                    //    // Update the first chart's first serie's values with the new one.
                    //    charts[0].Series[0].Values = numbers;
                    //    // Gets the first chart's first serie's categories (in X).
                    //    var categories = charts[0].Series[0].Categories;
                    //    // Modify the second category from Canada to Russia.
                    //    categories[1] = "Russia";
                    //    // Add a new category.
                    //    categories.Add("Italia");
                    //    // Update the first chart's first serie's categories with the new one.
                    //    charts[0].Series[0].Categories = categories;
                    //    // Modify first chart's first serie's color from Blue to Gold.
                    //    charts[0].Series[0].Color = Color.Gold;
                    //    // Remove the legend.
                    //    charts[0].RemoveLegend();

                    //    // Save the changes in the first chart.
                    //    charts[0].Save();
                    //}
                }

                // Insert chart into document
                document.InsertParagraph("Expenses(M$) for selected categories per country").FontSize(15).SpacingAfter(10d);
            //document.InsertChart(c);

            // Save this document to disk.
            //document.SaveAs(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.docx");
            // Aspose.Words.Document document1 = new Aspose.Words.Document(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.docx");

            using (MemoryStream ms = new MemoryStream()) { 
                    document.SaveAs(ms);
                    document.SaveAs(doc);
                    document1= new Spire.Doc.Document(ms);
                    document1.SaveToStream(resultStream,Spire.Doc.FileFormat.PDF);                }
              
                
               
                //document1.Save(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.pdf", pso);
                return resultStream;
            
        }
    }
}
