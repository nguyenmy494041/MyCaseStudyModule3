using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models.Products;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetAllByCategory(int? categoryId);
        int Create(CreateProduct createProduct, IFormFile[] ImageFiles);
        int Edit(CreateProduct editproduct, IFormFile[] ImageFiles);
        int Delete(int id);
        CreateProduct ConvertToCreateProduct(int id);
      

    }
}
