using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using Newtonsoft.Json;
using ResumeBuilder.DTO;
using ResumeBuilder.Infrastructure;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBox = Spire.Doc.Fields.TextBox;

namespace ResumeBuilder.Service
{
    public class DocumentService
    {
        IEntityOperations<DtoPlaceholder> _placeHolders;
        private Document document1;
        public DocumentService()
        {
            _placeHolders = new EntityOperations<DtoPlaceholder>();
        }

        public MemoryStream FillupTemplate(
            string templatePath,
            DtoResumeTemplate template,
            ResumeDataWrapper data,
            out MemoryStream doc)
        {
            string pdfPath = string.Empty;
            Document document = new Document();

            document.LoadFromFile(templatePath);
            MemoryStream resultStream = new MemoryStream();
            doc = new MemoryStream();
            //var document = DocX.Load(templatePath);

            foreach (var substituted in _placeHolders.GetList())
            {
                switch (substituted.Type)
                {
                    case "List":
                        TextSelection selection = document.FindString(substituted.Placeholder, true, true);
                        if (selection != null)
                        {
                            TextRange text = selection.GetAsOneRange();
                            Paragraph p = text.OwnerParagraph;
                            text.Text = EtyService.GetPropValue(data.resumeData, substituted.Field);
                            p.ListFormat.ContinueListNumbering();
                        }
                        break;

                    case "SkillsList":
                        TextSelection skillsSelection = document.FindString(substituted.Placeholder, true, true);
                        if (skillsSelection != null)
                        {
                            TextRange text = skillsSelection.GetAsOneRange();
                            Paragraph p = text.OwnerParagraph;
                            text.Text = string.Empty;
                            foreach (var tmpSkill in data.skillDetails) {                             
                                    text.Text+=tmpSkill.SkillName+ " (Experince:"+tmpSkill.SkillExperience + "   Level:"+GetSkillLevel(tmpSkill.SkillRating.ToString())+ ")\n";
                            }
                            if (!string.IsNullOrEmpty(text.Text)) 
                            text.Text= text.Text.Remove(text.Text.Length - 1, 1);
                            p.ListFormat.ContinueListNumbering();
                        }
                        break;

                    case "Chart":
                        //c.AddLegend(ChartLegendPosition.Left, false);
                        // Create the data.

                        break;

                    case "Photo":
                        TextSelection photoPlaceholder = document.FindString(substituted.Placeholder, true, true);
                        if (photoPlaceholder != null )
                        {
                            TextRange text = photoPlaceholder.GetAsOneRange();
                            Paragraph p = text.OwnerParagraph;
                            p.Format.TextAlignment = TextAlignment.Center;
                            text.Text = string.Empty;
                            if (data.resumeData.CandidatePhoto != null)
                            {
                                DocPicture pic = p.AppendPicture(System.Convert.FromBase64String(data.resumeData.CandidatePhoto));
                                pic.Height = 100f;
                                pic.Width = 75f;
                            }
                        }
                        break;                       
                    case "EducationList":
                        TextSelection eduSelection = document.FindString(substituted.Placeholder, true, true);
                        if (eduSelection != null)
                        {
                            TextRange text = eduSelection.GetAsOneRange();
                            //TextRange titleText = new TextRange(document);
                            //titleText.CharacterFormat.FontName = "Arial";
                            
                            Paragraph p = text.OwnerParagraph;                            
                            text.Text = string.Empty;
                          //  p.AppendRTF(File.ReadAllText("C:\\Users\\anike\\OneDrive\\Desktop\\Document.rtf"),false);
                           foreach (var tempEdu in data.EducationData) {
                                p.AppendHTML("<p style='margin-top:10px;font-size:"+template.TextFontSize+"pt;color:black'>Completed <b>"+tempEdu.Specification+"</b> from <b>"+
                                    tempEdu.University+"</b> dated from "+tempEdu.FromDate+" to "+tempEdu.ToDate+" with <b>"+tempEdu.PercentData+" of marks.</b> </p>");
                                p.AppendBreak(BreakType.LineBreak);
                               // p.AppendBreak(BreakType.LineBreak);                                
                                //text.Text+= tempEdu.Specification+"\t"+ tempEdu.University + "\r\n";
                            }
                            p.ListFormat.ContinueListNumbering();
                        }
                        break;

                    case "EduPara":
                    case "PrjPara":
                    case "ExpPara":
                        List<Paragraph> originalEduParagraph = new List<Paragraph>();                       
                        int indexToInsert=0;
                        dynamic dataToProcess=new List<string>();

                        switch (substituted.Type) {
                            case "PrjPara":
                                dataToProcess = data.ProjectDetails;
                                break;
                            case "EduPara":
                                dataToProcess = data.EducationData;
                                break;
                            case "ExpPara":
                                dataToProcess = data.CompanyExperience;
                                break;
                            case "CertPara":
                                break;
                               

                        }
                        TextBox textBoxToInsert=null;
                        TextSelection[] EduTexts = document.FindAllString(substituted.Placeholder, true, true);
               

                        if(EduTexts!=null)
                        foreach (var item in EduTexts)
                        {
                            TextRange text = item.GetAsOneRange();
                            originalEduParagraph.Add(text.OwnerParagraph);
                        }

                        if (originalEduParagraph.Count > 0) {
                            indexToInsert = document.Sections[0].Paragraphs.IndexOf(originalEduParagraph[0]);

                            if (indexToInsert == -1) {
                                for (int i = 0; i < document.TextBoxes.Count; i++)
                                {
                                    // Get the current textbox
                                    TextBox textbox = document.TextBoxes[i];
                                    foreach (Paragraph item in textbox.Body.Paragraphs) 
                                    {
                                        if (item.Text.Contains(substituted.Placeholder)) {
                                            textBoxToInsert = textbox;
                                            break;
                                        }
                                    }
                                }
                            }
                        }                       

                        foreach (var tempEdu in dataToProcess)
                        {
                            List<Paragraph> clonedEduParagraphs = new List<Paragraph>();
                            foreach (Paragraph paragraph in originalEduParagraph)
                            {
                                clonedEduParagraphs.Add((Paragraph)paragraph.Clone());
                            }
                            clonedEduParagraphs.Reverse();
                            foreach (Paragraph clonedParagraph in clonedEduParagraphs)
                            {
                                foreach (DTOPlaceHolderJSON tempPlaceholder in ParseJSON(substituted.Field)) {
                                    clonedParagraph.Replace(tempPlaceholder.placeholder, EtyService.GetPropValue(tempEdu, tempPlaceholder.fieldName), false, false);
                                }
                               // clonedParagraph.Replace("#spec#", "Diploma in Graphics Engineering", false, false);
                                clonedParagraph.Replace(substituted.Placeholder, string.Empty, false, false);
                                // Add the cloned paragraph to the document
                                if (indexToInsert != -1)
                                {
                                    document.Sections[0].Paragraphs.Insert(indexToInsert, clonedParagraph);
                                }
                                else {

                                    textBoxToInsert.Body.Paragraphs.Insert(0,clonedParagraph);
                                    foreach (var item in originalEduParagraph)
                                    {
                                        textBoxToInsert.Body.Paragraphs.Remove(item);
                                    }
                                }
                            }
                        }
                        foreach (var item in originalEduParagraph)
                        {
                            document.Sections[0].Body.Paragraphs.Remove(item);
                        }
                        break;

                    //case "ExperienceList":
                    //    TextSelection expTextSelection = document.FindString(substituted.Placeholder, true, true);

                    //    if (expTextSelection != null)
                    //    {
                    //        TextRange text = expTextSelection.GetAsOneRange();
                    //        Paragraph p = text.OwnerParagraph;
                    //        text.Text = string.Empty;
                           
                    //        p.AppendHTML("<p style='margin-top:10px;font-size:" +
                    //               template.TextFontSize + "pt;color:gray'>Total of 7 years of work experience with details listed as below.</p>");
                    //        p.AppendBreak(BreakType.LineBreak);

                    //        foreach (var tmpExp in data.CompanyExperience)
                    //        {
                    //            text.Text += "Worked at "+tmpExp.CompanyName+" for "+tmpExp.Experience+" as "+tmpExp.Designation+" from "+tmpExp.FromDate+" to "+tmpExp.ToDate.ToString()+".\n";
                               
                    //        }
                    //         p.ListFormat.ContinueListNumbering();
                    //    }
                    //    break;

                    case "Default":
                        document.ReplaceInLine(substituted.Placeholder,
                        EtyService.GetPropValue(data.resumeData, substituted.Field), true, true);
                        break;
                }
            }

            using (MemoryStream ms = new MemoryStream())
            {
                document.SaveToStream(ms, FileFormat.Docx);
                document.SaveToStream(doc, FileFormat.Docx);
                document1 = new Document(ms);
                document1.SaveToStream(resultStream, FileFormat.PDF);
            }
            //document1.Save(Environment.CurrentDirectory + "//ResumeTemplates//template_1_updated.pdf", pso);
            return resultStream;

        }


        private string GetSkillLevel(string skillRating) {

            string result=string.Empty;
            int rating = Convert.ToInt32(skillRating);

            if (rating > 0 && rating <= 2)
            {
                result = "Beginner";
            }
            else if (rating > 2 && rating <= 3)
            {
                result = "Intermediate";
            }
            else {
                result = "Advanced";
            }
            return result;
        }

        public DTOPlaceHolderJSON[] ParseJSON(string jsonInput) {        
            return JsonConvert.DeserializeObject<DTOPlaceHolderJSON[]>(jsonInput);
        }
    }
}
