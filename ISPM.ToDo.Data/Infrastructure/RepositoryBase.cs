namespace ISPM.ToDo.Data.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The repository base.
    /// </summary>
    /// <typeparam name="T">
    /// type with which the repository will work
    /// </typeparam>
    public abstract class RepositoryBase<T> where T : class
    {
        /// <summary>
        /// The database set.
        /// </summary>
        private readonly IDbSet<T> dbset;

        /// <summary>
        /// The data context.
        /// </summary>
        private ToDoContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="databaseFactory">
        /// The database factory.
        /// </param>
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            this.DatabaseFactory = databaseFactory;
            this.dbset = this.DataContext.Set<T>();
        }

        /// <summary>
        /// Gets the database factory.
        /// </summary>
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        protected ToDoContext DataContext
        {
            get { return this.dataContext ?? (this.dataContext = DatabaseFactory.Get()); }
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Add(T entity)
        {
            this.dbset.Add(entity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Update(T entity)
        {
            this.dbset.Attach(entity);
            this.dataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Delete(T entity)
        {
            this.dbset.Remove(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this.dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                this.dbset.Remove(obj);
            }
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T GetById(long id)
        {
            return this.dbset.Find(id);
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T GetById(string id)
        {
            return this.dbset.Find(id);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<T> GetAll()
        {
            return this.dbset.ToList();
        }

        /// <summary>
        /// The get many.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return this.dbset.Where(where).ToList();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            return this.dbset.Where(where).FirstOrDefault<T>();
        }
    }
}
