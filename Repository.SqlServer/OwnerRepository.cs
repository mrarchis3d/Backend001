
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
    /// Repository of Owner
    /// </summary>
    public class OwnerRepository : Repository, IOwnerRepository
    {
        public OwnerRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        /// <summary>
        /// Create Method for Owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task<Guid> Create(Owner owner)
        {
            var command = "dbo.InsertOwner";
            var res = await Create(command, owner);
            return Guid.Parse(res.ToString());
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
            await ExecuteSP(command, parameters);
        }
        /// <summary>
        /// Get all Owners
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Owner>> GetAllOwner(Pagging pagging)
        {
            var command = "dbo.GetAllOwner";
            return await GetDataFromStoreProcedure<Owner>(command, pagging);
        }
        /// <summary>
        /// Update Method for Owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task Update(Owner owner)
        {
            var command = "dbo.UpdateOwner";
            await Update(command, owner);
        }
    }
}
