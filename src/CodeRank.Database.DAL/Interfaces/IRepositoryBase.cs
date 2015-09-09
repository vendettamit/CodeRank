using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Database.DAL.Interfaces
{
    /// <summary>
    /// base for all repository classes
    /// </summary>
    public interface IRepositoryBase
    {
        /// <summary>
        /// Saves the repository changes.
        /// </summary>
        void SaveRepositoryChanges();
    }
}
