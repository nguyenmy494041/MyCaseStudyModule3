using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Services
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext context;

        public BrandRepository(AppDbContext context)
        {
            this.context = context;
        }
        public int Create(Brand brand)
        {
            var exit = context.Brands.FirstOrDefault(e => e.BrandName == brand.BrandName);
            if (exit == null)
            {
                context.Brands.Add(brand);
                return context.SaveChanges();
            }

            return -1;
        }

        public int Delete(int id)
        {
            var deleteBrand = Get(id);
            if (deleteBrand != null)
            {
                context.Brands.Remove(deleteBrand);
                return context.SaveChanges();                
            }
            return -1;
        }

        public int Edit(Brand brand)
        {
            var edit = Get(brand.BrandId);
            if (edit== null || edit.BrandName == brand.BrandName)
            {
                return -1;
            }          
            edit.BrandName = brand.BrandName;
            return context.SaveChanges();
        }

        public Brand Get(int id)
        {
            return context.Brands.FirstOrDefault(e => e.BrandId == id);
        }

        public Brand Get(string brandname, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetsAllBrand()
        {
            return context.Brands;
        }
    }
}
