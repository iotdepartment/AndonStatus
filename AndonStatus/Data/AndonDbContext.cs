using System;
using System.Collections.Generic;
using AndonStatus.Models;
using Microsoft.EntityFrameworkCore;

namespace AndonStatus.Data;

public partial class AndonDbContext : DbContext
{
    public AndonDbContext()
    {
    }

    public AndonDbContext(DbContextOptions<AndonDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Andon> Andons { get; set; }

    public virtual DbSet<AndonRegistro> AndonRegistros { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Andon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Andon__3214EC0734E6F54F");
        });

        modelBuilder.Entity<AndonRegistro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AndonReg__3214EC071C97A600");

            entity.Property(e => e.FechaHora).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Andon).WithMany(p => p.AndonRegistros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AndonRegistro_Andon");

            entity.HasOne(d => d.Estado).WithMany(p => p.AndonRegistros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AndonRegistro_Estado");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estado__3214EC071B584B55");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
