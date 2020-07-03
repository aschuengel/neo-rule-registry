using System.Collections.Generic;

namespace Neo.Rule.Registry
{
    public class DiscountRequest
    {
        public List<DiscountRequestItem> Items { get; set; }
        public int TotalDiscount { get; set; }
    }
}