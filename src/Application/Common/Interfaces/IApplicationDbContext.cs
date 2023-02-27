using CleanArchitecture.Domain.Entities.Classroom;
using CleanArchitecture.Domain.Entities.Parents;
using CleanArchitecture.Domain.Entities.Schools;
using CleanArchitecture.Domain.Entities.Todos;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Parent> Parents { get; }
    DbSet<Child> Children { get; }
    DbSet<School> Schools { get; }
    DbSet<Classroom> Classrooms { get; }
    DbSet<ClassroomStudent> ClassroomStudents { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
