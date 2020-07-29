using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Storing
{
    public partial class PizzaStoreDbContext : DbContext
    {
        public PizzaStoreDbContext()
        {
        }

        public PizzaStoreDbContext(DbContextOptions<PizzaStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaTopping> PizzaTopping { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=PizzaStoreDb;user id=sa;password=Password12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CrustName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Orders", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Qty).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_PizzaOrders_StoreId");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_PizzaOrders_UserId");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PizzaPrice).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId)
                    .HasConstraintName("FK_Pizza_CrustId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_Pizza_SizeId");
            });

            modelBuilder.Entity<PizzaTopping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PizzaTopping", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ToppingId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Pizza)
                    .WithMany()
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_PizzaTopping_PizzaId");

                entity.HasOne(d => d.Topping)
                    .WithMany()
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_PizzaTopping_ToppingId");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SizeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK_Pizza_Stores");

                entity.ToTable("Stores", "Pizza");

                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ToppingName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Pizza_Users");

                entity.ToTable("Users", "Pizza");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastOrderDate)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
