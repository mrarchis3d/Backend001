using Models.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepositoryEntity<T>  where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T id);
        Task Update(T id);
        Task Delete(T id);
    }
}
