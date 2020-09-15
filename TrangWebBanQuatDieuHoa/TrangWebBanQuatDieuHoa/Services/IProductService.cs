using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models.Products;

namespace TrangWebBanQuatDieuHoa.Services
{
    public interface IProductService : IGeneralService<CreateProduct>
    {
        Product TaoMoiSanPham(CreateProduct model, IFormFile[] imageFiles);

    }
}
