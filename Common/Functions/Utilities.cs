using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Exceptions;
using Newtonsoft.Json;

namespace Common.Functions
{
    public static class Utilities
    {
        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] Convert(string source) => Encoding.ASCII.GetBytes(source);
        /// <summary>
        /// Convert byte array to string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Convert(byte[] source) => Encoding.ASCII.GetString(source);

        /// <summary>
        /// OrderbyAscProperty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <param name="nameProperty"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderByAscProperty<T>(IEnumerable<T> lista, string nameProperty)
        {
            try
            {
                if (lista.Any())
                {

                    return lista.OrderBy(x => x.GetType().GetProperty(nameProperty).GetValue(x));
                }
                return lista;
            }catch(GlobalExceptionError ex)
            {
                throw new GlobalExceptionError(Errors.ErrorMessages.ERROR_ORDER_BY_ASC_PROPERTY, ex);
            }

        }
        /// <summary>
        /// Order by desc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <param name="nameProperty"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderByDescProperty<T>(IEnumerable<T> lista, string nameProperty)
        {
            try
            {
                if (lista.Any())
                {
                    return lista.OrderByDescending(x => x.GetType().GetProperty(nameProperty).GetValue(x));
                }
                return lista;
            }
            catch(GlobalExceptionError ex)
            {
                throw new GlobalExceptionError(Errors.ErrorMessages.ERROR_ORDER_BY_DESC_PROPERTY, ex);
            }

        }
        /// <summary>
        /// example: list, "{Name:"Jorge"}"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static IEnumerable<T> FilterByProperty<T>(IEnumerable<T> lista, string json)
        {
            try
            {
                if (lista.Any())
                {
                    var jss = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    return lista.Where(x => x.GetType().GetProperty(jss.First().Key).GetValue(x).ToString().Contains(jss.First().Value.ToString())).ToList();
                }
                return lista;
            }
            catch (GlobalExceptionError ex)
            {
                throw new GlobalExceptionError(Errors.ErrorMessages.ERROR_FITERING_BY_PROPERTY, ex);
            }
        }
    }
}
