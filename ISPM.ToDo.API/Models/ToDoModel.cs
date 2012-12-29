namespace ISPM.ToDo.API.Models
{
    using System;

    /// <summary>
    /// The to do model.
    /// </summary>
    public class ToDoModel
    {
        /// <summary>
        /// The date format string.
        /// </summary>
        private const string DateFormatString = "dd/MM/yyyy HH:mm:ss";

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether completed.
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// Gets the open date support.
        /// </summary>
        public string OpenDateSupport
        {
            get
            {
                return this.OpenDate.ToString(DateFormatString);
            }
        }

        /// <summary>
        /// Gets the close date support.
        /// </summary>
        public string CloseDateSupport 
        { 
            get
            {
                return this.CloseDate.HasValue ? this.CloseDate.Value.ToString(DateFormatString) : "em aberto";
            }
        }

        /// <summary>
        /// Gets or sets the open date.
        /// </summary>
        public DateTime OpenDate { get; set; }

        /// <summary>
        /// Gets or sets the close date.
        /// </summary>
        public DateTime? CloseDate { get; set; }
    }
}