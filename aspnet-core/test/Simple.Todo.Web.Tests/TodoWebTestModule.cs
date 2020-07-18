using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Simple.Todo.EntityFrameworkCore;
using Simple.Todo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Simple.Todo.Web.Tests
{
    [DependsOn(
        typeof(TodoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TodoWebTestModule : AbpModule
    {
        public TodoWebTestModule(TodoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TodoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TodoWebMvcModule).Assembly);
        }
    }
}