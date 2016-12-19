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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoForm>()
                .HasMany<Task>(t => t.Tasks)
                .WithOptional(t => t.ToDoForm)
                .WillCascadeOnDelete(true);
        }
    }
}
