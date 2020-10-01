using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Migrations;
using TrangWebBanQuatDieuHoa.Models.Ordersss;
using TrangWebBanQuatDieuHoa.Models.Products;
using TrangWebBanQuatDieuHoa.Models.Userss;

namespace TrangWebBanQuatDieuHoa.Models
{
    public class AppDbContext: IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasOne<Specification>(p => p.Specification)
                .WithOne(s => s.Product)
                .HasForeignKey<Specification>(s => s.ProductId);

            modelBuilder.Entity<Image>()
                .HasOne<Product>(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Product>()
               .HasOne<Category>(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
               .HasOne<Brand>(p => p.Brand)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.BrandId);

                   modelBuilder.Entity<QuanHuyen>()
                 .HasOne<TinhThanh>(p => p.TinhThanh)
                 .WithMany(c => c.QuanHuyens)
                 .HasForeignKey(p => p.TinhThanhId);

                   modelBuilder.Entity<PhuongXa>()
                  .HasOne<QuanHuyen>(p => p.QuanHuyen)
                  .WithMany(c => c.PhuongXas)
                  .HasForeignKey(p => p.QuanHuyenId);

            modelBuilder.Entity<PhuongXa>()
                .HasOne<Order>(p => p.Order)
                .WithOne(s => s.PhuongXa)
                .HasForeignKey<Order>(s => s.PhuongXaId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<TinhThanh> TinhThanh { get; set; }
        public DbSet<QuanHuyen> QuanHuyen { get; set; }
        public DbSet<PhuongXa> PhuongXa { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<State> States { get; set; }

    }
}
