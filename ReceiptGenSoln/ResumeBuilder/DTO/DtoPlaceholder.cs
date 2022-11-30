using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.DTO
{
    [Table("TemplatePlaceholders")]
    public class DtoPlaceholder
    {
        [Column(name: "Placeholder")]
        public string Placeholder { get; set; }
        [Column(name: "Field")]
        public string Field { get; set; }

        [Column(name: "Type")]
        public string Type { get; set; }
    }
}
