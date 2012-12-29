namespace ISPM.ToDo.Data.Infrastructure
{
    /// <summary>
    /// The unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The database factory.
        /// </summary>
        private readonly IDatabaseFactory databaseFactory;

        /// <summary>
        /// The data context.
        /// </summary>
        private ToDoContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="databaseFactory">
        /// The database factory.
        /// </param>
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        protected ToDoContext DataContext
        {
            get { return this.dataContext ?? (this.dataContext = this.databaseFactory.Get()); }
        }

        /// <summary>
        /// The commit.
        /// </summary>
        public void Commit()
        {
            this.DataContext.Commit();
        }
    }
}
