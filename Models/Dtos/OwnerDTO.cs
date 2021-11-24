using System;

namespace Models.Dtos
{
    /// <summary>
    /// Dto For Owner Creation, and Update
    /// </summary>
    public class OwnerDTO
    {
        public Guid? IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTimeOffset Birthday { get; set; }
    }
}
