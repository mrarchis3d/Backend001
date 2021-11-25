using System;

namespace Common.Attributes
{
    /// <summary>
    /// This attribute indicate that property is used for filtering into the request in sp
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class Filtering : System.Attribute
    {
    }
}
