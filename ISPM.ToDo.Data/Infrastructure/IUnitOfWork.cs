namespace ISPM.ToDo.Data.Infrastructure
{
    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The commit.
        /// </summary>
        void Commit();
    }
}
