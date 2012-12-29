namespace ISPM.ToDo.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using ISPM.ToDo.Domain.Entities;

    /// <summary>
    /// The To Do Context.
    /// </summary>
    public class ToDoContext : DbContext
    {
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = true;

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /// <summary>
        /// Gets or sets the To Do.
        /// </summary>
        public DbSet<ToDo> ToDo { get; set; }
    }

    /// <summary>
    /// The to do context initializer.
    /// </summary>
    public class ToDoContextInitializer : DropCreateDatabaseIfModelChanges<ToDoContext>
    {
        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(ToDoContext context)
        {
        }
    }
}
