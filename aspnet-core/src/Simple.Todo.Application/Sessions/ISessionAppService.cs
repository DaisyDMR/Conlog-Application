using System.Threading.Tasks;
using Abp.Application.Services;
using Simple.Todo.Sessions.Dto;

namespace Simple.Todo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
