using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Products;

namespace TrangWebBanQuatDieuHoa.Repositories.Impl
{
    public class ProductRepositoryImpl : GeneralRepositoryImpl<Product, AppDbContext>, IProductRepository
    {
        public ProductRepositoryImpl(AppDbContext context) : base(context)

        {



        }

        public Task<CreateProduct> Add(CreateProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task<CreateProduct> Update(CreateProduct entity)
        {
            throw new NotImplementedException();
        }

        Task<CreateProduct> IGeneralRepository<CreateProduct>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<CreateProduct> IGeneralRepository<CreateProduct>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<CreateProduct>> IGeneralRepository<CreateProduct>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
