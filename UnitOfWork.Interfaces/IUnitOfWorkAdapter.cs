using System;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWorkAdapter: IDisposable
    {
        /// <summary>
        /// Access to repositories
        /// </summary>
        IUnitOfWorkRepository Repositories { get; }
        /// <summary>
        /// confirm Changes at end of command
        /// </summary>
        void SaveChanges();
    }
}
