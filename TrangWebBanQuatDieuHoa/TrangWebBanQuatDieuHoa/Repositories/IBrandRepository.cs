using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models.Products;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetsAllBrand();
        Brand Get(int id );
        int Create(Brand brand);
        int Edit(Brand brand);
        int Delete(int id);
    }
}
