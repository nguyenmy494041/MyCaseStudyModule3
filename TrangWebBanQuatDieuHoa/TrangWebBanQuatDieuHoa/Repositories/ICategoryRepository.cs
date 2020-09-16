using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models.Products;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetsAll();
        Category Get(int id);
        int Create(Category category);
        int Edit(Category category);
        int Delete(int id);
    }
}
