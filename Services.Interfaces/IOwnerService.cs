using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    /// <summary>
    /// interface for Owner Service
    /// </summary>
    public interface IOwnerService
    {
        Task Create(OwnerDTO owner);
        Task Delete(Guid idOwner);
        Task Update(OwnerDTO owner);
        Task<IEnumerable<OwnerDTO>> GetAllOwner();
    }
}
