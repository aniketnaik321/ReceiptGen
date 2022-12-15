using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.DTO
{
    [Table("ResumeTemplates")]
    public class DtoResumeTemplate
    {
        [Column(name:"TemplateName")]
        public string TemplateName {get;set;}
        [Column(name: "Description")]
        public string Description { get; set; }

        [Column(name: "ThumbnailImage")]
        public string ThumbnailImage { get; set; }

        [Column(name: "FileName")]
        public string FileName { get; set; }

        [Column(name: "TitleFontSize")]
        public string TitleFontSize { get; set; }

        [Column(name: "TextFontSize")]
        public string TextFontSize { get; set; }

        [Column(name: "TemplateFont")]
        public string TemplateFont { get; set; }


        [Column(name: "Id")]
        public int Id { get; set; }
    }

}
