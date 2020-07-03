namespace Neo.Rule.Registry
{
    internal class PercentageOnCartStrategy : IDiscountStrategy
    {
        // Must match type code in Salesforce
        public string TypeCode => "PercentageOnCart";

        public void ComputeDiscountOnCart(DiscountRule rule, DiscountRequest discountRequest, DiscountResponse discountResponse)
        {
            discountRequest.TotalDiscount += rule.Value;
        }

        public void ComputeDiscountOnItem(DiscountRule rule, DiscountRequest discountRequest, DiscountResponse discountResponse, DiscountRequestItem item)
        {
            // Do nothing
        }
    }
}