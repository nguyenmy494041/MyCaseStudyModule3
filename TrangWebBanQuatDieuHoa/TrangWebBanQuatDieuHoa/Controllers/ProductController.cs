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
    }
}
