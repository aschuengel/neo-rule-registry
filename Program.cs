using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.Rule.Registry
{
    class Program
    {
        static void Main(string[] args)
        {
            // Search all the implementations
            var type = typeof(IDiscountStrategy);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(implemetingType => type.IsAssignableFrom(implemetingType) && !implemetingType.IsAbstract);

            var collection = new ServiceCollection();
            foreach (var implemetingType in types)
            {
                collection.AddSingleton(type, implemetingType);
            }

            collection.AddSingleton<IDiscountService, DiscountService>();
            var provider = collection.BuildServiceProvider();

            var service = provider.GetService<IDiscountService>();

            // From database
            var rules = new List<DiscountRule>
            {
                new DiscountRule
                {
                    TypeCode = "PercentageOnCart",
                    Value = 10,
                    ValueType = ValueType.Percent
                },
                new DiscountRule
                {
                    TypeCode = "PercentageOnItem",
                    Value = 10,
                    ValueType = ValueType.Percent
                }
            };

            // From API controller
            var request = new DiscountRequest
            {
                Items = new List<DiscountRequestItem> {
                    new DiscountRequestItem {
                        SfId = "asas"
                    },
                    new DiscountRequestItem {
                        SfId = "asas"
                    }
                }
            };

            service.ComputeDiscount(request, rules);
        }
    }
}
