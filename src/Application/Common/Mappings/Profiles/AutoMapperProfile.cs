using Assignment.Application.TodoLists.Queries.GetTodos;
using Assignment.Domain.Entities;

namespace Assignment.Application.Common.Mappings.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TodoItem, TodoItemDto>();
    }   
}
