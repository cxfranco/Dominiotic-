using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodApi.Entities.Models
{
    public partial class FoodContext : DbContext
    {
        public FoodContext()
        {
        }

        public FoodContext(DbContextOptions<FoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<PayType> PayType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:xamarin.database.windows.net,1433;Initial Catalog=demonetcore;Persist Security Info=False;User ID=xamarin;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("category");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("customer");

                entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Identification)
                    .HasColumnName("identification")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK_Order");

                entity.ToTable("order");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.AddressDelivery)
                    .HasColumnName("addressDelivery")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DateOrder)
                    .HasColumnName("dateOrder")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");

                entity.Property(e => e.IdPayType).HasColumnName("idPayType");

                entity.Property(e => e.IdSeller).HasColumnName("idSeller");

                entity.Property(e => e.Observation)
                    .HasColumnName("observation")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubTotal)
                    .HasColumnName("subTotal")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TaxPercent)
                    .HasColumnName("taxPercent")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Order_customer");

                entity.HasOne(d => d.IdPayTypeNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdPayType)
                    .HasConstraintName("FK_Order_payType");

                entity.HasOne(d => d.IdSellerNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdSeller)
                    .HasConstraintName("FK_Order_seller");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdOrder, e.Sequence })
                    .HasName("PK_OrderDetail");

                entity.ToTable("orderDetail");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.DicountPercent)
                    .HasColumnName("dicountPercent")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SubTotal)
                    .HasColumnName("subTotal")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TaxPercent)
                    .HasColumnName("taxPercent")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unitPrice")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_OrderDetail_product");
            });

            modelBuilder.Entity<PayType>(entity =>
            {
                entity.HasKey(e => e.IdPayType);

                entity.ToTable("payType");

                entity.Property(e => e.IdPayType).HasColumnName("idPayType");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("product");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_product_category");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.IdSeller);

                entity.ToTable("seller");

                entity.Property(e => e.IdSeller).HasColumnName("idSeller");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
