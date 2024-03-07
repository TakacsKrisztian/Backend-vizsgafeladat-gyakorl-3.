using Microsoft.EntityFrameworkCore;

namespace Takács_Krisztián_backend3.Models;

public partial class UszoebContext : DbContext
{
    public UszoebContext()
    {
    }

    public UszoebContext(DbContextOptions<UszoebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Orszagok> Orszagoks { get; set; }

    public virtual DbSet<Szamok> Szamoks { get; set; }

    public virtual DbSet<Versenyzok> Versenyzoks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=uszoeb;user=root;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_hungarian_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Orszagok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orszagok");

            entity.HasIndex(e => e.Nobid, "nobid").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(60)
                .HasColumnName("nev");
            entity.Property(e => e.Nobid)
                .HasMaxLength(3)
                .HasColumnName("nobid");
        });

        modelBuilder.Entity<Szamok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("szamok");

            entity.HasIndex(e => e.Versenyzoid, "versenyzoid");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(40)
                .HasColumnName("nev");
            entity.Property(e => e.Versenyzoid)
                .HasColumnType("int(11)")
                .HasColumnName("versenyzoid");

            entity.HasOne(d => d.Versenyzo).WithMany(p => p.Szamoks)
                .HasForeignKey(d => d.Versenyzoid)
                .HasConstraintName("szamok_ibfk_1");
        });

        modelBuilder.Entity<Versenyzok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("versenyzok");

            entity.HasIndex(e => e.Nev, "nev").IsUnique();

            entity.HasIndex(e => e.Orszagid, "orszagid");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nem)
                .HasColumnType("text")
                .HasColumnName("nem");
            entity.Property(e => e.Nev)
                .HasMaxLength(60)
                .HasColumnName("nev");
            entity.Property(e => e.Orszagid)
                .HasColumnType("int(11)")
                .HasColumnName("orszagid");

            entity.HasOne(d => d.Orszag).WithMany(p => p.Versenyzoks)
                .HasForeignKey(d => d.Orszagid)
                .HasConstraintName("versenyzok_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}