using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Total { get; set; }
        public DateTime CreateDay { get; set; }
        public bool Status { get; set; }

        [ForeignKey("Id")]
        public Customer Customers { get;set;}
        [ForeignKey("EmployeeId")]
        public Empolyee Employees { get; set; }
    }
}
