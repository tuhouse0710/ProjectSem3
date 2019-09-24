using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public byte Status { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
        [ForeignKey("Id")]
        public Customer Customers { get; set; }
    }
}
