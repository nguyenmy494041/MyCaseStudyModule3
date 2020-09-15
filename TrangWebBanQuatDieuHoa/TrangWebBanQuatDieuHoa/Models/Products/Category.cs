using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Products
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Chưa chọn tên loại hàng")]
        [Display(Name = "Tên loại hàng"), MaxLength(150)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
