using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPropertyImageService
    {
        Task Delete(Guid idPropImage);
        Task Update(bool enabled, Guid IdImage);
        Task<IEnumerable<PropertyImageDTO>> GetAllPropertyImages(bool getAll, Guid IdProperty);
    }
}
