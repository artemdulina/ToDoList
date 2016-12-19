using System;

namespace ORM
{
    public class Task
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual ToDoForm ToDoForm { get; set; }
    }
}
