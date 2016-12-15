using System.Collections.Generic;

namespace ORM
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<ToDoForm> Records { get; set; }
    }
}
