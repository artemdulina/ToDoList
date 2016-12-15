using System;
using System.Collections.Generic;

namespace ORM
{
    public class ToDoForm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual Author Author { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
