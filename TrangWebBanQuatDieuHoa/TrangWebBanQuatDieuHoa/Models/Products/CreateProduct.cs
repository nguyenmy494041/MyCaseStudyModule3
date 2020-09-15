using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Products
{
    public class CreateProduct : Specification
    {

        [Required(ErrorMessage = "Chưa điền tên sản phẩm")]
        [Display(Name = "Tên sản phẩm"), MaxLength(150)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Chưa điền mã sản phẩm")]
        [Display(Name = "Mã sản phẩm"), MaxLength(20)]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Chưa điền giá sản phẩm")]
        [Display(Name = "Giá sản phẩm")]
        public long ProductPrice { get; set; }

        [Required(ErrorMessage = "Chưa điền thông số kích thước")]
        [Display(Name = "Kích thước"), MaxLength(150)]
        public string Size { get; set; }

        [Display(Name = "Cân nặng")]
        [Required(ErrorMessage = "Chưa điền thông tin cân nặng")]
        public float Weight { get; set; }

        [Display(Name = "Dung tích bình chứa")]
        [Required(ErrorMessage = "Chưa điền dung tích bình chứa")]
        public int TankCapacity { get; set; }

        [Display(Name = "Tên hãng")]
        [Required(ErrorMessage = "Chưa điền tên hãng sản phẩm")]
        public int BrandId { get; set; }

        [Display(Name = "Công suất")]
        [Required(ErrorMessage = "Chưa điền công suất")]
        public int Wattage { get; set; }

        [Display(Name = "Tiện ích"), MaxLength(500)]
        [Required(ErrorMessage = "Chưa điền thông tin tiện ích")]
        public string Utilities { get; set; }

        [Display(Name = "Thương hiệu của"), MaxLength(100)]
        [Required(ErrorMessage = "Chưa điền thông tin ")]
        public string Manufactures { get; set; }

        [Display(Name = "Sản xuất tại"), MaxLength(50)]
        [Required(ErrorMessage = "Chưa điền nơi sản xuất")]
        public string MadeIn { get; set; }

        [Display(Name = "Năm ra mắt")]
        [Required(ErrorMessage = "Chưa điền năm ra mắt")]

        public int Year { get; set; }

        [Display(Name = "Mô tả sản phẩm"), MaxLength(50000)]
        [Required(ErrorMessage = "Chưa mô tả về sản phẩm")]
        public string Description { get; set; }

        public Specification Specification { get; set; }

        [Required]
        [Display(Name = "Loại sản phẩm")]
        public int CategoryId { get; set; }

        public IEnumerable<IFormFile> ImageFiles { get; set; }
    }
}
