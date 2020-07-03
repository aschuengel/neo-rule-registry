using System.Linq;
using System.Collections.Generic;

namespace Neo.Rule.Registry
{
    internal class DiscountService : IDiscountService
    {
        private readonly Dictionary<string, IDiscountStrategy> _strategies;

        // Inject all instances of the strategy
        public DiscountService(IEnumerable<IDiscountStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(element => element.TypeCode);
        }
        // The real business logic
        public DiscountResponse ComputeDiscount(DiscountRequest discountRequest, List<DiscountRule> rules)
        {
            var discountResponse = new DiscountResponse();
            foreach (var rule in rules)
            {
                var strategy = _strategies[rule.TypeCode];
                strategy.ComputeDiscountOnCart(rule, discountRequest, discountResponse);

                foreach (var item in discountRequest.Items)
                {
                    strategy.ComputeDiscountOnItem(rule, discountRequest, discountResponse, item);
                }
            }
            return discountResponse;
        }
    }
}