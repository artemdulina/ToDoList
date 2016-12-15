using System;

namespace DAL.DataTransferObject
{
    public class DalTask : IEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
