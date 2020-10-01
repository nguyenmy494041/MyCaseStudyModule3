﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrangWebBanQuatDieuHoa.Models;

namespace TrangWebBanQuatDieuHoa.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200921040348_order")]
    partial class order
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Ordersss.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PhuongXaId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<long>("ProductPrice")
                        .HasColumnType("bigint");

                    b.Property<int>("QuanHuyenId")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("TinhThanhId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("PhuongXaId")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Ordersss.PhuongXa", b =>
                {
                    b.Property<int>("PhuongXaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhuongHayXa")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("QuanHuyenId")
                        .HasColumnType("int");

                    b.Property<string>("TenPhuongXa")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("TinhThanhId")
                        .HasColumnType("int");

                    b.HasKey("PhuongXaId");

                    b.HasIndex("QuanHuyenId");

                    b.ToTable("PhuongXa");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Ordersss.QuanHuyen", b =>
                {
                    b.Property<int>("QuanHuyenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuanHayHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("TenQuanHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("TinhThanhId")
                        .HasColumnType("int");

                    b.HasKey("QuanHuyenId");

                    b.HasIndex("TinhThanhId");

                    b.ToTable("QuanHuyen");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Ordersss.TinhThanh", b =>
                {
                    b.Property<int>("TinhThanhId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaBuuDien")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("TenTinhThanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("TinhHayThanhPho")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("TinhThanhId");

                    b.ToTable("TinhThanh");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Products.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Products.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Products.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Products.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(50000);

                    b.Property<string>("MadeIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Manufactures")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<long>("ProductPrice")
                        .HasColumnType("bigint");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("TankCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Utilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Wattage")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Products.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollingRange")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Control")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Dynamic")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("FanCageType")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("FilterCapacity")
                        .HasColumnType("int");

                    b.Property<string>("FilterTechnology")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("MachineModel")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int?>("MaxTemperature")
                        .HasColumnType("int");

                    b.Property<string>("Noiselevel")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("NumberFilterCores")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Pumping")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Safemode")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("WarmUpTime")
                        .HasColumnType("int");

                    b.Property<string>("WaterConsumption")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<float?>("WaterPressure")
                        .HasColumnType("real");

                    b.Property<int?>("WindFlow")
                        .HasColumnType("int");

                    b.Property<string>("WindMode")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("WindSpeed")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Ordersss.Order", b =>
                {
                    b.HasOne("TrangWebBanQuatDieuHoa.Models.Ordersss.PhuongXa", "PhuongXa")
                        .WithOne("Order")
                        .HasForeignKey("TrangWebBanQuatDieuHoa.Models.Ordersss.Order", "PhuongXaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Ordersss.PhuongXa", b =>
                {
                    b.HasOne("TrangWebBanQuatDieuHoa.Models.Ordersss.QuanHuyen", "QuanHuyen")
                        .WithMany("PhuongXas")
                        .HasForeignKey("QuanHuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Ordersss.QuanHuyen", b =>
                {
                    b.HasOne("TrangWebBanQuatDieuHoa.Models.Ordersss.TinhThanh", "TinhThanh")
                        .WithMany("QuanHuyens")
                        .HasForeignKey("TinhThanhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Products.Image", b =>
                {
                    b.HasOne("TrangWebBanQuatDieuHoa.Models.Products.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Products.Product", b =>
                {
                    b.HasOne("TrangWebBanQuatDieuHoa.Models.Products.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrangWebBanQuatDieuHoa.Models.Products.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrangWebBanQuatDieuHoa.Models.Products.Specification", b =>
                {
                    b.HasOne("TrangWebBanQuatDieuHoa.Models.Products.Product", "Product")
                        .WithOne("Specification")
                        .HasForeignKey("TrangWebBanQuatDieuHoa.Models.Products.Specification", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
