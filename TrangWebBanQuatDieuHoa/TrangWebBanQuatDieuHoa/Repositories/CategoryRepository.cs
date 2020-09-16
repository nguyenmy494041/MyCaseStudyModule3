using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Products;

namespace TrangWebBanQuatDieuHoa.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public int Create(Category category)
        {
            var exit = context.Categories.FirstOrDefault(e => e.CategoryName == category.CategoryName);
            if (exit == null)
            {
                context.Categories.Add(category);
                return context.SaveChanges();
            }

            return -1;
        }

        public int Delete(int id)
        {
            var delete = Get(id);
            if (delete != null)
            {
                context.Categories.Remove(delete);
                return context.SaveChanges();
            }
            return -1;
        }

        public int Edit(Category category)
        {
            var edit = Get(category.CategoryId);
            if (edit != null && edit.CategoryName != category.CategoryName)
            {
                edit.CategoryName = category.CategoryName;
                return context.SaveChanges();
            }
            return -1;
        }

        public Category Get(int id)
        {
            return context.Categories.Find(id);
        }

        public IEnumerable<Category> GetsAll()
        {
            return context.Categories.ToList();
        }
    }
}
