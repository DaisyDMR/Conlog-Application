using Abp.Application.Services;
using Simple.Todo.People.Dtos;
using System.Threading.Tasks;

namespace Simple.Todo.People
{
    public interface IPersonAppService : IApplicationService
    {
        Task<GetAllPeopleOutput> GetAllPeople();
    }
}
