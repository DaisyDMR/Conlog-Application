using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Todo.Tasks.Dtos
{
    public class GetTasksOutput
    {
        public List<TaskDto> Tasks { get; set; }
    }
}
