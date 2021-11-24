using Common.Attributes;
using Common.Errors;
using Common.Exceptions;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace Repository.SqlServer
{
    public abstract class Repository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        /// <summary>
        /// this method is for get data from sp, passing object with parameters
        /// the params should be equals to object params
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="dtoParameters"></param>
        /// <returns></returns>
        protected async Task<List<T>> GetDataFromStoreProcedure<T>(string command, object dtoParameters=null) where T: class, new()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, this._context, this._transaction))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (dtoParameters != null)
                    {
                        var parametersObject = dtoParameters.GetType().GetProperties();
                        getPropertiesForRead(cmd.Parameters, parametersObject, dtoParameters);
                    }
                    var response = new List<T>();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(this.MapDataToObject<T>(reader));
                        }
                    }
                    return response;
                }
            }catch(Exception ex)
            {
                throw new GlobalExceptionError(ErrorMessages.ERROR_ON_EXCECUTE_STORE_PROCEDURE, ex);
            }

        }
 
        /// <summary>
        /// Get data from SP, with a dictionary of params, Key = param, Value = value of parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected async Task<List<T>> GetDataFromStoreProcedure<T>(string command, Dictionary<string,object> parameters) where T : class, new()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, this._context, this._transaction))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (var paramt in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(paramt.Key, paramt.Value));
                    }

                    var response = new List<T>();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(this.MapDataToObject<T>(reader));
                        }
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new GlobalExceptionError(ErrorMessages.ERROR_ON_EXCECUTE_STORE_PROCEDURE, ex);
            }
            
        }
        /// <summary>
        /// Execute Store for create object with object parameters 
        /// parameters for insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="dtoParameters"></param>
        /// <returns></returns>
        protected async Task Create(string command, object dtoParameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, this._context, this._transaction))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var parametersObject = dtoParameters.GetType().GetProperties();
                    getPropertiesForCreate(cmd.Parameters, parametersObject, dtoParameters);
                    await cmd.ExecuteNonQueryAsync();
                    await this._transaction.CommitAsync();
                }
            }catch (Exception ex)
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
        protected async Task Update(string command, object dtoParameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, this._context, this._transaction))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var parametersObject = dtoParameters.GetType().GetProperties();
                    getPropertiesForParam(cmd.Parameters, parametersObject, dtoParameters);
                    await cmd.ExecuteNonQueryAsync();
                    await this._transaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                throw new GlobalExceptionError(ErrorMessages.ERROR_ON_EXCECUTE_STORE_PROCEDURE, ex);
            }
        }
        /// <summary>
        /// Execute Store Procedure for Inserting, delete or update data with a dictionary of parameteres
        /// Key=name of parameter, Value = value of parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected async Task ExecuteSP(string command, Dictionary<string, object> parameters=null)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, this._context, this._transaction))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if(parameters!=null)
                        foreach (var paramt in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(paramt.Key, paramt.Value));
                        }
                    await cmd.ExecuteNonQueryAsync();
                    await this._transaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                throw new GlobalExceptionError(ErrorMessages.ERROR_ON_EXCECUTE_STORE_PROCEDURE, ex);
            }
        }
        /// <summary>
        /// Maps a SqlDataReader record to an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <param name="newObject"></param>
        private T MapDataToObject<T>(SqlDataReader dataReader) where T: new()
        {
            var newObject = new T();
            // Fast Member Usage
            var objectMemberAccessor = TypeAccessor.Create(newObject.GetType());
            var propertiesHashSet =
                    objectMemberAccessor
                    .GetMembers()
                    .Select(mp => mp.Name)
                    .ToHashSet();

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                if (propertiesHashSet.Contains(dataReader.GetName(i)))
                {
                    objectMemberAccessor[newObject, dataReader.GetName(i)]
                        = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);
                }
            }
            return newObject;
        }
        /// <summary>
        /// Get properties for create object
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parametersObject"></param>
        /// <param name="dtoParameters"></param>
        private void getPropertiesForCreate(SqlParameterCollection parameters, PropertyInfo[] parametersObject, Object dtoParameters)
        {
            foreach (PropertyInfo prop in parametersObject)
            {
                object[] attrs = prop.GetCustomAttributes(false);
                var flag = false;
                foreach (object attr in attrs)
                {
                    IdKey idkey = attr as IdKey;
                    if (idkey != null)
                    {
                        flag = true;
                        continue;
                    }
                }
                if (flag)
                    continue;
                parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(dtoParameters)));
            }
        }
        /// <summary>
        /// Get properties for updates object
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parametersObject"></param>
        /// <param name="dtoParameters"></param>
        private void getPropertiesForParam(SqlParameterCollection parameters, PropertyInfo[] parametersObject, Object dtoParameters)
        {
            foreach (PropertyInfo prop in parametersObject)
            {
                parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(dtoParameters)));
            }
        }
        /// <summary>
        /// Get properties for read
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parametersObject"></param>
        /// <param name="dtoParameters"></param>
        private void getPropertiesForRead(SqlParameterCollection parameters, PropertyInfo[] parametersObject, Object dtoParameters)
        {
            foreach (PropertyInfo prop in parametersObject)
            {
                object[] attrs = prop.GetCustomAttributes(false);
                var flag = false;
                foreach (object attr in attrs)
                {
                    NoRead noRead = attr as NoRead;
                    if (noRead != null)
                    {
                        flag = true;
                        continue;
                    }
                }
                if (flag)
                    continue;
                parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(dtoParameters)));
            }
        }

    }
}
