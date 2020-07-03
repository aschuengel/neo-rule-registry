namespace Neo.Rule.Registry
{
    internal class PercentageOnItemStrategy : IDiscountStrategy
    {
        // Must match type code in Salesforce
        public string TypeCode => "PercentageOnItem";

        public void ComputeDiscountOnCart(DiscountRule rule, DiscountRequest discountRequest, DiscountResponse discountResponse)
        {
            // Do Nothing
        }

        public void ComputeDiscountOnItem(DiscountRule rule, DiscountRequest discountRequest, DiscountResponse discountResponse, DiscountRequestItem item)
        {
            item.TotalDiscount += rule.Value;
        }
    }
}