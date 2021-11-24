using DataTemplate.Repository.Contracts;
using SharedTemplate.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace DataTemplate.Repository
{
    public class ADORepository : IRepository
    {
        public string _connectionString = C
        public async Task<IEnumerable<T>> ExcecuteSP<T>(string commandName, Object dtoParameters) where T : class, new()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandName, sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var parametersObject = dtoParameters.GetType().GetProperties();
                    

                    getPropertiesForParam(cmd.Parameters, parametersObject, dtoParameters);
                    
                    var response = new List<T>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(this.Mapping<T>(reader));
                        }
                    }
                    return response;
                }
            }

        }

        private void getPropertiesForParam(SqlParameterCollection parameters, PropertyInfo[] parametersObject, Object dtoParameters)
        {
            foreach (PropertyInfo prop in parametersObject)
            {
                parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(dtoParameters)));
            }
        }

        private T Mapping<T>(SqlDataReader reader) where T : new()
        {
            var objeto = new T();
            Type tipo = objeto.GetType();
            var properties = tipo.GetProperties();

            for (int i = 0; i < tipo.GetProperties().Length; i++)
            {

                var nombre = tipo.GetProperties()[i].Name;
                object[] attrs = properties[i].GetCustomAttributes(false);
                var flag = false;
                foreach (object attr in attrs)
                {
                    Read read = attr as Read;
                    if (read != null)
                    {
                        if (!read.value)
                        {
                            flag = !flag;
                            continue;
                        }

                    }
                }
                if (flag)
                    continue;


                if (properties[i].PropertyType.Equals(typeof(int)))
                {
                    var valor = 0;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = (int)reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(int?)))
                {
                    int? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = (int)reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(byte[])))
                {
                    byte[] valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = (byte[])reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(float)))
                {
                    var valor = 0.0f;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = Single.Parse(reader[nombre].ToString());
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(float?)))
                {
                    float? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = Single.Parse(reader[nombre].ToString());
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(string)))
                {
                    var valor = reader[nombre];
                    if (String.IsNullOrEmpty(valor.ToString()))
                        valor = "";
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(Guid)))
                {
                    var valor = Guid.Empty;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = Guid.Parse(reader[nombre].ToString());
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(Guid?)))
                {
                    Guid? valor = null;
                    if (reader[nombre] != System.DBNull.Value)
                        valor = Guid.Parse(reader[nombre].ToString());
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(bool?)))
                {
                    var valor = (bool?)reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(bool)))
                {
                    var valor = (bool)reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
                if (properties[i].PropertyType.Equals(typeof(DateTime)))
                {
                    var valor = (DateTime)reader[nombre];
                    objeto.GetType().GetProperty(nombre).SetValue(objeto, valor);
                }
            }
            return objeto;
        }
    }
}
