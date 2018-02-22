using CityServicesPortal.Domain.Core;
using Microsoft.EntityFrameworkCore;

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
                .HasForeignKey(pv => pv.PetitionId);

            modelBuilder.Entity<PetitionVoter>()
                .HasOne(pv => pv.PetitionUser)
                .WithMany(pu => pu.PetitionVoters)
                .HasForeignKey(pv => pv.PetitionUserId);
        }
    }
}
