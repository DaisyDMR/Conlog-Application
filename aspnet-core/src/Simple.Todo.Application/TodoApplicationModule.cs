using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Simple.Todo.Authorization;

namespace Simple.Todo
{
    [DependsOn(
        typeof(TodoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TodoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TodoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TodoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
