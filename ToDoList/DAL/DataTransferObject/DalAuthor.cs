using System.Collections.Generic;

namespace DAL.DataTransferObject
{
    public class DalAuthor : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<DalToDoForm> Records { get; set; }
    }
}
