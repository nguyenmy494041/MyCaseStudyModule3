using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Ordersss;
using TrangWebBanQuatDieuHoa.Models.ViewModel;
using TrangWebBanQuatDieuHoa.Repositories;
using X.PagedList;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository productRepository;
        private const int fanId = 1;
        private const int bottleId = 3;
        private const int filterId = 2;
        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Show()
        {
            var products = productRepository.GetAllByCategory(null);
            return View(products);
        }
        public IActionResult Detail(int id)
        {
            var detail = productRepository.Get(id);
            if (detail != null)
            {
                ViewBag.products = productRepository.Gets(detail.CategoryId, detail.ProductId);               
                return View(detail);
            }
            return View("~/Views/Shared/Error.cshtml", id);
        }
        public IActionResult ShowFan(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var fans = productRepository.GetAllByCategory(fanId).ToPagedList(pageNumber, pageSize);
            return View(fans);
        }
        public IActionResult ShowFilter(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var filters = productRepository.GetAllByCategory(filterId).ToPagedList(pageNumber, pageSize);
            return View(filters);
        }
        public IActionResult ShowBottle(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var filters = productRepository.GetAllByCategory(bottleId).ToPagedList(pageNumber, pageSize);
            return View(filters);
        }

        public IActionResult Search(string Search, int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.search = new State() { StateName = Search };
            var result = productRepository.Search(Search).ToPagedList(pageNumber, pageSize);
            return View(result);
        }

        public IActionResult LocSanPham(int? categoryId, int? brandId, int? price, int? sortByPrice,int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.search = new LocSanPham() { brandId = brandId,categoryId = categoryId,price=price,sortByPrice=sortByPrice };
            var dat = productRepository.LocSanPham(categoryId,brandId,price,sortByPrice).ToPagedList(pageNumber, pageSize);
            return View(dat);
        }

        public IActionResult History()
        {
            return View();
        }
        
    }

}
