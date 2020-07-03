using System.Collections.Generic;

namespace Neo.Rule.Registry
{
    internal interface IDiscountService
    {
        DiscountResponse ComputeDiscount(DiscountRequest discountRequest, List<DiscountRule> rules);
    }
}