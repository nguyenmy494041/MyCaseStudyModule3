using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Ordersss
{
    public class TinhThanh
    {
        [Key]
        public int TinhThanhId { get; set; }

        [Required, MaxLength(100)]
        public string TenTinhThanh { get; set; }

        [Required, MaxLength(100)]
        public string TinhHayThanhPho { get; set; }
        [Required, MaxLength(10)]
        public string MaBuuDien { get; set; }
        public string TenDayDu => $"{TinhHayThanhPho} {TenTinhThanh}";
        public List<QuanHuyen> QuanHuyens { get; set; }
    }
}
