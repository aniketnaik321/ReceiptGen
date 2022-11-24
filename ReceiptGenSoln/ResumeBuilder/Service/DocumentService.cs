using Aspose.Words.Saving;
using ResumeBuilder.DTO;
using ResumeBuilder.Infrastructure;
using System;
using System.Collections.Generic;
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

        public void TranslateDocxToPdf(string sourcePath,string targetPath) {        
            Aspose.Words.Document document = new Aspose.Words.Document(sourcePath);
            document.Save(targetPath);
        }


        public string FillupTemplate(string templatePath, int templateId,ResumeDataWrapper data) {

            string pdfPath=string.Empty;
            using (var document = DocX.Load(templatePath))
            {
                foreach (var substituted in _placeHolders.GetList())
                {
                    document.ReplaceText(substituted.Placeholder, EtyService.GetPropValue(data.resumeData, substituted.Field));
                }
                // Save this document to disk.
                document.SaveAs(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.docx");
                Aspose.Words.Document document1 = new Aspose.Words.Document(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.docx");
                // Provide PDFSaveOption compliance to PDF17
                // or just convert without SaveOptions
                PdfSaveOptions pso = new PdfSaveOptions();
                pso.Compliance = PdfCompliance.Pdf17;

                document1.Save(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.pdf", pso);
                return Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.pdf";
            }
        }
    }
}
