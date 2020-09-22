using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Ordersss
{
    public class PhuongXa
    {
        public int PhuongXaId { get; set; }
        [Required, MaxLength(100)]
        public string TenPhuongXa { get; set; }
        [Required, MaxLength(30)]
        public string PhuongHayXa { get; set; }
        public string TenDayDu => $"{PhuongHayXa} {TenPhuongXa}";
        

        [Required]     
        public int TinhThanhId { get; set; }
      

        [Required]
        [ForeignKey("QuanHuyen")]
        public int QuanHuyenId { get; set; }
        public QuanHuyen QuanHuyen { get; set; }
        public Order Order { get; set; }
    }
}
