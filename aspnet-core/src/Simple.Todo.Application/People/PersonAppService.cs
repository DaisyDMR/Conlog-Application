using Abp.Application.Services;
using Abp.Domain.Repositories;
using Simple.Todo.People.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Todo.People
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        // ABP provides that we can directly inject IRepository<Person> (without creating any repository class)
        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        // This method uses async pattern that is supported by ASP.NET Boilerplate
        public async Task<GetAllPeopleOutput> GetAllPeople()
        {
            var people = await _personRepository.GetAllListAsync();
            return new GetAllPeopleOutput
            {
                People = ObjectMapper.Map<List<PersonDto>>(people) 
            };
        }
    }
}
