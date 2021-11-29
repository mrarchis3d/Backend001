using System;


namespace Models.Dtos
{
    /// <summary>
    /// DTO Entity for Property images
    /// </summary>
    public class PropertyImageDTO
    {
        public Guid? IdPropertyImage { get; set; }
        public Guid? IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
