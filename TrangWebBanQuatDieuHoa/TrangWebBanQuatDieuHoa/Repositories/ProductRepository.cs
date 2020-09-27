using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Ordersss;
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



        public List<Product> GetAllByCategory(int? categoryId)
        {

            List<Product> products = context.Products.Include(e => e.Specification)
              .Include(e => e.Images).Include(e => e.Category).Include(e => e.Brand).ToList();
            var query = products.AsQueryable();
            if(categoryId!=null)
            {
                query = query.Where(e => e.CategoryId == categoryId);
            }
            return query.ToList();
        }

        public int Create(CreateProduct createProduct, IFormFile[] ImageFiles)
        {
            var exit = context.Products.FirstOrDefault(e => e.ProductCode == createProduct.ProductCode && e.CategoryId == createProduct.CategoryId);
            if (createProduct!= null /*&& ImageFiles !=null*/ && exit == null)
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







        public Product Edit(CreateProduct editproduct, IFormFile[] ImageFiles)
        {
            var exit = context.Products.Include(e => e.Specification)
              .Include(e => e.Images).Include(e => e.Category).FirstOrDefault(e => e.ProductId == editproduct.ProductId);
            //var exit = context.Products.Find(editproduct.ProductId);
            if (exit != null)
            {
                exit.ProductName = editproduct.ProductName;
                exit.ProductPrice = editproduct.ProductPrice;
                exit.Size = editproduct.Size;
                exit.Weight = editproduct.Weight;
                exit.Wattage = editproduct.Wattage;
                exit.TankCapacity = editproduct.TankCapacity;
                exit.Utilities = editproduct.Utilities;
                exit.Manufactures = editproduct.Manufactures;
                exit.MadeIn = editproduct.MadeIn;
                //exit.CategoryId = editproduct.CategoryId;
                //exit.BrandId = editproduct.BrandId;
                exit.Year = editproduct.Year;
                exit.Description = editproduct.Description;
                //var spec = context.Specifications.FirstOrDefault(p => p.ProductId == exit.ProductId);
                var spec = new Specification()
                {
                Dynamic = editproduct.Dynamic,
                WindSpeed = editproduct.WindSpeed,
                WindFlow = editproduct.WindFlow,
                WindMode = editproduct.WindMode,
                Control = editproduct.Control,
                CollingRange = editproduct.CollingRange,
                FanCageType = editproduct.FanCageType,
                Noiselevel = editproduct.Noiselevel,
                WaterConsumption = editproduct.WaterConsumption,
                MachineModel = editproduct.MachineModel,
                FilterTechnology = editproduct.FilterTechnology,
                FilterCapacity = editproduct.FilterCapacity,
                Pumping = editproduct.Pumping,
                Safemode = editproduct.Safemode,
                Temperature = editproduct.Temperature,
                WaterPressure = editproduct.WaterPressure,
                WarmUpTime = editproduct.WarmUpTime,
                MaxTemperature = editproduct.MaxTemperature,
                NumberFilterCores = editproduct.NumberFilterCores,
                ProductId = editproduct.ProductId
            };

                exit.Specification = spec;
                List<Image> images = new List<Image>();
                if (editproduct.ImageFiles != null)
                {
                    //List<Image> imagesList = context.Images.ToList().FindAll(el => el.ProductId == exit.ProductId);
                    //context.RemoveRange(imagesList);
                    //context.SaveChangesAsync();

                    var iamge = editproduct.ImageFiles.ToList();
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
                            ProductId = exit.ProductId,
                            ImageName = fileName
                        };
                        images.Add(anh);

                    }
                    exit.Images = images;

                }
                context.SaveChanges();
                return exit;
            }
            return new Product();
        }

        public int Delete(int id)
        {
            var delete = context.Products.FirstOrDefault(e => e.ProductId == id);
            if (delete != null)
            {
                context.Products.Remove(delete);
                return context.SaveChanges();
            }
            return -1;
        }

        

        public CreateProduct ConvertToCreateProduct(int id)
        {
            Product edit = Get(id);
            //Product edit = context.Products.Include(e => e.Specification)
            //  .Include(e => e.Images).Include(e => e.Category).FirstOrDefault(e => e.ProductId == id);
            //var products = productRepository.GetAllByCategory(null).ToList();
            //var edit = context.Products.FirstOrDefault(e => e.ProductId == id);
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
            return createproduct;
        }

        public Product Get(int id)
        {
            return context.Products.Include(e => e.Specification)
             .Include(e => e.Images).Include(e => e.Category).Include(e => e.Brand).FirstOrDefault(e => e.ProductId == id);
        }

        public List<Product> Gets(int caregoryid, int productid)
        {
            return context.Products.Include(e => e.Specification)
            .Include(e => e.Images).Include(e => e.Category).Include(e => e.Brand).Where(
                e => e.ProductId != productid && e.CategoryId== caregoryid).ToList();
        }

        public List<Product> Search(string name)
        {
            return context.Products.Include(e => e.Specification)
         .Include(e => e.Images).Include(e => e.Category).Include(e => e.Brand).Where(
             e => e.ProductName.Contains(name)).ToList();
        }

        public List<Product> LocSanPham(int? categoryId, int? brandId, int? price, int? sortByPrice)
        {
            var data = context.Products.Include(e => e.Specification)
           .Include(e => e.Images).Include(e => e.Category).Include(e => e.Brand).ToList();
            if (categoryId.HasValue)
            {
                data = data.Where(e => e.CategoryId == categoryId).ToList();
            }
            if (brandId.HasValue)
            {
                data = data.Where(e => e.BrandId == brandId).ToList();
            }
            if (price.HasValue)
            {
                if (price == 1)
                {
                    data = data.Where(e => e.ProductPrice >= 1000000 && e.ProductPrice < 4000000).ToList();
                        }
                else if (price == 2)
                {
                    data = data.Where(e => e.ProductPrice >= 4000000 && e.ProductPrice < 8000000).ToList();
                }
                else
                {
                    data = data.Where(e => e.ProductPrice >= 8000000).ToList();
                }
            }
            if (sortByPrice.HasValue)
            {
                if (sortByPrice == 2)
                {
                    data = data.OrderByDescending(e=>e.ProductPrice).ToList();
                }
                else
                {
                    data = data.OrderBy(e=>e.ProductPrice).ToList();
                }
            }

            return data;
        }

        
    }
}
