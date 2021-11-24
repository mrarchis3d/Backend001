using Models.Entities;
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
            this._context = context;
            this._transaction = transaction;
        }

        /// <summary>
        /// Create Property of owner
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task Create(Property property)
        {
            var command = "dbo.InsertProperty";
            await this.Create(command, property);
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
            parameters.Add("@idProperty", idProperty);
            await this.ExecuteSP(command, parameters);
        }
        /// <summary>
        /// Get all Properties
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Property>> GetAllProperties()
        {
            var command = "dbo.GetAllProperties";
            return await this.GetDataFromStoreProcedure<Property>(command);
        }


        /// <summary>
        /// Update Method for Property
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task Update(Property owner)
        {
            var command = "dbo.UpdateProperty";
            await this.Update(command, owner);
        }
    }
}
