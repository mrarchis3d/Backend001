using Models.Entities;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    /// <summary>
    /// Contract for Test repository
    /// </summary>
    public interface IOwnerRepository
    {
        Task Create(Owner owner);
        Task Delete(Guid idOwner);
        Task Update(Owner owner);
        Task<IEnumerable<Owner>> GetAllOwner(Pagging pagging);
    }
}
