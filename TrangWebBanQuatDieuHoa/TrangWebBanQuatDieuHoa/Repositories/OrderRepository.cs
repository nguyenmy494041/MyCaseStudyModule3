using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Ordersss;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Models.ViewModel;
using TrangWebBanQuatDieuHoa.Views.Order;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Order Buy(Ordermodel model)
        {
            if (model != null)
            {
                var oder = new Order()
                {
                    Fullname = model.Fullname,
                    ProductName=model.ProductName,
                    ProductPrice=model.ProductPrice,
                    Adress=model.Adress,
                    TinhThanhId=model.TinhThanhId,
                    QuanHuyenId=model.QuanHuyenId,
                    PhuongXaId=model.PhuongXaId,
                    SoDienThoai=model.SoDienThoai,
                    Soluong=model.Soluong,
                    Status = "Chờ xử lý",
                    Total=model.Soluong * model.ProductPrice,                
            };
              
                context.Order.Add(oder);
                context.SaveChanges();
                return oder;
            }
            return null;
        }

        public ShowOrder Get(int id)
        {
            IEnumerable<ShowOrder> result = new List<ShowOrder>();
            result = (from o in context.Order
                      join t in context.TinhThanh on o.TinhThanhId equals t.TinhThanhId
                      join q in context.QuanHuyen on o.QuanHuyenId equals q.QuanHuyenId
                      join p in context.PhuongXa on o.PhuongXaId equals p.PhuongXaId
                    
                      select (new ShowOrder()
                      {
                          Ma =o.OrderId,
                         fullname = o.Fullname,
                         Phone=o.SoDienThoai,
                         Address= $"{o.Adress}, {p.TenDayDu}, {q.TenDayDu}, {t.TenDayDu}",
                         ProductName = o.ProductName,
                         ProductPrice=o.ProductPrice,
                         Soluong=o.Soluong,
                         Total= o.Total                        

                      }));
            return result.FirstOrDefault(ep => ep.Ma == id);
        }

        public Product GetByName(string name, long price)
        {
            return context.Products.FirstOrDefault(ep => ep.ProductName == name && ep.ProductPrice == price);
        }

        public List<PhuongXa> GetPhuongXa()
        {
            return context.PhuongXa.ToList();
        }

        public List<QuanHuyen> GetQuanHuyen()
        {
            return context.QuanHuyen.ToList();
        }

        public List<TinhThanh> GetTinhThanh()
        {
            return context.TinhThanh.ToList();
        }

        public Order HuyDonHang(int id)
        {
            var oder = context.Order.Find(id);
            context.Order.Remove(oder);
            context.SaveChanges();
            return oder;
        }

        public List<PhuongXa> LayDanhSachPhuongXa(int idQuanHuyen = 0, int idTinh = 0)
        {
            if (idQuanHuyen != 0 && idTinh != 0)
            {
                return context.PhuongXa.Where(e => e.TinhThanhId == idTinh && e.QuanHuyenId == idQuanHuyen).ToList();
            }
            else if (idQuanHuyen != 0)
            {
                return context.PhuongXa.Where(e => e.QuanHuyenId == idQuanHuyen).ToList();
            }
            else if (idTinh != 0)
            {
                return context.PhuongXa.Where(e => e.TinhThanhId == idTinh).ToList();
            }
            else
            {
                return context.PhuongXa.ToList();
            }
        }

        public List<QuanHuyen> LayDanhSachQuanHuyen(int idTinh)
        {
            var result = context.QuanHuyen.Where(e => e.TinhThanhId == idTinh).ToList();
            return result;
        }
    }
}
