using System.Threading.Tasks;
using Abp.Application.Services;
using Simple.Todo.Authorization.Accounts.Dto;

namespace Simple.Todo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
