namespace Neo.Rule.Registry
{
    internal interface IDiscountStrategy
    {
        public string TypeCode { get; }

        void ComputeDiscountOnCart(DiscountRule rule, DiscountRequest discountRequest, DiscountResponse discountResponse);

        void ComputeDiscountOnItem(DiscountRule rule, DiscountRequest discountRequest, DiscountResponse discountResponse, DiscountRequestItem item);
    }
}