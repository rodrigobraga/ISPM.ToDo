namespace ISPM.ToDo.Domain.Entities
{
    using System;

    /// <summary>
    /// The to do.
    /// </summary>
    public class ToDo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToDo"/> class.
        /// </summary>
        public ToDo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDo"/> class.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        public ToDo(string description)
        {
            this.Description = description;
            this.OpenDate = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether completed.
        /// </summary>
        public bool Completed { get; protected set; }

        /// <summary>
        /// Gets or sets the open date.
        /// </summary>
        public DateTime OpenDate { get; protected set; }

        /// <summary>
        /// Gets or sets the close date.
        /// </summary>
        public DateTime? CloseDate { get; protected set; }

        /// <summary>
        /// The mark as done.
        /// </summary>
        /// <param name="flag">
        /// The flag.
        /// </param>
        public void MarkAsDone(bool flag)
        {
            this.Completed = flag;
            this.CloseDate = DateTime.Now;

            if (!this.Completed)
            {
                this.CloseDate = null;
            }
        }

    }
}
