using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities.Todos;

namespace CleanArchitecture.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
