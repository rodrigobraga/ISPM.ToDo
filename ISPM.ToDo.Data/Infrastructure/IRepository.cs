namespace ISPM.ToDo.Data.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// type with which the repository will work
    /// </typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Add(T entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="Id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetById(long Id);

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="Id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetById(string Id);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Get(Expression<Func<T, bool>> where);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// The get many.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
