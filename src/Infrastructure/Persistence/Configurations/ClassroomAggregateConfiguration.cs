using CleanArchitecture.Domain.Entities.Classroom;
using CleanArchitecture.Domain.Entities.Parents;
using CleanArchitecture.Domain.Entities.Schools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class ClassroomAggregateConfiguration :
    IEntityTypeConfiguration<Classroom>,
    IEntityTypeConfiguration<ClassroomStudent>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        builder.ToTable("Classrooms");
        builder.HasKey(x => x.Id);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(x => x.SchoolId)
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<ClassroomStudent> builder)
    {
        builder.ToTable("ClassroomStudents");

        builder.HasKey(x => new { x.StudentId, x.ClassroomId });

        builder.HasOne<Classroom>()
            .WithMany(x => x.Students)
            .HasForeignKey(e => e.ClassroomId)
            .IsRequired();

        builder.HasOne<Child>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .IsRequired();
    }
}
