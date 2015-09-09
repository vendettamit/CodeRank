using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeRank.Database.DAL.Database;
using CodeRank.Database.DAL.Interfaces;

namespace CodeRank.Database.DAL.Repositories
{
    /// <summary>
    /// abstract class for all repository
    /// </summary>
    public abstract class RepositoryBase : IDisposable, IRepositoryBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private CodeRankEntities context;

        /// <summary>
        /// true if object already disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected RepositoryBase(CodeRankEntities context)
        {
            this.context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        protected RepositoryBase()
        {
            this.context = new CodeRankEntities();
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public CodeRankEntities Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Saves the repository changes.
        /// </summary>
        public void SaveRepositoryChanges()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (!disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
