using Geometrica.Auth.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Geometrica.Auth.Repository
{
    public partial class geometricaContext : DbContext
    {
        public geometricaContext()
        {
        }

        public geometricaContext(DbContextOptions<geometricaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("player_pkey");

                entity.ToTable("player");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("uid");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("email");

                entity.Property(e => e.Genderid).HasColumnName("genderid");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("nickname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");
               });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
