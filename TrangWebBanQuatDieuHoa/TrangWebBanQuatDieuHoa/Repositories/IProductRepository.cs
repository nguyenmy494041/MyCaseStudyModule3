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
        IEnumerable<Product> GetAllFan();
        int Create(CreateProduct createProduct, IFormFile[] ImageFiles);
    }
}
