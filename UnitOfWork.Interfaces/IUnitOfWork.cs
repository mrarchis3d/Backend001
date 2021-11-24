
namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        public IUnitOfWorkAdapter CreateRepository();
    }
}
