using System.Text;

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
    }
}
