using System.Threading.Tasks;
using Simple.Todo.Configuration.Dto;

namespace Simple.Todo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
