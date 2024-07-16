using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIBPO.Models;

public partial class ObpotestContext : DbContext
{
    public ObpotestContext()
    {
    }

    public ObpotestContext(DbContextOptions<ObpotestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Storeproductmapping> Storeproductmappings { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__PRODUCT__B40CC6CDE8F502B3");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__STORE__3B82F1012DD13DFF");

            entity.ToTable("STORE");

            entity.Property(e => e.StoreName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<Storeproductmapping>(entity =>
        {
            entity.HasKey(e => e.MappingId).HasName("PK__STOREPRO__8B57819D5105B63D");

            entity.ToTable("STOREPRODUCTMAPPING");

            entity.Property(e => e.MappingId).ValueGeneratedNever();
            entity.Property(e => e.Stock).HasDefaultValue(0);

            entity.HasOne(d => d.Product).WithMany(p => p.Storeproductmappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOREPROD__Produ__3F466844");

            entity.HasOne(d => d.Store).WithMany(p => p.Storeproductmappings)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOREPROD__Store__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
