using Common.Attributes;
using System;

namespace Models.Utils
{
    /// <summary>
    /// Class for filter days
    /// </summary>
    public class FilterDay
    {
        /// <summary>
        /// Start of the day
        /// </summary>
        [Filtering]
        public DateTime? DateStart { get; set; }
        /// <summary>
        /// End of the day
        [Filtering]
        public DateTime? DateEnd { get; set; }
    }
}
