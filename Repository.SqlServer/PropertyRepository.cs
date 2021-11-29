using Common.Exceptions;
using Models.Dtos;
using Models.Entities;
using Models.Utils;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repository.SqlServer
{

    /// <summary>
    /// Repositoryy for property entity
    /// </summary>
    public class PropertyRepository : Repository, IPropertyRepository
    {
        public PropertyRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        /// <summary>
        /// Create Property of owner
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<Guid> Create(Property property)
        {
            try
            {
                var command = "dbo.InsertProperty";
                var res = await Create(command, property);
                return Guid.Parse(res.ToString());

            }catch(Exception ex)
            {
                throw new GlobalExceptionError(Common.Errors.ErrorMessages.ERROR_ON_PARSING_GUID, ex);
            }

        }

        /// <summary>
        /// Delete Method for Property
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public async Task Delete(Guid idProperty)
        {
            var command = "dbo.DeleteProperty";
            Dictionary<string, object> parameters = new();
            parameters.Add("@IdProperty", idProperty);
            await ExecuteSP(command, parameters);
        }
        /// <summary>
        /// Get all Properties
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyWithOwnerDTO>> GetAllPropertyWithOwner(Pagging pagging)
        {
            var command = "dbo.GetAllPropertyWithOwner";
            return await GetDataFromStoreProcedure<PropertyWithOwnerDTO>(command, pagging);
        }


        /// <summary>
        /// Update Method for Property
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task Update(Property owner)
        {
            var command = "dbo.UpdateProperty";
            await Update(command, owner);
        }
    }
}
