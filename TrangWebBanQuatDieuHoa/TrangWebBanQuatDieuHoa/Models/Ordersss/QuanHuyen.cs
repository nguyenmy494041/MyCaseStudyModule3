using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Ordersss
{
    public class QuanHuyen
    {
        [Key]
        public int QuanHuyenId { get; set; }
        [Required, MaxLength(100)]
        public string TenQuanHuyen { get; set; }
        [Required, MaxLength(100)]
        public string QuanHayHuyen { get; set; }
        public string TenDayDu => $"{QuanHayHuyen} {TenQuanHuyen}";

        [Required]
        [ForeignKey("TinhThanh")]
        public int TinhThanhId { get; set; }
        public TinhThanh TinhThanh { get; set; }
        public List<PhuongXa> PhuongXas { get; set; }
    }
}
