using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Simple.Todo.People.Dtos
{
    // AutoMapFrom attribute maps Person -> PersonDto
    [AutoMapFrom(typeof(Person))] 
    public class PersonDto : EntityDto
    {
        public string Name { get; set; }
    }
}
