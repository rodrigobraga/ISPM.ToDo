namespace ISPM.ToDo.Data.Repositories
{
    using ISPM.ToDo.Data.Infrastructure;
    using ISPM.ToDo.Domain.Entities;

    /// <summary>
    /// The ToDoRepository interface.
    /// </summary>
    public interface IToDoRepository : IRepository<ToDo>
    {
    }

    /// <summary>
    /// The to do repository.
    /// </summary>
    public class ToDoRepository : RepositoryBase<ToDo>, IToDoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoRepository"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        public ToDoRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }
    }
}
