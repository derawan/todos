using AutoMapper;
using Todo.Domain.Models;
using Todo.Mapping;
using Todo.Resources;

namespace Todo.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<TodoItem, TodoResource>();
        }
    }
}
