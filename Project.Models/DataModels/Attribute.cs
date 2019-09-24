using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class Attribute
    {
        [Key]
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public int TypeId { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }

        [ForeignKey("TypeId")]
        public TypeAttr TypeAttrs { get; set; }

    }
}
