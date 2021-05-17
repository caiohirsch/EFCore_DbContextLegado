using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCore.Legado
{
    public partial class HeroAppContext : DbContext
    {
        public HeroAppContext()
        {
        }

        public HeroAppContext(DbContextOptions<HeroAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arma> Armas { get; set; }
        public virtual DbSet<Batalha> Batalhas { get; set; }
        public virtual DbSet<Heroi> Herois { get; set; }
        public virtual DbSet<HeroisBatalha> HeroisBatalhas { get; set; }
        public virtual DbSet<IdentidadesSecreta> IdentidadesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HeroApp;Data Source=MASTER\\SQLEXPRESS01");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Arma>(entity =>
            {
                entity.HasIndex(e => e.HeroiId, "IX_Armas_HeroiId");

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.Armas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<HeroisBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });

                entity.HasIndex(e => e.HeroiId, "IX_HeroisBatalhas_HeroiId");

                entity.HasOne(d => d.Batalha)
                    .WithMany(p => p.HeroisBatalhas)
                    .HasForeignKey(d => d.BatalhaId);

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.HeroisBatalhas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<IdentidadesSecreta>(entity =>
            {
                entity.HasIndex(e => e.HeroiId, "IX_IdentidadesSecretas_HeroiId")
                    .IsUnique();

                entity.HasOne(d => d.Heroi)
                    .WithOne(p => p.IdentidadesSecreta)
                    .HasForeignKey<IdentidadesSecreta>(d => d.HeroiId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
