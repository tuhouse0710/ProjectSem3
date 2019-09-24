using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int GroupId { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        [ForeignKey("GroupId")]
        public Group Groups { get; set; }
    }
}
