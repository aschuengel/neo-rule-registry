namespace Neo.Rule.Registry
{
    public class DiscountRule
    {
        public string TypeCode { get; internal set; }
        public int Value { get; internal set; }
        public ValueType ValueType { get; internal set; }
    }
}