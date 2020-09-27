using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models.Userss;
using TrangWebBanQuatDieuHoa.Models.ViewModel;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();

        User Get(string id);

        User Create(User product);

        User Edit(User product);

        bool Remove(string id);
        User Them(RegisterViewModel model);
    }
}
