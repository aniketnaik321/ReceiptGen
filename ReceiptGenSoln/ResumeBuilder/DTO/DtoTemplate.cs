using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.DTO
{
    [Table("ResumeTemplates")]
    public class DtoResumeTemplates
    {
        [Column(name:"TemplateName")]
        public string TemplateName {get;set;}
        [Column(name: "Description")]
        public string Description { get; set; }

        [Column(name: "ThumbnailImage")]
        public string ThumbnailImage { get; set; }

        [Column(name: "Id")]
        public string Id { get; set; }
    }

}
