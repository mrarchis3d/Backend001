
namespace UnitOfWork.Interfaces
{
    /// <summary>
    /// Interface for unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        public IUnitOfWorkAdapter CreateRepository();
    }
}
