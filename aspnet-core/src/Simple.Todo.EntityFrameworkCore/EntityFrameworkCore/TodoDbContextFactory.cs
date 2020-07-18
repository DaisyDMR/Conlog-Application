using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Simple.Todo.Configuration;
using Simple.Todo.Web;

namespace Simple.Todo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TodoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TodoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TodoConsts.ConnectionStringName));

            return new TodoDbContext(builder.Options);
        }
    }
}
