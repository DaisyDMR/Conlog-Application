using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Simple.Todo.Authorization.Roles;
using Simple.Todo.Authorization.Users;
using Simple.Todo.MultiTenancy;
using Simple.Todo.People;
using Simple.Todo.Tasks;

namespace Simple.Todo.EntityFrameworkCore
{
    public class TodoDbContext : AbpZeroDbContext<Tenant, Role, User, TodoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Task> Task { get; set; }
    }
}
