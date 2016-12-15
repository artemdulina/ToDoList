using System.Data.Entity;

namespace ORM
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("name=ToDoContext")
        {
            
        }

        public DbSet<ToDoForm> ToDoForms { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
