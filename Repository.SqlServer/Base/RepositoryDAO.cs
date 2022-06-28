using Common.Errors;
using Common.Exceptions;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Repository.Interfaces;
using Repository.Interfaces.Base;

namespace Repository.Queries
{
    public abstract class Repository : RepositoryContract, IRepositoryADO
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;


        /// <summary>
        /// Execute Store for create object with object parameters 
        /// parameters for insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="dtoParameters"></param>
        /// <returns></returns>
        public async Task<T> Create<T>(string command, object dtoParameters)
        {
            try
            {
                using SqlCommand cmd = new(command, _context, _transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var parametersObject = dtoParameters.GetType().GetProperties();
                GetPropertiesForCreate(cmd.Parameters, parametersObject, dtoParameters);
                var res = await cmd.ExecuteScalarAsync();
                await _transaction.CommitAsync();
                return (T) res;
            }
            catch (Exception ex)
            {
                throw new GlobalExceptionError(ErrorMessages.ERROR_ON_EXCECUTE_STORE_PROCEDURE, ex);
            }
        }
        /// <summary>
        /// Execute Store for update object with object parameters 
        /// parameters for insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="dtoParameters"></param>
        /// <returns></returns>
        public async Task Update(string command, object dtoParameters)
        {
            try
            {
                using SqlCommand cmd = new(command, _context, _transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var parametersObject = dtoParameters.GetType().GetProperties();
                GetPropertiesForParam(cmd.Parameters, parametersObject, dtoParameters);
                await cmd.ExecuteNonQueryAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new GlobalExceptionError(ErrorMessages.ERROR_ON_EXCECUTE_STORE_PROCEDURE, ex);
            }
        }

    }
}
