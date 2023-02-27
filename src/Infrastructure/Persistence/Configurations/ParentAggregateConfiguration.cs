using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Parents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;
public class ParentAggregateConfiguration :
    IEntityTypeConfiguration<Parent>,
    IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.ToTable("Parents");

        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Children)
            .WithOne()
            .HasForeignKey(e => e.ParentId)
            .IsRequired();

    }

    public void Configure(EntityTypeBuilder<Child> builder)
    {
        builder.ToTable("Children");

        builder.HasKey(e => e.Id);
    }
}
