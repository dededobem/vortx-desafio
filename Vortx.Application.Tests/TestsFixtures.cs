using Bogus;
using System;
using System.Collections.Generic;
using Vortx.Domain.Entities;

namespace Vortx.Application.Tests
{
    public class TestsFixtures
    {
        public Plan GenerateNewPlan() => 
            new Plan(Guid.NewGuid(), "FaleMais30", 30, DateTime.Now, null);

        public IEnumerable<Plan> GeneratePlans()
        {

            var plans = new Faker<Plan>()
                .CustomInstantiator(f => new Plan(
                    Guid.NewGuid(),
                    "FaleMais" + f.Random.Number(0, 9999),
                    f.Random.Number(0, 9999),
                    DateTime.Now,
                    null
                    ));
            return plans.Generate(10);
        }

        public IEnumerable<Price> GeneratePrices()
        {

            var prices = new Faker<Price>()
                .CustomInstantiator(f => new Price(
                    Guid.NewGuid(),
                    "0" + f.Random.Number(10, 99),
                    "0" + f.Random.Number(10, 99),
                    f.Random.Double(1, 2),
                    DateTime.Now,
                    null
                    ));
            return prices.Generate(10);
        }

        public Price GenerateNewPrice() =>
            new Price(Guid.NewGuid(), "011", "017", 1.90, DateTime.Now, null);
         
    }
}
