using Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for property repository
    /// </summary>
    public interface IPropertyRepository
    {
        Task Create(Property property);
        Task Delete(Guid idProperty);
        Task Update(Property property);
        Task<IEnumerable<Property>> GetAllProperties();
    }
}
