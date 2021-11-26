using Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for property images repository
    /// </summary>
    public interface IPropertyImageRepository
    {
        Task<Guid> Create(PropertyImage propImage);
        Task Delete(Guid idpropImage);
        Task Update(PropertyImage propImage);
        Task<IEnumerable<PropertyImage>> GetAllPropertyImages();
    }
}
