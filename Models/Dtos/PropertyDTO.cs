using System;

namespace Models.Dtos
{
    /// <summary>
    /// Property dto
    /// </summary>
    class PropertyDTO
    {
        public Guid? IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public Guid IdOwner { get; set; }
    }
}
