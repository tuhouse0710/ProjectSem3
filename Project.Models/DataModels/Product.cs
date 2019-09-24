using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string Images { get; set; }
        public string FeatureImages { get; set; }
        public bool Related { get; set; }
        public bool Status { get; set; }

        [ForeignKey("CategoryId")]
        public Category Categories { get; set; }
        public ICollection<ProductAttribute> ProductAttrs { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
