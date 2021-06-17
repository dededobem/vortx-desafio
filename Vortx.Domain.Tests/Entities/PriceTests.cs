using System;
using Vortx.Domain.Entities;
using Xunit;

namespace Vortx.Domain.Tests.Entities
{
    public class PriceTests
    {
        [Theory(DisplayName = "Calculate Price Without Plan")]
        [Trait("Category", "Price - Calculate price")]
        [InlineData("011", "016", 1.90, 20, 38)]
        [InlineData("011", "017", 1.70, 80, 136)]
        [InlineData("018", "011", 1.90, 200, 380)]
        public void Price_CalculatePriceWithoutPlan_ShouldBeReturnValueCorrect(string dddOrigin,
            string dddDestination, double priceMinute, int callTime, double expected)
        {
            //Arrange
            var price = new Price(Guid.NewGuid(), dddOrigin, dddDestination, 
                priceMinute, DateTime.Now, null);

            //Act
            var result = price.CalculateCall(callTime);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
