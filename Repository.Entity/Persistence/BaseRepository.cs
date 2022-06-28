using Models.Entities.Base;
using Repository.Interfaces.Base;
using System;

namespace Repository.Entity.Persistence
{
    public class BaseRepository<T> : IRepositoryEntity<T> where T: BaseEntity
    {
        public Task Add(T id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T id)
        {
            throw new NotImplementedException();
        }
    }
}