using System;
using System.Collections.Generic;
using System.Composition.Convention;
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
        private const int fanId = 1;
        private const int  bottleId = 3;
        private const int filterId = 2;
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
                    if (model.CategoryId == fanId)
                    {
                        return RedirectToAction("ShowFan", "Product");
                    }
                    else if (model.CategoryId == filterId)
                    {
                        return RedirectToAction("ShowFilter", "Product");
                    }
                    else
                    {
                        return RedirectToAction("ShowBottle", "Product");
                    }
                }
                
            }
            ViewData["Message"] = "Sản phẩm đã tồn tại";
            return View();
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
        [HttpGet]
        public IActionResult Edit(int id)
        {           
            var createproduct = productRepository.ConvertToCreateProduct(id);
            return View(createproduct);
        }
        [HttpPost]
        public IActionResult Edit(CreateProduct editproduct, IFormFile[] ImageFiles)
        {
            var result = productRepository.Edit(editproduct, ImageFiles);
            if (result.ProductId > 0)
            {
                if (result.CategoryId == fanId)
                {
                    return RedirectToAction("ShowFan", "Product");
                }
                else if (result.CategoryId==filterId)
                {
                    return RedirectToAction("ShowFilter", "Product");
                }
                else
                {
                    return RedirectToAction("ShowBottle", "Product");
                }              
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var result = productRepository.Delete(id);
            if (result > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
