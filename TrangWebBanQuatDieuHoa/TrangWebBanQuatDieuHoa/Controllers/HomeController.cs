using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Repositories;

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
                //ViewData["listpros"] = productRepository.GetAllByCategory(detail.CategoryId);
                return View(detail);
            }
            return View("~/Views/Shared/Error.cshtml", id);
        }
        public IActionResult ShowFan()
        {
            var fans = productRepository.GetAllByCategory(fanId);
            return View(fans);
        }
        public IActionResult ShowFilter()
        {
            var filters = productRepository.GetAllByCategory(filterId);
            return View(filters);
        }
        public IActionResult ShowBottle()
        {
            var filters = productRepository.GetAllByCategory(bottleId);
            return View(filters);
        }
        public IActionResult Search(string Search)
        {
            var result = productRepository.Search(Search);
            return View(result);
        }
    }
}
