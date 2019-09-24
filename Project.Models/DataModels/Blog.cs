using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class Blog
    {
        [Key]
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string Author { get; set; }
        public string FeatureImg { get; set; }
        public DateTime CreateDay { get; set; }
        public bool Status { get; set; }
    }
}
