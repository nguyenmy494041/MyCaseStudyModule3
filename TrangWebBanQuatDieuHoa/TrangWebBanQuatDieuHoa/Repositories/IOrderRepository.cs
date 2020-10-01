using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models.Ordersss;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Models.ViewModel;
using TrangWebBanQuatDieuHoa.Views.Order;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public interface IOrderRepository
    {
        ShowOrder Get(int id);
        Order Buy(Ordermodel order);
        List<TinhThanh> GetTinhThanh();
        List<QuanHuyen> GetQuanHuyen();
        List<PhuongXa> GetPhuongXa();
        List<QuanHuyen> LayDanhSachQuanHuyen(int idTinh);
        public List<PhuongXa> LayDanhSachPhuongXa(int idQuanHuyen = 0, int idTinh = 0);
        Order HuyDonHang(int id);
        Product GetByName(string name, long price);

        List<Order> OrderShowAdmin();

        Order XemChiTietDonHang(int orderId);
        List<Order> LayDanhSachDonHang(string number);
        Order XacNhanGiaoHang(int orderId);

        List<Order> DonHangDaGiao();
        Order InstallmentPurchase(Ordermodel model);
    }
}
