using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class TypeAttr
    {
        [Key]
        public int TypeAttrId { get; set; }
        public string TypeName { get; set; }
        public int OrderBy { get; set; }
        public bool Status { get; set; }

        public ICollection<Attribute> Attributes { get; set; }
    }
}
