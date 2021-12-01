using Models.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace Repository.SqlServer
{
    public class PropertyTraceRepository : Repository, IPropertyTraceRepository
    {
        public PropertyTraceRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        /// <summary>
        /// Create Method for property trace
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task Create(PropertyTrace proptrace)
        {
            var command = "dbo.InsertPropertyTrace";
            await Create(command, proptrace);
        }
        /// <summary>
        /// Delete Method for Property trace
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public async Task Delete(Guid idPropertyTrace)
        {
            var command = "dbo.DeletePropertyTrace";
            Dictionary<string, object> parameters = new();
            parameters.Add("@IdPropertyTrace", idPropertyTrace);
            await ExecuteSP(command, parameters);
        }
        /// <summary>
        /// Get all property traces
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyTrace>> GetPropertyTraces(Guid idProperty)
        {
            var command = "dbo.GetPropertyTraces";
            Dictionary<string, object> parameters = new();
            parameters.Add("@IdProperty", idProperty);
            return await GetDataFromStoreProcedure<PropertyTrace>(command, parameters);
        }
        /// <summary>
        /// Update Method for Update Property Trace
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task Update(PropertyTrace propertyTrace)
        {
            var command = "dbo.UpdatePropertyTrace";
            await Update(command, propertyTrace);
        }
    }
}
