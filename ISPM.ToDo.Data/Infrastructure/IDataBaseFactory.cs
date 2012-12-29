namespace ISPM.ToDo.Data.Infrastructure
{
    using System;

    // <summary>
    /// The DatabaseFactory interface.
    /// </summary>
    public interface IDatabaseFactory : IDisposable
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="ToDoContext"/>.
        /// </returns>
        ToDoContext Get();
    }
}
