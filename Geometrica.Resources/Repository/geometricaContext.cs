using Geometrica.Resources.Models;
using Microsoft.EntityFrameworkCore;


namespace Geometrica.Resources.Repository
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

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Countryid)
                    .ValueGeneratedNever()
                    .HasColumnName("countryid");

                entity.Property(e => e.Iso)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("iso");

                entity.Property(e => e.Iso3)
                    .HasMaxLength(3)
                    .HasColumnName("iso3")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Nicename)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("nicename");

                entity.Property(e => e.Numcode).HasColumnName("numcode");

                entity.Property(e => e.Phonecode).HasColumnName("phonecode");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.Gameid)
                    .ValueGeneratedNever()
                    .HasColumnName("gameid");

                entity.Property(e => e.Rightguesses).HasColumnName("rightguesses");

                entity.Property(e => e.Roundnum).HasColumnName("roundnum");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Wrongguesses).HasColumnName("wrongguesses");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_uid_fkey");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.Genderid)
                    .ValueGeneratedNever()
                    .HasColumnName("genderid");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("value");
            });

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

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.Countryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("player_countryid_fkey");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.Genderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("player_genderid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
