using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.ViewModel
{
    public class EditProduct
    {

        [Required(ErrorMessage = "Chưa điền tên sản phẩm")]
        [Display(Name = "Tên sản phẩm"), MaxLength(150)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Chưa điền giá sản phẩm")]
        [Display(Name = "Giá sản phẩm")]
        public long ProductPrice { get; set; }

        [Required(ErrorMessage = "Chưa điền thông số kích thước")]
        [Display(Name = "Kích thước"), MaxLength(150)]
        public string Size { get; set; }

        [Display(Name = "Cân nặng")]
        [Required(ErrorMessage = "Chưa điền thông tin cân nặng")]
        public float Weight { get; set; }



    }
}
