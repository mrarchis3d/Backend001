using Common.Attributes;
using System;

namespace Models.Entities
{
    public class Owner
    {
        [IdKey]
        public Guid IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public DateTimeOffset Birthday { get; set; } 
    }
}
