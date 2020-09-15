using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Services.Impl
{
    public class ProductServiceImpl : GeneralServiceImpl<CreateProduct, IProductRepository>, IProductService
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductServiceImpl(IProductRepository repository, AppDbContext context, 
                                  IWebHostEnvironment webHostEnvironment) : base(repository)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        
        public Product TaoMoiSanPham(CreateProduct model, IFormFile[] ImageFiles)
        {
            var product = new Product()
            {
                ProductCode = model.ProductCode,
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                Size = model.Size,
                Weight = model.Weight,
                TankCapacity = model.TankCapacity,
                BrandId = model.BrandId,
                Wattage = model.Wattage,
                Utilities = model.Utilities,
                CategoryId = model.CategoryId,
                Manufactures = model.Manufactures,
                MadeIn = model.MadeIn,
                Year = model.Year,
                Description = model.Description
            };
            
            //context.SaveChanges();
            //var proIds = context.Products.FirstOrDefaultAsync(a => a.ProductCode == model.ProductCode &&
            //                                                           a.ProductName == model.ProductName)

            var spec = new Specification()
            {
                Dynamic = model.Dynamic,
                WindMode = model.WindMode,
                WindSpeed = model.WindSpeed,
                Control = model.Control,
                CollingRange = model.CollingRange,
                WindFlow = model.WindFlow,
                FanCageType = model.FanCageType,
                Noiselevel = model.Noiselevel,
                WaterConsumption = model.WaterConsumption,
                MachineModel = model.MachineModel,
                FilterTechnology = model.FilterTechnology,
                NumberFilterCores = model.NumberFilterCores,
                FilterCapacity = model.FilterCapacity,
                Pumping = model.Pumping,
                Safemode = model.Safemode,
                Temperature = model.Temperature,
                WaterPressure = model.WaterPressure,
                WarmUpTime = model.WarmUpTime,
                MaxTemperature = model.MaxTemperature,
                ProductId = model.ProductId,
               
            };
            List<Image> images = new List<Image>();
            if (model.ImageFiles != null)
            {
                var iamge = model.ImageFiles.ToList();
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

                for (int i = 0; i < iamge.Count; i++)
                {
                    string fileName = $"{Guid.NewGuid()}_{iamge[i].FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        iamge[i].CopyTo(fs);
                    }
                    var anh = new Image()
                    {
                        ProductId = model.ProductId,
                        ImageName = fileName
                    };
                    images.Add(anh);
                   
                }
                product.Images = images;
            }
            product.Specification = spec;
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        Task<CreateProduct> IGeneralService<CreateProduct>.Add(CreateProduct entity)
        {
          
            return null;
        }

        Task<CreateProduct> IGeneralService<CreateProduct>.Delete(int id)
        {
            return null;
        }

        Task<CreateProduct> IGeneralService<CreateProduct>.Get(int id)
        {
            return null;
        }

        Task<List<CreateProduct>> IGeneralService<CreateProduct>.GetAll()
        {
            return null;
        }

       

        Task<CreateProduct> IGeneralService<CreateProduct>.Update(CreateProduct entity)
        {
            return null;
        }
    }
}
