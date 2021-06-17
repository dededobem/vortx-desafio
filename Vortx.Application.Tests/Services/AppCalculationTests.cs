using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Vortx.Application.Exceptions;
using Vortx.Application.Services;
using Vortx.Domain.Interfaces;
using Xunit;

namespace Vortx.Application.Tests.Services
{
    [Collection(nameof(TestCollection))]
    public class AppCalculationTests
    {
        private readonly TestsFixtures _testsFixtures;

        public AppCalculationTests(TestsFixtures testsFixtures)
        {
            _testsFixtures = testsFixtures;
        }

        [Fact(DisplayName = "Check if price already exists")]
        [Trait("Category", "App Calculation")]
        public async Task AppCalculation_VerifyExistsPrice_ShouldBeExceptionPriceNotRegistered()
        {
            //Arrange             
            var price = _testsFixtures.GenerateNewPrice();
            var mock = new AutoMocker();
            var appCalculation = mock.CreateInstance<AppCalculation>();

            mock.GetMock<IPriceRepository>().Setup(r => r
                .VerifyExistsPriceRegistered(price.DddOrigin, price.DddDestination))
                .Returns(Task.FromResult(false));

            //Act
            var resultEx = await Assert
                .ThrowsAsync<ApiException>(() => 
                    appCalculation.CalculatePrice(price.DddOrigin, price.DddDestination, 20, Guid.NewGuid()));            

            //Assert            
            Assert.Equal("Não existe preço cadastrado para a origem e o destino informados.", resultEx.Message);
        }
    }
}
