using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class ExamenContext : DbContext
{
    public ExamenContext()
    {
    }

    public ExamenContext(DbContextOptions<ExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Distrito> Distritos { get; set; } = null!;
    public virtual DbSet<Finca> Fincas { get; set; } = null!;
    public virtual DbSet<Persona> Personas { get; set; } = null!;
    public virtual DbSet<Propietario> Propietarios { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Examen;Integrated Security=True;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Finca>(entity =>
        {
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");

            entity.Property(e => e.Numero).HasMaxLength(10);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.PersonaId).HasColumnName("PersonaID");

            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.Property(e => e.Porcentaje).HasColumnType("numeric(15, 8)");

            entity.HasOne(d => d.Finca)
                .WithMany(p => p.Propietarios)
                .HasForeignKey(d => d.FincaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Propietarios_Fincas");

            entity.HasOne(d => d.Persona)
                .WithMany(p => p.Propietarios)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Propietarios_Personas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}