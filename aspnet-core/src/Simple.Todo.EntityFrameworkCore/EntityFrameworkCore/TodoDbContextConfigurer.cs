using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Simple.Todo.EntityFrameworkCore
{
    public static class TodoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TodoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TodoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
