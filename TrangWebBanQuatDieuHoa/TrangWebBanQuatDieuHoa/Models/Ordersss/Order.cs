using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Ordersss
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Số điện thoại"), MaxLength(15)]
        [RegularExpression(@"(09[0|1|2|3|4|6|7|8|9]|08[1|2|3|4|5|6|8|9]|07[0|6|7|8|9]|03[2|3|4|5|6|7|8|9]|05[6|8|9])+([0-9]{7})\b",
          ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string SoDienThoai { get; set; }
        [Required(ErrorMessage ="Chưa điền thông tin")]
        [MaxLength(100),Display(Name ="Tên khách hàng")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Chưa điền thông tin")]
        [MaxLength(200), Display(Name = "Tên sản phẩm:")]

        public string ProductName { get; set; }

        [Required(ErrorMessage = "Chưa điền thông tin")]
        [MaxLength(30), Display(Name = "Hình thức mua hàng:")]
        public string PurchaseForm { get; set; }

        [Required(ErrorMessage = "Chưa điền thông tin")]
        [MaxLength(500), Display(Name = "Hình thức thanh toán:")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Chưa điền thông tin")]
        [MaxLength(100), Display(Name = "Số nhà")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Chưa điền thông tin"), Display(Name = "Tỉnh thành")]
       
        public int TinhThanhId { get; set; }
        [Required(ErrorMessage = "Chưa điền thông tin"), Display(Name = "Quận huyện")]
       
        public int QuanHuyenId { get; set; }
       
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai số lượng!"), Display(Name = "Số lượng:")]
        public int Soluong { get; set; }
        [Required(ErrorMessage = "Chưa điền giá sản phẩm")]
        [Display(Name = "Giá sản phẩm:")]
        public long ProductPrice { get; set; }

        public DateTime ThoiDiemDatHang { get; set; }

        [Display(Name = "Thành tiền:")]
        [Range(1, long.MaxValue, ErrorMessage = "Nhập sai số lượng!")]
        public long Total { get; set; }

        [Required(ErrorMessage = "Chưa điền thông tin"), Display(Name = "Phường Xã")]
        [ForeignKey("PhuongXa")]
        public int PhuongXaId { get; set; }
        public PhuongXa PhuongXa { get; set; }
        
        [Required]        
        [ForeignKey("States")]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
