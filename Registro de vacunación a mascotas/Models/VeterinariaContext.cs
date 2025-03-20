using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Registro_de_vacunación_a_mascotas.Models;

public partial class VeterinariaContext : DbContext
{
    public VeterinariaContext()
    {
    }

    public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aplicacionesvacunas> Aplicacionesvacunas { get; set; }

    public virtual DbSet<Mascotas> Mascotas { get; set; }

    public virtual DbSet<Tipos> Tipos { get; set; }

    public virtual DbSet<Vacunas> Vacunas { get; set; }

    public virtual DbSet<Vwhistorialvacunas> Vwhistorialvacunas { get; set; }

    public virtual DbSet<Vwmascotasconmasvacunas> Vwmascotasconmasvacunas { get; set; }

    public virtual DbSet<Vwmascotassinvacunas> Vwmascotassinvacunas { get; set; }

    public virtual DbSet<Vwmascotasvacunasfaltantes> Vwmascotasvacunasfaltantes { get; set; }

    public virtual DbSet<Vwregistro> Vwregistro { get; set; }

    public virtual DbSet<Vwvacunassinaplicar> Vwvacunassinaplicar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;password=root;user=root;database=veterinaria;port=3307", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.3.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Aplicacionesvacunas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aplicacionesvacunas");

            entity.HasIndex(e => e.IdMascota, "fkAM");

            entity.HasIndex(e => e.IdVacuna, "fkAV");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FechaAplicacion).HasColumnType("datetime");
            entity.Property(e => e.IdMascota).HasColumnType("int(11)");
            entity.Property(e => e.IdVacuna).HasColumnType("int(11)");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.Aplicacionesvacunas)
                .HasForeignKey(d => d.IdMascota)
                .HasConstraintName("fkAM");

            entity.HasOne(d => d.IdVacunaNavigation).WithMany(p => p.Aplicacionesvacunas)
                .HasForeignKey(d => d.IdVacuna)
                .HasConstraintName("fkAV");
        });

        modelBuilder.Entity<Mascotas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mascotas");

            entity.HasIndex(e => e.IdTipo, "IdTipo");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.IdTipo).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Mascotas)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("mascotas_ibfk_1");
        });

        modelBuilder.Entity<Tipos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipos");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vacunas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vacunas");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwhistorialvacunas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwhistorialvacunas");

            entity.Property(e => e.FechaAplicacion).HasColumnType("datetime");
            entity.Property(e => e.NombreMascota)
                .HasMaxLength(100)
                .HasColumnName("nombreMascota");
            entity.Property(e => e.NombreTipo).HasMaxLength(100);
            entity.Property(e => e.NombreVacuna).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwmascotasconmasvacunas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwmascotasconmasvacunas");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdTipo).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TotalVacunas).HasColumnType("bigint(21)");
        });

        modelBuilder.Entity<Vwmascotassinvacunas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwmascotassinvacunas");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdTipo).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwmascotasvacunasfaltantes>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwmascotasvacunasfaltantes");

            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Idtipo)
                .HasColumnType("int(11)")
                .HasColumnName("idtipo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vwregistro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwregistro");

            entity.Property(e => e.FechaAplicacion).HasColumnType("datetime");
            entity.Property(e => e.Mascota)
                .HasMaxLength(100)
                .HasColumnName("mascota");
            entity.Property(e => e.Vacuna)
                .HasMaxLength(100)
                .HasColumnName("vacuna");
        });

        modelBuilder.Entity<Vwvacunassinaplicar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwvacunassinaplicar");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
