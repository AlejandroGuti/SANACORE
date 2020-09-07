using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SANA.Entities
{
    public partial class SANAContext : DbContext
    {
        public SANAContext()
        {
        }

        public SANAContext(DbContextOptions<SANAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomOrders> CustomOrders { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersProducts> OrdersProducts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsCategory> ProductsCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=RENTATIC-0286;Database=SANA;Persist Security Info=True;User ID=sa;Password=Software1;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategory).HasColumnName("Id_Category");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FName)
                    .HasColumnName("F_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdCustomer).HasColumnName("Id_Customer");

                entity.Property(e => e.LName)
                    .HasColumnName("L_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomOrders>(entity =>
            {
                entity.ToTable("Custom_Orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkIdCustomer).HasColumnName("FkId_Customer");

                entity.Property(e => e.FkIdOrders).HasColumnName("FkId_Orders");

                entity.Property(e => e.GenerationDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.FkIdCustomerNavigation)
                    .WithMany(p => p.CustomOrders)
                    .HasForeignKey(d => d.FkIdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Custom_Orders");

                entity.HasOne(d => d.FkIdOrdersNavigation)
                    .WithMany(p => p.CustomOrders)
                    .HasForeignKey(d => d.FkIdOrders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Orders_Customer");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrders).HasColumnName("Id_Orders");
            });

            modelBuilder.Entity<OrdersProducts>(entity =>
            {
                entity.ToTable("Orders_Products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.FkIdOrders).HasColumnName("FkId_Orders");

                entity.Property(e => e.FkIdProducts).HasColumnName("FkId_Products");

                entity.Property(e => e.Tpprice)
                    .HasColumnName("TPPrice")
                    .HasColumnType("money");

                entity.HasOne(d => d.FkIdOrdersNavigation)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.FkIdOrders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Orders_Products");

                entity.HasOne(d => d.FkIdProductsNavigation)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.FkIdProducts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Products_Orders");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdProduct).HasColumnName("Id_Product");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductsCategory>(entity =>
            {
                entity.ToTable("Products_Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkIdCategory).HasColumnName("FkId_Category");

                entity.Property(e => e.FkIdProducts).HasColumnName("FkId_Products");

                entity.HasOne(d => d.FkIdCategoryNavigation)
                    .WithMany(p => p.ProductsCategory)
                    .HasForeignKey(d => d.FkIdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Category_Products");

                entity.HasOne(d => d.FkIdProductsNavigation)
                    .WithMany(p => p.ProductsCategory)
                    .HasForeignKey(d => d.FkIdProducts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Products_Category");
            });
        }
    }
}
