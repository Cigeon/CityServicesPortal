using CityServicesPortal.Petitions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityServicesPortal.Petitions.Infra.Data.Mappings
{
    public class PetitionMap : IEntityTypeConfiguration<Petition>
    {
        public void Configure(EntityTypeBuilder<Petition> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();

            //builder.Property(p => p.Created)
            //    .HasColumnType("datetime")
            //    .IsRequired();

        }
    }
}
