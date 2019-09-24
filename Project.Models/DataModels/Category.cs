using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int OrderBy{ get; set; }
        public int? ParentId { get; set; }
        public string Images { get; set; }
        public bool Status { get; set; }

        //Chỉ ra quan hệ 1 danh mục có nhiều sản phẩm (1-n)

        public ICollection<Product> Products { get; set; }
    }
}
