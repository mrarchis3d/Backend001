using Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPropertyTraceService
    {
        Task Create(PropertyTrace propertyTrace);
        Task Delete(Guid idtrace);
        Task Update(PropertyTrace propertyTrace);
        Task<IEnumerable<PropertyTrace>> GetPropertyTraces(Guid idProperty);
    }
}
