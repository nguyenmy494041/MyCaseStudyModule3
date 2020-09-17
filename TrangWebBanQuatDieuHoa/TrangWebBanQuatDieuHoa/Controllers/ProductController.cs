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
            var products = productRepository.GetAllByCategory(null).ToList();
            var edit = products.FirstOrDefault(e => e.ProductId== id);
            var createproduct = new CreateProduct()
            {
                ProductId = edit.ProductId,
                ProductName = edit.ProductName,
                CategoryId = edit.CategoryId,
                ProductPrice = edit.ProductPrice,
                Utilities = edit.Utilities,
                Year = edit.Year,
                Wattage = edit.Wattage,
                WaterConsumption = edit.Specification.WaterConsumption,
                WarmUpTime = edit.Specification.WarmUpTime,
                WaterPressure = edit.Specification.WaterPressure,
                Weight = edit.Weight,
                WindFlow = edit.Specification.WindFlow,
                WindMode = edit.Specification.WindMode,
                WindSpeed = edit.Specification.WindSpeed,
                Safemode = edit.Specification.Safemode,
                Size = edit.Size,
                CollingRange = edit.Specification.CollingRange,
                Control = edit.Specification.Control,
                Dynamic = edit.Specification.Dynamic,
                Description = edit.Description,
                FanCageType = edit.Specification.FanCageType,
                FilterCapacity = edit.Specification.FilterCapacity,
                FilterTechnology = edit.Specification.FilterTechnology,
                MachineModel = edit.Specification.MachineModel,
                MadeIn = edit.MadeIn,
                Manufactures = edit.Manufactures,
                MaxTemperature = edit.Specification.MaxTemperature,
                Noiselevel = edit.Specification.Noiselevel,
                NumberFilterCores = edit.Specification.NumberFilterCores,
                Pumping = edit.Specification.Pumping,
                TankCapacity = edit.TankCapacity,
                Temperature = edit.Specification.Temperature,
                images = edit.Images,
                
            };
            return View(createproduct);
        }
        [HttpPost]
        public IActionResult Edit(CreateProduct editproduct, IFormFile[] ImageFiles)
        {
            var result = productRepository.Edit(editproduct, ImageFiles);
            if (result > 0)
            {
                return RedirectToAction("Index", "Home");
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
