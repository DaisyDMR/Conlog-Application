using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Todo.Tasks.Dtos
{
    public class GetTasksInput
    {
        public TaskState? State { get; set; }

        public int? AssignedPersonId { get; set; }
    }
}
