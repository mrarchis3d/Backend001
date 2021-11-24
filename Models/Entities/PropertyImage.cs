using System;

namespace Models.Entities
{
    /// <summary>
    /// Entity for Property images
    /// </summary>
    public class PropertyImage
    {
        public Guid IdPropertyImage { get; set; }
        public Guid IdProperty { get; set; }
        public byte[] File { get; set; }
        public bool Enabled { get; set; }
    }
}
