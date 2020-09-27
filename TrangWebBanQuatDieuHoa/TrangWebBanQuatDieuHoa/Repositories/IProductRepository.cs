using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models.Ordersss;
using TrangWebBanQuatDieuHoa.Models.Products;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public interface IProductRepository
    {

        List<Product> GetAllByCategory(int? categoryId);
        int Create(CreateProduct createProduct, IFormFile[] ImageFiles);
        Product Edit(CreateProduct editproduct, IFormFile[] ImageFiles);
        int Delete(int id);
        CreateProduct ConvertToCreateProduct(int id);
        Product Get(int id);
        List<Product> Gets(int caregoryid, int productid);
        List<Product> Search(string name);

        List<Product> LocSanPham(int? categoryId, int? brandId, int? price, int? sortByPrice);
      

    }
}
