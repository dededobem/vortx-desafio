using System;
using Vortx.Domain.Entities;
using Xunit;

namespace Vortx.Domain.Tests.Entities
{
    public class PlanTests
    {
        [Theory(DisplayName = "Calculate Price With Plan")]
        [Trait("Category", "Plan - Calculate price")]
        [InlineData(1.90, 20, "FaleMais30", 30, 0)]
        [InlineData(1.70, 80, "FaleMais60", 60, 37.40)]
        [InlineData(1.90, 200, "FaleMais120", 120, 167.20)]
        public void Plan_CalculatePriceWithPlan_ShouldBeReturnValueCorrect(double priceMinute, 
            int callTime, string description, int timeMinute, double expected)
        {
            //Arrange            
            var plan = new Plan(Guid.NewGuid(), description, timeMinute, DateTime.Now, null);

            //Act
            var result = plan.CalculateCall(priceMinute, callTime);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
