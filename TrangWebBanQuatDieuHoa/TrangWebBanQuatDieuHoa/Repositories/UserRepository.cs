using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Userss;
using TrangWebBanQuatDieuHoa.Models.ViewModel;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserRepository(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public User Create(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.IsDeleted = false;
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Edit(User user)
        {
            var editUser = context.Users.Attach(user);
            editUser.State = EntityState.Modified;
            context.SaveChanges();
            return user;
        }

        public IEnumerable<User> Get()
        {
            return from u in context.Users where u.IsDeleted == false select u;
        }

        public User Get(string id)
        {
            return (from u in context.Users where u.IsDeleted == false select u).FirstOrDefault();
        }

        public bool Remove(string id)
        {
            var userToRemove = context.Users.Find(id);
            if (userToRemove != null)
            {
                userToRemove.IsDeleted = true;
                return context.SaveChanges() > 0;
            }

            return false;
        }

        public User Them(RegisterViewModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Email,
                Address = model.Address,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                IsDeleted = false
            };
            if (model.ImageFile != null)
            {
                var uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/users");
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ImageFile.FileName)}";
                var filePath = Path.Combine(uploadFolder, fileName);
                using var fs = new FileStream(filePath, FileMode.Create);
                model.ImageFile.CopyTo(fs);
                user.ProfilePicture = fileName;
            }
            return user;
        }
    }
}
