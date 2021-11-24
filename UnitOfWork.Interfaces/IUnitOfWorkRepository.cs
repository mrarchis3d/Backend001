using Repository.Interfaces;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IOwnerRepository OwnerRepository { get; }
    }
}
