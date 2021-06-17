using Moq;
using System.Threading.Tasks;
using Vortx.Application.Exceptions;
using Vortx.Application.Services;
using Vortx.Application.ViewModels;
using Vortx.Domain.Entities;
using Vortx.Domain.Interfaces;
using Xunit;

namespace Vortx.Application.Tests.Services
{
    [Collection(nameof(TestCollection))]
    public class AppPriceTests
    {
        private readonly TestsFixtures _testsFixtures;

        public AppPriceTests(TestsFixtures testsFixtures)
        {
            _testsFixtures = testsFixtures;
        }

        [Fact(DisplayName = "Add New Price With Success")]
        [Trait("Category", "App Price - Add price")]
        public async Task AppPrice_Add_ShouldBeSuccessful()
        {
            //Arrange
            var price = _testsFixtures.GenerateNewPrice();
            var repoPrice = new Mock<IPriceRepository>();
            var appPrice = new AppPrice(repoPrice.Object);

            //Act            
            await appPrice.Add(new PriceViewModel(price));

            //Assert            
            repoPrice.Verify(r => r.Add(price), Times.Once);
        }

        [Fact(DisplayName = "Verify If Exists Price Already Registered")]
        [Trait("Category", "App Price - Verify price registered")]
        public async Task AppPrice_VerifyPriceAlreadyRegistered_ShouldBeReturnException()
        {
            //Arrange
            var price = _testsFixtures.GenerateNewPrice();
            var repoPrice = new Mock<IPriceRepository>();

            repoPrice.Setup(r => r.VerifyExistsPriceRegistered(price.DddOrigin, price.DddDestination))
                .Returns(Task.FromResult(true));

            var appPrice = new AppPrice(repoPrice.Object);

            //Act
            var resultException = await Assert
                .ThrowsAsync<ApiException>(() => appPrice.Add(new PriceViewModel(price)));

            //Assert
            Assert.Equal("Já existe um preço cadastrado para os DDDs de origem e destino informados.", 
                resultException.Message);
        }

        [Fact(DisplayName = "Verify If Price Don't Exists")]
        [Trait("Category", "App Price - Verify price don't exists")]
        public async Task AppPrice_VerifyPriceDontExists_ShouldBeReturnException()
        {
            //Arrange
            var price = _testsFixtures.GenerateNewPrice();
            var repoPrice = new Mock<IPriceRepository>();

            repoPrice.Setup(r => r.GetById(price.Id)).Returns(Task.FromResult((Price)null));

            var appPrice = new AppPrice(repoPrice.Object);

            //Act
            var resultException = await Assert
                .ThrowsAsync<ApiException>(() => appPrice.VerifyPrice(price.Id));

            //Assert
            Assert.Equal("Preço de origens e destinos não encontrado!", resultException.Message);
        }

        [Fact(DisplayName = "Get All Price With Success")]
        [Trait("Category", "App Price - Get All prices")]
        public async Task AppPrice_GetAll_ShouldBeSuccessful()
        {
            //Arrange             
            var repoPrice = new Mock<IPriceRepository>();

            repoPrice.Setup(r => r.GetAll()).Returns(Task.FromResult(_testsFixtures.GeneratePrices()));

            var appPrice = new AppPrice(repoPrice.Object);

            //Act
            var result = await appPrice.GetAll();

            //Assert
            Assert.NotNull(result);
            repoPrice.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact(DisplayName = "Get Price By Id With Success")]
        [Trait("Category", "App Price - Get price by id")]
        public async Task AppPrice_GetById_ShouldBeSuccessful()
        {
            //Arrange             
            var price = _testsFixtures.GenerateNewPrice();
            var repoPrice = new Mock<IPriceRepository>();

            repoPrice.Setup(r => r.GetById(price.Id)).Returns(Task.FromResult(price));

            var appPrice = new AppPrice(repoPrice.Object);

            //Act
            var result = await appPrice.GetById(price.Id);

            //Assert
            Assert.NotNull(result);
            repoPrice.Verify(r => r.GetById(price.Id), Times.Once);
        }

        [Fact(DisplayName = "Remove Price With Success")]
        [Trait("Category", "App Price - Remove price")]
        public async Task AppPrice_RemovePrice_ShouldBeRemovedWithSuccess()
        {
            //Arrange             
            var price = _testsFixtures.GenerateNewPrice();
            var repoPrice = new Mock<IPriceRepository>();

            repoPrice.Setup(r => r.GetById(price.Id)).Returns(Task.FromResult(price));

            var appPrice = new AppPrice(repoPrice.Object);

            //Act
            await appPrice.Remove(price.Id);

            //Assert
            repoPrice.Verify(r => r.Delete(price), Times.Once);
        }

        [Fact(DisplayName = "Update Price With Success")]
        [Trait("Category", "App Price - Update price")]
        public async Task AppPrice_UpdatePrice_ShouldBeUpdatedWithSuccess()
        {
            //Arrange             
            var price = _testsFixtures.GenerateNewPrice();
            var repoPrice = new Mock<IPriceRepository>();

            repoPrice.Setup(r => r.GetById(price.Id)).Returns(Task.FromResult(price));

            var appPrice = new AppPrice(repoPrice.Object);

            //Act
            await appPrice.Update(price.Id, new PriceViewModel(price));

            //Assert
            repoPrice.Verify(r => r.Update(price), Times.Once);
        }

    }
}
