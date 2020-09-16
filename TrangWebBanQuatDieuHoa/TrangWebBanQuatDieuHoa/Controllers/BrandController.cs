using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public IActionResult Index()
        {
            var brands = brandRepository.GetsAllBrand();
            return View(brands.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                
                var result = brandRepository.Create(brand);
                if(result > 0)
                {
                    return RedirectToAction("Index", "Brand");
                }
            }
            ViewData["Message"] = "Thương hiệu đã tồn tại";
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = brandRepository.Get(id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            var result = brandRepository.Edit(brand);
            if (result > 0)
            {
                return RedirectToAction("Index", "Brand");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var result = brandRepository.Delete(id);
            if (result>0)
            {
                return RedirectToAction("Index", "Brand");
            }
            return View();
        }
    }
}
