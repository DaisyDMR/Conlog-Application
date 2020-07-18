using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Simple.Todo.Controllers
{
    public abstract class TodoControllerBase: AbpController
    {
        protected TodoControllerBase()
        {
            LocalizationSourceName = TodoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
