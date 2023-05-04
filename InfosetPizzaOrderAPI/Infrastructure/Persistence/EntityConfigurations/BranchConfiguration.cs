using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(x => x.Id).UseSerialColumn();
            builder.Property(x => x.Name).HasColumnType("varchar(100)");
            builder.Property(x => x.Latitude).HasColumnType("double precision");
            builder.Property(x => x.Longitude).HasColumnType("double precision");
        }
    }
}
