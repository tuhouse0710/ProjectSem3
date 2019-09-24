using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class OrderDetails
    {
        [Column(Order=0),Key]
        public int OrderId { get; set; }
        [Column(Order =1), Key]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product Products { get; set; }
        [ForeignKey("OrderId")]
        public Order Orders { get; set; }
    }
}
