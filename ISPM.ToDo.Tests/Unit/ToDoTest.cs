namespace ISPM.ToDo.Tests.Unit
{
    using System;

    using ISPM.ToDo.Domain.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The to do test.
    /// </summary>
    [TestClass]
    public class ToDoTest
    {
        /// <summary>
        /// Gets or sets the To Do.
        /// </summary>
        public ToDo Todo { get; set; }

        /// <summary>
        /// The when i create.
        /// </summary>
        [TestInitialize]
        public void WhenICreate()
        {
            this.Todo = new ToDo("uma descrição qualquer");
        }

        /// <summary>
        /// The has a description.
        /// </summary>
        [TestMethod]
        public void HasADescription()
        {
            Assert.IsNotNull(this.Todo.Description);
        }

        /// <summary>
        /// The the opening date is today.
        /// </summary>
        [TestMethod]
        public void TheOpeningDateIsToday()
        {
            Assert.AreEqual(DateTime.Today.Date, this.Todo.OpenDate.Date);
        }

        /// <summary>
        /// The it has no closing date.
        /// </summary>
        [TestMethod]
        public void ItHasNoClosingDate()
        {
            Assert.IsNull(this.Todo.CloseDate);
        }

        /// <summary>
        /// The when i mark as done the property Completed is true.
        /// </summary>
        [TestMethod]
        public void WhenIMarkAsDoneThePropertyCompletedIsTrue()
        {
            this.Todo.MarkAsDone(true);

            Assert.IsTrue(this.Todo.Completed);
            Assert.IsTrue(this.Todo.CloseDate.HasValue);
            Assert.AreEqual(DateTime.Today.Date, this.Todo.CloseDate.Value.Date);
        }

        /// <summary>
        /// The when i mark as undone the property completed is false.
        /// </summary>
        [TestMethod]
        public void WhenIMarkAsUndoneThePropertyCompletedIsFalse()
        {
            this.Todo.MarkAsDone(false);

            Assert.IsFalse(this.Todo.Completed);
        }
    }
}
