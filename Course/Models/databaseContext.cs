using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Course
{
    public partial class databaseContext : DbContext
    {
        public databaseContext()
        {
        }

        public databaseContext(DbContextOptions<databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dog> Dogs { get; set; } = null!;
        public virtual DbSet<DogRace> DogRaces { get; set; } = null!;
        public virtual DbSet<Track> Tracks { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;
        public virtual DbSet<Trap> Traps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\Vlapssk\\Visual-Course\\database.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>(entity =>
            {
                entity.ToTable("Dog");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CurrentLosingSequence).HasColumnName("Current Losing Sequence");

                entity.Property(e => e.LastRun)
                    .HasColumnType("STRING")
                    .HasColumnName("Last Run");

                entity.Property(e => e.LongestLosingSequence).HasColumnName("Longest Losing Sequence");

                entity.Property(e => e.LongestWinningSequence).HasColumnName("Longest Winning Sequence");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.StrikeRate)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Strike Rate");
            });

            modelBuilder.Entity<DogRace>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Date, e.DogId });

                entity.ToTable("Dog Race");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("STRING");

                entity.Property(e => e.DogId).HasColumnName("Dog ID");

                entity.Property(e => e.CalcTime)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Calc Time");

                entity.Property(e => e.ChesterRating)
                    .HasColumnType("STRING")
                    .HasColumnName("Chester Rating");

                entity.Property(e => e.Distance).HasColumnType("STRING");

                entity.Property(e => e.Finish).HasColumnType("STRING");

                entity.Property(e => e.Going).HasColumnType("STRING");

                entity.Property(e => e.Grade).HasColumnType("STRING");

                entity.Property(e => e.Sectional).HasColumnType("DOUBLE");

                entity.Property(e => e.Sp)
                    .HasColumnType("STRING")
                    .HasColumnName("SP");

                entity.Property(e => e.Time).HasColumnType("DOUBLE");

                entity.Property(e => e.TrackName)
                    .HasColumnType("STRING")
                    .HasColumnName("Track Name");

                entity.Property(e => e.TrainerId).HasColumnName("Trainer ID");

                entity.HasOne(d => d.Dog)
                    .WithMany(p => p.DogRaces)
                    .HasForeignKey(d => d.DogId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TrackNameNavigation)
                    .WithMany(p => p.DogRaces)
                    .HasForeignKey(d => d.TrackName);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.DogRaces)
                    .HasForeignKey(d => d.TrainerId);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("Track");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.TotalWinners).HasColumnName("Total winners");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("Trainer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AverageSp)
                    .HasColumnType("STRING")
                    .HasColumnName("Average SP");

                entity.Property(e => e.FavWinPercent)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Fav Win Percent");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.NoFavs).HasColumnName("No Favs");

                entity.Property(e => e.NoWinFavs).HasColumnName("No Win Favs");

                entity.Property(e => e.ProfitLossToStake)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Profit Loss to stake");

                entity.Property(e => e.StartingFavP)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Starting Fav P");

                entity.Property(e => e.TrackName)
                    .HasColumnType("STRING")
                    .HasColumnName("Track Name");

                entity.Property(e => e.WinnersP)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Winners_P");

                entity.HasOne(d => d.TrackNameNavigation)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.TrackName);
            });

            modelBuilder.Entity<Trap>(entity =>
            {
                entity.HasKey(e => new { e.TrackName, e.Number });

                entity.ToTable("Trap");

                entity.Property(e => e.TrackName)
                    .HasColumnType("STRING")
                    .HasColumnName("Track Name");

                entity.Property(e => e.WinPercent)
                    .HasColumnType("STRING")
                    .HasColumnName("Win Percent");

                entity.HasOne(d => d.TrackNameNavigation)
                    .WithMany(p => p.Traps)
                    .HasForeignKey(d => d.TrackName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
