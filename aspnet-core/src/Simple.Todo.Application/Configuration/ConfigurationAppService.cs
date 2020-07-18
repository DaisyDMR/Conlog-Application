using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Simple.Todo.Configuration.Dto;

namespace Simple.Todo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TodoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
