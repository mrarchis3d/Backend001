using System;

namespace Models.Dtos
{
    /// <summary>
    /// Get information for properties with its respective owner
    /// </summary>
    public class PropertyWithOwnerDTO
    {
        public Guid IdProperty { get; set; }
        public string PropertyName { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public Guid IdOwner { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
