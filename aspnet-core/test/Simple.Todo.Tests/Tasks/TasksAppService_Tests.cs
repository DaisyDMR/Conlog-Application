using Simple.Todo.Tasks;
using Simple.Todo.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Simple.Todo.Tasks.Dtos;
using Shouldly;

namespace Simple.Todo.Tests.Tasks
{
    public class TasksAppService_Tests : TodoTestBase
    {
        private readonly ITaskAppService _taskAppService;

        public TasksAppService_Tests()
        {
            _taskAppService = Resolve<ITaskAppService>();
        }

        [Fact]
        public void GetTasks_Test()
        {
            // Act
            var output = _taskAppService.GetTasks(new GetTasksInput { State = TaskState.Active});

            // Assert
            output.Tasks.Count.ShouldBeGreaterThan(0);
        }
        
    }
}
