using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class ProductAttribute
    {
        [Column(Order = 0), Key]
        public int ProductId { get; set; }
        [Column(Order = 1), Key]
        public int AttrId { get; set; }
        [ForeignKey("ProductId")]
        public Product Products { get; set; }
        [ForeignKey("AttrId")]
        public Attribute Attributes { get; set; }
    }
}
