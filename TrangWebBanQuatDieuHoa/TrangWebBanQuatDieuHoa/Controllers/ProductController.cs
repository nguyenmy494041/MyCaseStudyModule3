using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Services;
using TrangWebBanQuatDieuHoa.Services.Impl;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProductService service;

        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment, IProductService service)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            this.service = service;
        }

        //phần viêt thêm
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProduct model, IFormFile[] ImageFiles)
        {
            if (ModelState.IsValid)
            {
                service.TaoMoiSanPham( model,ImageFiles);
               return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
