using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Simple.Todo.People;
using Simple.Todo.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Todo.Tasks
{

    /// <summary>
    /// Implements <see cref="ITaskAppService"/> to perform task related application functionality.
    /// 
    /// Inherits from <see cref="ApplicationService"/>.
    /// <see cref="ApplicationService"/> contains some basic functionality common for application services (such as logging and localization).
    /// </summary>
    public class TaskAppService : ApplicationService, ITaskAppService
    {
        // These members set in constructor using constructor injection.
        private readonly IRepository<Task, long> _taskRepository;
        private readonly IRepository<Person> _personRepository;

        /// <summary>
        ///In constructor, we can get needed classes/interfaces.
        ///They are sent here by dependency injection system automatically.
        /// </summary>
        public TaskAppService(IRepository<Task, long> taskRepository, IRepository<Person> personRepository)
        {
            _taskRepository = taskRepository;
            _personRepository = personRepository;
        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            // Called specific GetAllWithTaskState method.
            var tasks = GetAllWithPeople(input.AssignedPersonId, input.State);

            // Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetTasksOutput
            {
                Tasks = ObjectMapper.Map<List<TaskDto>>(tasks)
            };
        }

        public GetActiveTaskCountOutput GetActiveTaskCount()
        {
            var total = _taskRepository.Count(p => p.State == TaskState.Active);

            return new GetActiveTaskCountOutput { Total = total };
        }

        private List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        {
            var query = _taskRepository.GetAll(); 

            // Add some Where conditions...
            if (assignedPersonId.HasValue)
            {
                query = query.Where(task => task.AssignedPerson.Id == assignedPersonId.Value);
            }

            if (state.HasValue)
            {
                query = query.Where(task => task.State == state);
            }

            return query
                .OrderByDescending(task => task.CreationTime)
                .Include(task => task.AssignedPerson) 
                .ToList();
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            Logger.Info("Updating a task for input: " + input);

            var task = _taskRepository.Get(input.TaskId);

            if (task != null)

            {

                task.State = (TaskState)input.State;

                _taskRepository.Update(task);

            }

            // TODO: Implement feature
        }

        public void CreateTask(CreateTaskInput input)
        {
            Logger.Info("Creating a task for input: " + input);

            _taskRepository.Insert(new Task()

            {

                AssignedPersonId = input.AssignedPersonId,

                CreationTime = DateTime.Now,

                Description = input.Description,

                State = TaskState.Active

            });

            // TODO: Implement feature
        }
    }
}
