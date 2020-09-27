using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Models.Ordersss
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required(ErrorMessage ="Chưa nhaph trạng thái")]
        [MaxLength(70), Display(Name = "Tên khách hàng")]
        public string StateName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
