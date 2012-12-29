namespace ISPM.ToDo.Data.Infrastructure
{
    /// <summary>
    /// The database factory.
    /// </summary>
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        /// <summary>
        /// The context.
        /// </summary>
        private ToDoContext context;

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="ToDoContext"/>.
        /// </returns>
        public ToDoContext Get()
        {
            return this.context ?? (this.context = new ToDoContext());
        }

        /// <summary>
        /// The dispose core.
        /// </summary>
        public override void DisposeCore()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }
    }
}
