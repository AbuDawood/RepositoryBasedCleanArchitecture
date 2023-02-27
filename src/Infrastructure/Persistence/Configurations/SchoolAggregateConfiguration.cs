using CleanArchitecture.Domain.Entities.Schools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class SchoolAggregateConfiguration :
    IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable(nameof(School) + "s");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(e => e.Address);

    }
}