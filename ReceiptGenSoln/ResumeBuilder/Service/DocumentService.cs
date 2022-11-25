using Aspose.Words.Saving;
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
using Xceed.Words.NET;

namespace ResumeBuilder.Service
{
    public class DocumentService
    {

        IEntityOperations<DtoPlaceholder> _placeHolders;
        public DocumentService() { 
        _placeHolders=new EntityOperations<DtoPlaceholder>();
        }

        public MemoryStream FillupTemplate(string templatePath, 
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
                    document.ReplaceText(substituted.Placeholder, EtyService.GetPropValue(data.resumeData, substituted.Field));
                }
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
