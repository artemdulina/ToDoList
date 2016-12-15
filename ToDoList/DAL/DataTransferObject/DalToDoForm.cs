using System;
using System.Collections.Generic;

namespace DAL.DataTransferObject
{
    public class DalToDoForm : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<DalTask> Tasks { get; set; }

        public DalAuthor Author { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
