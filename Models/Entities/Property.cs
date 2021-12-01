using Common.Attributes;
using System;

namespace Models.Entities
{
    /// <summary>
    /// Entity for property
    /// </summary>
    public class Property
    {
        [IdKey]
        public Guid IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        [NoUpdate]
        public Guid IdOwner { get; set; }
    }
}
