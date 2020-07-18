using System.Linq;
using Microsoft.EntityFrameworkCore;
using Simple.Todo.People;
using Simple.Todo.Tasks;

namespace Simple.Todo.EntityFrameworkCore.Seed.Host
{
    public class DefaultTasksCreator
    {
        private readonly TodoDbContext _context;

        public DefaultTasksCreator(TodoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreatePeople();
        }

        private void CreatePeople()
        {
            var defaultPersonJethro = _context.People.IgnoreQueryFilters().FirstOrDefault(e => e.Name == "Jethro");

            if (defaultPersonJethro == null)
            {
                defaultPersonJethro = new Person { Name = "Jethro" };
                _context.People.Add(defaultPersonJethro);
                _context.SaveChanges();

                var defaultTask = _context.Task.IgnoreQueryFilters().FirstOrDefault(e => e.Description == "Review Code");

                if (defaultTask == null)
                {
                    defaultTask = new Task { Description = "Review Code", State = TaskState.Active, AssignedPersonId = defaultPersonJethro.Id, CreationTime = System.DateTime.Now };
                    _context.Task.Add(defaultTask);
                    _context.SaveChanges();
                }
            }
        }
    }
}
