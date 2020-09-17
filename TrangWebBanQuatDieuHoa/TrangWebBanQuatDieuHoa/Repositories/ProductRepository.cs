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



        public IEnumerable<Product> GetAllByCategory(int? categoryId)
        {

            List<Product> products = context.Products.Include(e => e.Specification)
              .Include(e => e.Images).Include(e => e.Category).ToList();
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







        public int Edit(CreateProduct editproduct, IFormFile[] ImageFiles)
        {
            var exit = context.Products.Find(editproduct.ProductId);
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
                //exit.BrandId = editproduct.BrandId;
                exit.Year = editproduct.Year;
                exit.Description = editproduct.Description;
                var spec = context.Specifications.FirstOrDefault(p => p.ProductId == exit.ProductId);

                spec.Dynamic = editproduct.Dynamic;
                spec.WindSpeed = editproduct.WindSpeed;
                spec.WindFlow = editproduct.WindFlow;
                spec.WindMode = editproduct.WindMode;
                spec.Control = editproduct.Control;
                spec.CollingRange = editproduct.CollingRange;
                spec.FanCageType = editproduct.FanCageType;
                spec.Noiselevel = editproduct.Noiselevel;
                spec.WaterConsumption = editproduct.WaterConsumption;
                spec.MachineModel = editproduct.MachineModel;
                spec.FilterTechnology = editproduct.FilterTechnology;
                spec.FilterCapacity = editproduct.FilterCapacity;
                spec.Pumping = editproduct.Pumping;
                spec.Safemode = editproduct.Safemode;
                spec.Temperature = editproduct.Temperature;
                spec.WaterPressure = editproduct.WaterPressure;
                spec.WarmUpTime = editproduct.WarmUpTime;
                spec.MaxTemperature = editproduct.MaxTemperature;               
                
              
                List<Image> images = new List<Image>();
                if (editproduct.ImageFiles != null)
                {
                    List<Image> imagesList = context.Images.ToList().FindAll(el => el.ProductId == exit.ProductId);
                    context.RemoveRange(imagesList);
                    context.SaveChangesAsync();

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
                        context.Images.Add(anh);

                    }
                    //exit.Images = images;
                  
                }
                return context.SaveChanges();
            }
            return -1;
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
            var pro = context.Products.Find(id);
            var spec = context.Specifications.FirstOrDefault(q => q.ProductId == pro.ProductId);
            var image = context.Images.Where(q => q.ProductId == pro.ProductId).ToList();
            return null;
        }

       
    }
}
