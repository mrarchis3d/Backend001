using Repository.Interfaces;

namespace UnitOfWork.Interfaces
{
    /// <summary>
    /// All repositories from db test
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        IOwnerRepository OwnerRepository { get; }
        IPropertyRepository PropertyRepository { get; }
        IPropertyImageRepository PropertyImageRepository { get; }
    }
}
