using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrangWebBanQuatDieuHoa.Views.Order
{
    public class ShowOrder
    {
        public int Ma { get; set; }
        public string fullname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }
        public int Soluong { get; set; }
        public long Total { get; set; }
        public string PurchaseForm { get; set; }
        public string Note { get; set; }

    }
}
