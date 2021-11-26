using Models.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SqlServer
{
    public class PropertyImageRepository : Repository, IPropertyImageRepository
    {
        public PropertyImageRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        /// <summary>
        /// Create Property Image of owner
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<Guid> Create(PropertyImage propImage)
        {
            var command = "dbo.InsertPropertyImage";
            var res = await Create(command, propImage);
            return Guid.Parse(res.ToString());
        }

        /// <summary>
        /// Delete Method for Image Property 
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public async Task Delete(Guid idProperty)
        {
            var command = "dbo.DeletePropertyImage";
            Dictionary<string, object> parameters = new();
            parameters.Add("@idProperty", idProperty);
            await ExecuteSP(command, parameters);
        }
        /// <summary>
        /// Get all Images properties
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyImage>> GetAllPropertyImages()
        {
            var command = "dbo.GetAllPropertyImages";
            return await GetDataFromStoreProcedure<PropertyImage>(command);
        }


        /// <summary>
        /// Update Method for image Property 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public async Task Update(PropertyImage propImage)
        {
            var command = "dbo.UpdatePropertyImage";
            await Update(command, propImage);
        }
    }
}
