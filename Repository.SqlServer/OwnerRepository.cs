
using Models.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repository.SqlServer
{
    /// <summary>
    /// Repository of Owner
    /// </summary>
    public class OwnerRepository : Repository, IOwnerRepository
    {
        public OwnerRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        /// <summary>
        /// Create Method for Owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task Create(Owner owner)
        {
            var command = "dbo.InsertOwner";
            await this.Create(command, owner);
        }
        /// <summary>
        /// Delete Method for Owner
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public async Task Delete(Guid idOwner)
        {
            var command = "dbo.DeleteOwner";
            Dictionary<string, object> parameters = new();
            parameters.Add("@IdOwner", idOwner);
            await this.ExecuteSP(command, parameters);
        }
        /// <summary>
        /// Get all Owners
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Owner>> GetAllOwner()
        {
            var command = "dbo.GetAllOwner";
            return await this.GetDataFromStoreProcedure<Owner>(command);
        }
        /// <summary>
        /// Update Method for Owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task Update(Owner owner)
        {
            var command = "dbo.UpdateOwner";
            await this.Update(command, owner);
        }
    }
}
