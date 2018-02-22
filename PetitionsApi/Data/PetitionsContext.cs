using CityServicesPortal.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetitionsApi.Data
{
    public class PetitionsContext : DbContext
    {
        public DbSet<Petition> Petitions { get; set; }
        public DbSet<PetitionArea> PetitionAreas { get; set; }
        public DbSet<PetitionUser> PetitionUsers { get; set; }

        public PetitionsContext(DbContextOptions<PetitionsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetitionVoter>()
                .HasKey(t => new { t.PetitionId, t.PetitionUserId });

            modelBuilder.Entity<PetitionVoter>()
                .HasOne(pv => pv.Petition)
                .WithMany(p => p.PetitionVoters)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(pv => pv.PetitionId);


            modelBuilder.Entity<PetitionVoter>()
                .HasOne(pv => pv.PetitionUser)
                .WithMany(pu => pu.PetitionVoters)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(pv => pv.PetitionUserId);
        }
    }
}
