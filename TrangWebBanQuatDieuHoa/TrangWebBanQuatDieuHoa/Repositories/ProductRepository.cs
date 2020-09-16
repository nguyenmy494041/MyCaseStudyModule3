using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Products;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        
        public ProductRepository(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Product> GetAllFan()
        {
            var fan = context.Categories.FirstOrDefault(e => e.CategoryName == "Quạt điều hòa").CategoryId;
            return context.Products.Where(e => e.CategoryId == fan).ToList();
        }

        public int Create(CreateProduct createProduct, IFormFile[] ImageFiles)
        {
            var exit = context.Products.FirstOrDefault(e => e.ProductCode == createProduct.ProductCode && e.CategoryId == createProduct.CategoryId);
            if (createProduct!= null && ImageFiles !=null && exit == null)
            {
                var product = new Product()
                {
                    ProductCode = createProduct.ProductCode,
                    ProductName = createProduct.ProductName,
                    ProductPrice = createProduct.ProductPrice,
                    Size = createProduct.Size,
                    Weight = createProduct.Weight,
                    TankCapacity = createProduct.TankCapacity,
                    BrandId = createProduct.BrandId,
                    Wattage = createProduct.Wattage,
                    Utilities = createProduct.Utilities,
                    CategoryId = createProduct.CategoryId,
                    Manufactures = createProduct.Manufactures,
                    MadeIn = createProduct.MadeIn,
                    Year = createProduct.Year,
                    Description = createProduct.Description
                };
                var spec = new Specification()
                {
                    Dynamic = createProduct.Dynamic,
                    WindMode = createProduct.WindMode,
                    WindSpeed = createProduct.WindSpeed,
                    Control = createProduct.Control,
                    CollingRange = createProduct.CollingRange,
                    WindFlow = createProduct.WindFlow,
                    FanCageType = createProduct.FanCageType,
                    Noiselevel = createProduct.Noiselevel,
                    WaterConsumption = createProduct.WaterConsumption,
                    MachineModel = createProduct.MachineModel,
                    FilterTechnology = createProduct.FilterTechnology,
                    NumberFilterCores = createProduct.NumberFilterCores,
                    FilterCapacity = createProduct.FilterCapacity,
                    Pumping = createProduct.Pumping,
                    Safemode = createProduct.Safemode,
                    Temperature = createProduct.Temperature,
                    WaterPressure = createProduct.WaterPressure,
                    WarmUpTime = createProduct.WarmUpTime,
                    MaxTemperature = createProduct.MaxTemperature,
                    ProductId = createProduct.ProductId,

                };
                List<Image> images = new List<Image>();
                if (createProduct.ImageFiles != null)
                {
                    var iamge = createProduct.ImageFiles.ToList();
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
                            ProductId = createProduct.ProductId,
                            ImageName = fileName
                        };
                        images.Add(anh);

                    }
                    product.Images = images;
                }
                product.Specification = spec;
                context.Products.Add(product);
                return context.SaveChanges();
            }
            return -1;
        }

       
    }
}
