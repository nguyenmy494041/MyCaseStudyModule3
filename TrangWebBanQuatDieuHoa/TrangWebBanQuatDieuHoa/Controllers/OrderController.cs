 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Ordersss;
using TrangWebBanQuatDieuHoa.Models.ViewModel;
using TrangWebBanQuatDieuHoa.Repositories;
using X.PagedList;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        private readonly AppDbContext context;

        public OrderController(IOrderRepository orderRepository,IProductRepository productRepository,AppDbContext context )
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.context = context;
        }
        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.cactinh = orderRepository.GetTinhThanh();
            ViewBag.Product = productRepository.Get(id);
            //ViewBag.cacquan = orderRepository.GetQuanHuyen();
            //ViewBag.cacphuong = orderRepository.GetPhuongXa();
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Ordermodel model)
        {
            if (ModelState.IsValid)
            {
                var order = orderRepository.Buy(model);
                if (order!=null)
                {
                    return RedirectToAction("OrderDetail", new { id = order.OrderId });
                }               
            }
            return RedirectToAction("Detail","Home");
        }

        public IActionResult OrderDetail(int id)
        {
            var oder = orderRepository.Get(id);
            ViewBag.pro = orderRepository.GetByName(oder.ProductName, oder.ProductPrice);
            return View(oder);
        }

        [Route("/Order/TinhThanh/{TinhThanhId}")]
        public IActionResult LayDanhSachQuanHuyen(int TinhThanhId)
        {
            var quanhuyens = orderRepository.LayDanhSachQuanHuyen(TinhThanhId);
            return Json(new { quanhuyens });
        }

        [Route("/Order/TinhThanh/QuanHuyen/{QuanHuyenId}")]
        public IActionResult LayDanhSachPhuongXa(int QuanHuyenId, int TinhThanhId)
        {
            var phuongxas = orderRepository.LayDanhSachPhuongXa(QuanHuyenId, TinhThanhId);
            return Json(new { phuongxas });
        }
        [Route("/Order/HuyDonHang/{Ma}")]
        public IActionResult HuyDonHang(int Ma)
        {
            var order = orderRepository.HuyDonHang(Ma);
            var pro = orderRepository.GetByName(order.ProductName, order.ProductPrice);
            return RedirectToAction("Detail","Home", new { id = pro.ProductId });
        }
        public IActionResult Danhsachtinhthanh(int? page)
        {
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            var result = context.TinhThanh.OrderBy(m => m.TenTinhThanh).ToList().ToPagedList(pageNumber,pageSize);
            return View(result);
        }


        public IActionResult OrderShowAdmin()
        {
            var dat = orderRepository.OrderShowAdmin();
            return View(dat);
        }

        [Route("/Order/XemChiTietDonHang/{orderId}")]
        public IActionResult XemChiTietDonHang(int orderId)
        {
            var dat = orderRepository.XemChiTietDonHang(orderId);
            return View(dat);
        }

        public IActionResult ToLookUp(History history)
        {
            if (ModelState.IsValid)
            {
                var dat = orderRepository.LayDanhSachDonHang(history.SoDienThoai);
                return View(dat);
            }
            return View();
        }
        [Route("/Order/XacNhanGiaoHang/{orderId}")]
        public IActionResult XacNhanGiaoHang(int orderId)
        {
            var dat = orderRepository.XacNhanGiaoHang(orderId);
            return RedirectToAction("DonDaGiao", "Order");
        }

        public IActionResult DonDaGiao()
        {
            var dat = orderRepository.DonHangDaGiao();
            return View(dat);
        }


        [Route("/Order/AdminHuyDonHang/{orderId}")]
        public IActionResult AdminHuyDonHang(int orderId)
        {
            var dat = orderRepository.HuyDonHang(orderId);
            if (dat!=null )
            {
                return RedirectToAction("OrderShowAdmin", "Order");
            }
            return View();
        }

        [HttpGet]
        public IActionResult InstallmentPurchase(int id)
        {
            ViewBag.cactinh = orderRepository.GetTinhThanh();
            ViewBag.Product = productRepository.Get(id);           
            return View();
        }
        [HttpPost]
        public IActionResult InstallmentPurchase(Ordermodel model)
        {
            if (ModelState.IsValid)
            {
                var order = orderRepository.InstallmentPurchase(model);
                if (order != null)
                {
                    return RedirectToAction("OrderDetail", new { id = order.OrderId });
                }
            }
            return RedirectToAction("Detail", "Home");
        }
    }
}
