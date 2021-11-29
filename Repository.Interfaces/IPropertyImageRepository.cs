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
        Task Create(PropertyImage propImage);
        Task Delete(Guid idpropImage);
        Task Update(bool Enabled, Guid IdProperty);
        Task<IEnumerable<PropertyImage>> GetAllPropertyImages(bool getAll, Guid IdProperty);
    }
}
