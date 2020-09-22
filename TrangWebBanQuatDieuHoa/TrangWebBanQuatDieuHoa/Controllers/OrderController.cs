using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models.Ordersss;
using TrangWebBanQuatDieuHoa.Models.ViewModel;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderController(IOrderRepository orderRepository,IProductRepository productRepository )
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
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
    }
}
