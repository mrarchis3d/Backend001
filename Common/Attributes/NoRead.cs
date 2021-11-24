using System;

namespace Common.Attributes
{
    /// <summary>
    /// Attribute for reading properties in mapping GettingData from Sql
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class NoRead : System.Attribute
    {
    }
}
