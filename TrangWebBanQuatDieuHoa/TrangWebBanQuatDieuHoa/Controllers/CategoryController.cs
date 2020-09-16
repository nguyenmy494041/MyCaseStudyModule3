using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var ressult = categoryRepository.GetsAll();
            return View(ressult.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = categoryRepository.Create(category);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Category");
                }
            }
            ViewData["Message"] = "Loại sản phẩm đã tồn tại";
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = categoryRepository.Get(id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var result = categoryRepository.Edit(category);
            if (result > 0)
            {
                return RedirectToAction("Index", "Brand");
            }
            ViewData["Message"] = "Loại sản phẩm đã tồn tại";
            return View();
        }

    }
}
