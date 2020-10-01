using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public HelperController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [Route("/Helper/Loc/{categoryId}/{brandId}/{price}/{sortByPrice}")]
        [HttpGet]
        public List<Product> Loc(int? categoryId, int? brandId, int? price, int? sortByPrice)
        {

            List<Product> listproduct = productRepository.LocSanPham(categoryId, brandId, price, sortByPrice).ToList();
            return listproduct;
        }
    }
}
