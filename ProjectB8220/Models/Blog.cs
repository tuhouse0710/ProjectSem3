using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectB8220.Models
{
    public class Blog
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string Author { get; set; }
        public string FeatureImg { get; set; }
        public DateTime CreateDay { get; set; }
        public bool Status { get; set; }
    }
}