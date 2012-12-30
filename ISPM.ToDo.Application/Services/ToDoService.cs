namespace ISPM.ToDo.Application.Services
{
    using System.Collections.Generic;

    using ISPM.ToDo.Data.Infrastructure;
    using ISPM.ToDo.Data.Repositories;
    using ISPM.ToDo.Domain.Entities;

    /// <summary>
    /// The ToDoService interface.
    /// </summary>
    public interface IToDoService
    {
        /// <summary>
        /// The get to dos.
        /// </summary>
        /// <returns>
        /// The <see><cref>IEnumerable</cref></see>.
        /// </returns>
        IEnumerable<ToDo> GetToDos();

        /// <summary>
        /// The get to do.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ToDo"/>.
        /// </returns>
        ToDo GetToDo(int id);

        /// <summary>
        /// The create to do.
        /// </summary>
        /// <param name="task">
        /// The task.
        /// </param>
        void CreateToDo(Domain.Entities.ToDo task);

        /// <summary>
        /// The delete to do.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void DeleteToDo(int id);

        /// <summary>
        /// The save to do.
        /// </summary>
        void SaveToDo();
    }

    /// <summary>
    /// The to do service.
    /// </summary>
    public class ToDoService : IToDoService
    {
        /// <summary>
        /// The to do repository.
        /// </summary>
        private readonly IToDoRepository toDoRepository;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public ToDoService(IToDoRepository repository, IUnitOfWork unitOfWork)
        {
            this.toDoRepository = repository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The get to dos.
        /// </summary>
        /// <returns>
        /// The <see><cref>IEnumerable</cref></see>.
        /// </returns>
        public IEnumerable<ToDo> GetToDos()
        {
            var todos = this.toDoRepository.GetAll();
            return todos;
        }

        /// <summary>
        /// The get to do.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ToDo"/>.
        /// </returns>
        public ToDo GetToDo(int id)
        {
            var todos = this.toDoRepository.GetById(id);
            return todos;
        }

        /// <summary>
        /// The create To Do.
        /// </summary>
        /// <param name="todo">
        /// The To Do.
        /// </param>
        public void CreateToDo(ToDo todo)
        {
            this.toDoRepository.Add(todo);
            this.SaveToDo();
        }

        /// <summary>
        /// The delete to do.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteToDo(int id)
        {
            var todo = this.toDoRepository.GetById(id);
            this.toDoRepository.Delete(todo);
            this.SaveToDo();
        }

        /// <summary>
        /// The save to do.
        /// </summary>
        public void SaveToDo()
        {
            this.unitOfWork.Commit();
        }
    }
}
