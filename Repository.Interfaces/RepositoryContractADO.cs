using Common.Attributes;
using Common.Errors;
using Common.Exceptions;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public abstract class RepositoryContractADO
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
        protected async Task<List<T>> GetDataFromStoreProcedure<T>(string command, object dtoParameters = null) where T : class, new()
        {
            try
            {
                using SqlCommand cmd = new(command, _context, _transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (dtoParameters != null)
                {
                    var parametersObject = dtoParameters.GetType().GetProperties();
                    GetPropertiesForRead(cmd.Parameters, parametersObject, dtoParameters);
                }
                var response = new List<T>();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapDataToObject<T>(reader));
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new GlobalExceptionError(ErrorMessages.ERROR_ON_EXCECUTE_STORE_PROCEDURE, ex);
            }

        }


        /// <summary>
        /// Get properties for read
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parametersObject"></param>
        /// <param name="dtoParameters"></param>
        protected static void GetPropertiesForRead(SqlParameterCollection parameters, PropertyInfo[] parametersObject, Object dtoParameters)
        {
            foreach (PropertyInfo prop in parametersObject)
            {
                object[] attrs = prop.GetCustomAttributes(false);
                if (DetectFiltering(attrs, prop.GetValue(dtoParameters)))
                    continue;
                if (DetectFiltersNoRead(attrs))
                    continue;
                parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(dtoParameters)));

            }
        }

        /// <summary>
        /// Get data from SP, with a dictionary of params, Key = param, Value = value of parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected async Task<List<T>> GetDataFromStoreProcedure<T>(string command, Dictionary<string, object> parameters) where T : class, new()
        {
            try
            {
                using SqlCommand cmd = new(command, _context, _transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (var paramt in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(paramt.Key, paramt.Value));
                }

                var response = new List<T>();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapDataToObject<T>(reader));
                    }
                }
                return response;
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
        protected async Task ExecuteSP(string command, Dictionary<string, object> parameters = null)
        {
            try
            {
                using SqlCommand cmd = new(command, _context, _transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parameters != null)
                    foreach (var paramt in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(paramt.Key, paramt.Value));
                    }
                await cmd.ExecuteNonQueryAsync();
                await _transaction.CommitAsync();
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
        protected static T MapDataToObject<T>(SqlDataReader dataReader) where T : new()
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
        protected static void GetPropertiesForCreate(SqlParameterCollection parameters, PropertyInfo[] parametersObject, Object dtoParameters)
        {
            foreach (PropertyInfo prop in parametersObject)
            {
                object[] attrs = prop.GetCustomAttributes(false);
                if (DetectFiltersNoRead(attrs))
                    continue;
                parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(dtoParameters)));
            }
        }
        /// <summary>
        /// Detect if the property is NoRead and if is IdKey
        /// </summary>
        /// <param name="attrs"></param>
        /// <returns></returns>
        protected static bool DetectFiltersNoRead(object[] attrs)
        {
            foreach (object attr in attrs)
            {
                if (attr is IdKey || attr is NoRead)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Detect if the property is NoUpdate
        /// </summary>
        /// <param name="attrs"></param>
        /// <returns></returns>
        protected static bool DetectFiltersNoUpdate<T>(object[] attrs)
        {
            foreach (object attr in attrs)
            {
                if (attr is T)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Detect filtering this is for pagination
        /// </summary>
        /// <param name="attrs"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static bool DetectFiltering(object[] attrs, object value)
        {
            foreach (object attr in attrs)
            {
                if (attr is Filtering && value != null)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Get properties for updates object
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parametersObject"></param>
        /// <param name="dtoParameters"></param>
        protected static void GetPropertiesForParam(SqlParameterCollection parameters, PropertyInfo[] parametersObject, Object dtoParameters)
        {
            foreach (PropertyInfo prop in parametersObject)
            {
                object[] attrs = prop.GetCustomAttributes(false);
                if (DetectFiltersNoUpdate<NoUpdate>(attrs))
                    continue;
                parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(dtoParameters)));
            }
        }

    }
}
