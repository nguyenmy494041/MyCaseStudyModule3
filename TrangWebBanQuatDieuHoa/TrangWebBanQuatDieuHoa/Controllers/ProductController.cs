using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository  )
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProduct model, IFormFile[] ImageFiles)
        {
            if (ModelState.IsValid)
            {
                var result = productRepository.Create(model, ImageFiles);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            ViewData["Message"] = "Sản phẩm đã tồn tại";
            return View();
        }
        public IActionResult ShowFan()
        {
            var fans = productRepository.GetAllByCategory(1).ToList();
            return View(fans);
        }
        public IActionResult ShowFilter()
        {
            var filters = productRepository.GetAllByCategory(2).ToList();
            return View(filters);
        }
        public IActionResult ShowBottle()
        {
            var filters = productRepository.GetAllByCategory(3).ToList();
            return View(filters);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //    var pro = 
            var products = productRepository.GetAllByCategory(null).ToList();
            var edit = products.FirstOrDefault(e => e.ProductId== id);
            return View(edit);
        }
    }
}
