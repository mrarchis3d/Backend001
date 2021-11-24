using System;

namespace Models.Entities
{
    public class PropertyTrace
    {
        public Guid IdPropertyTrace { get; set; }
        public DateTimeOffset DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Tax { get; set; }
        public Guid IdProperty { get; set; }
    }
}
