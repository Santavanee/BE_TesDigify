using System;
using System.Collections.Generic;
using Common.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace RestAPI;

public partial class TesDigifyContext : DbContext
{
    public TesDigifyContext()
    {
    }

    public TesDigifyContext(DbContextOptions<TesDigifyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GQBP2AS\\SQLEXPRESS;Database=TesDigify;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D814315B6C");

            entity.ToTable("Customer");

            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.DirectorName).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FileNpwp)
                .HasMaxLength(255)
                .HasColumnName("FileNPWP");
            entity.Property(e => e.FilePowerOfAttorey).HasMaxLength(255);
            entity.Property(e => e.Npwp)
                .HasMaxLength(50)
                .HasColumnName("NPWP");
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Picname)
                .HasMaxLength(255)
                .HasColumnName("PICName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
