using Abp.Application.Services;
using Simple.Todo.MultiTenancy.Dto;

namespace Simple.Todo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

