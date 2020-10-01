using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Products
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Chức năng"), MaxLength(200)]
        public string Dynamic { get; set; }

        [Display(Name = "Tốc độ gió"), MaxLength(200)]
        public string WindSpeed { get; set; }

        [Display(Name = "Chế độ gió"), MaxLength(150)]
        public string WindMode { get; set; }

        [Display(Name = "Điều khiển"), MaxLength(200)]
        public string Control { get; set; }

        [Display(Name = "Phạm vi làm mát"), MaxLength(200)]
        public string CollingRange { get; set; }

        [Display(Name = "Lưu lượng gió")]
        public Nullable<int> WindFlow { get; set; }

        [Display(Name = "Loại lồng quạt"), MaxLength(100)]
        public string FanCageType { get; set; }

        [Display(Name = "Độ ồn"), MaxLength(100)]
        public string Noiselevel { get; set; }

        [Display(Name = "Mức tiêu thụ nước"), MaxLength(200)]
        public string WaterConsumption { get; set; }

        [Display(Name = "Kiểu máy"), MaxLength(150)]
        public string MachineModel { get; set; }

        [Display(Name = "Công nghệ lọc"), MaxLength(200)]
        public string FilterTechnology { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai số lượng!")]
        [Display(Name = "Số lượng lõi lọc")]
        public Nullable<int> NumberFilterCores { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai số lượng!")]
        [Display(Name = "Công suất lọc nước")]
        public Nullable<int> FilterCapacity { get; set; }

        [Display(Name = "Hệ thống bơm"), MaxLength(200)]
        public string Pumping { get; set; }


        [Display(Name = "Chế độ an toàn"), MaxLength(200)]
        public string Safemode { get; set; }


        [Display(Name = "Tùy chỉnh nhiệt độ"), MaxLength(100)]
        public string Temperature { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Nhập sai số lượng!")]
        [Display(Name = "Áp lực nước")]
        public Nullable<float> WaterPressure { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai số lượng!")]
        [Display(Name = "Thời gian đun nóng")]
        public Nullable<int> WarmUpTime { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai số lượng!")]
        [Display(Name = "Nhiệt độ tối đa")]
        public Nullable<int> MaxTemperature { get; set; }

        [Required]
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
