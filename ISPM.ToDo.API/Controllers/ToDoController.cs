namespace ISPM.ToDo.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web.Http;

    using AutoMapper;

    using ISPM.ToDo.API.Models;
    using ISPM.ToDo.Application.Services;
    using ISPM.ToDo.Data.Infrastructure;
    using ISPM.ToDo.Data.Repositories;
    using ISPM.ToDo.Domain.Entities;

    /// <summary>
    /// The to do controller.
    /// </summary>
    public class ToDoController : ApiController
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IToDoService service;

        /// <summary>
        /// The JSON formatter.
        /// </summary>
        private readonly JsonMediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoController"/> class.
        /// </summary>
        public ToDoController()
        {
            IDatabaseFactory factory = new DatabaseFactory();
            IToDoRepository repository = new ToDoRepository(factory);
            IUnitOfWork unitOfWork = new UnitOfWork(factory);

            this.service = new ToDoService(repository, unitOfWork);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        public HttpResponseMessage Get()
        {
            Mapper.CreateMap<ToDo, ToDoModel>();

            IEnumerable<ToDo> todos = this.service.GetToDos();

            var result = todos.Select(Mapper.Map<ToDo, ToDoModel>);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content =
                    new ObjectContent<IEnumerable<ToDoModel>>(
                    result, this.jsonFormatter)
            };

            return response;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        public HttpResponseMessage Get(int id)
        {
            Mapper.CreateMap<ToDo, ToDoModel>();

            var todo = this.service.GetToDo(id);

            var modelo = Mapper.Map<ToDo, ToDoModel>(todo);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content =
                    new ObjectContent<ToDoModel>(
                    modelo, this.jsonFormatter)
            };
            return response;
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        public HttpResponseMessage Post(ToDoModel model)
        {
            var todo = new ToDo(model.Description);

            try
            {
                this.service.CreateToDo(todo);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        public HttpResponseMessage Put(int id, ToDoModel model)
        {
            try
            {
                var todo = this.service.GetToDo(id);
                todo.MarkAsDone(model.Completed);

                this.service.SaveToDo();
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var response = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content =
                    new ObjectContent<ToDoModel>(
                    model, this.jsonFormatter)
            };
            return response;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                this.service.DeleteToDo(id);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
