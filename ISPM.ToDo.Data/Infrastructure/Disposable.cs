namespace ISPM.ToDo.Data.Infrastructure
{
    using System;

    /// <summary>
    /// The disposable.
    /// </summary>
    public class Disposable : IDisposable
    {
        /// <summary>
        /// The is disposed.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class. 
        /// </summary>
        ~Disposable()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose core.
        /// </summary>
        public virtual void DisposeCore()
        {
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (!this.isDisposed && disposing)
            {
                this.DisposeCore();
            }

            this.isDisposed = true;
        }
    }
}
