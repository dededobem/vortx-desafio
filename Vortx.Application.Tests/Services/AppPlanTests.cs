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
    public class AppPlanTests
    {
        private readonly TestsFixtures _testsFixtures;

        public AppPlanTests(TestsFixtures testsFixtures)
        {
            _testsFixtures = testsFixtures;
        }

        [Fact(DisplayName = "Add New Plan With Success")]
        [Trait("Category", "App Plan - Add plan")]
        public async Task AppPlan_Add_ShouldBeSuccessful()
        {
            //Arrange
            var plan = _testsFixtures.GenerateNewPlan();
            var repoPlan = new Mock<IPlanRepository>();
            var appPlan = new AppPlan(repoPlan.Object);

            //Act            
            await appPlan.Add(new PlanViewModel(plan));

            //Assert            
            repoPlan.Verify(r => r.Add(plan), Times.Once);
        }

        [Fact(DisplayName = "Verify If Exists Plan With Same Name")]
        [Trait("Category", "App Plan - Verify name plan")]
        public async Task AppPlan_VerifyPlanNameAlreadyExists_ShouldBeReturnException()
        {
            //Arrange
            var plan = _testsFixtures.GenerateNewPlan();
            var repoPlan = new Mock<IPlanRepository>();

            repoPlan.Setup(r => r.VerifyExists(plan.Name)).Returns(Task.FromResult(true));

            var appPlan = new AppPlan(repoPlan.Object); 

            //Act
            var resultException = await Assert
                .ThrowsAsync<ApiException>(() => appPlan.Add(new PlanViewModel(plan)));

            //Assert
            Assert.Equal("Já existe um plano cadastrado com este nome.", resultException.Message);
        }

        [Fact(DisplayName = "Verify If Plan Don't Exists")]
        [Trait("Category", "App Plan - Verify plan don't exists")]
        public async Task AppPlan_VerifyPlanDontExists_ShouldBeReturnException()
        {
            //Arrange
            var plan = _testsFixtures.GenerateNewPlan();
            var repoPlan = new Mock<IPlanRepository>();
            
            repoPlan.Setup(r => r.GetById(plan.Id)).Returns(Task.FromResult((Plan)null));

            var appPlan = new AppPlan(repoPlan.Object);

            //Act
            var resultException = await Assert
                .ThrowsAsync<ApiException>(() => appPlan.VerifyPlan(plan.Id));

            //Assert
            Assert.Equal("Plano não encontrado!", resultException.Message);
        }

        [Fact(DisplayName = "Get All Plan With Success")]
        [Trait("Category", "App Plan - Get All plans")]
        public async Task AppPlan_GetAll_ShouldBeSuccessful()
        {
            //Arrange             
            var repoPlan = new Mock<IPlanRepository>();

            repoPlan.Setup(r => r.GetAll()).Returns(Task.FromResult(_testsFixtures.GeneratePlans()));

            var appPlan = new AppPlan(repoPlan.Object);

            //Act
            var result = await appPlan.GetAll();

            //Assert
            Assert.NotNull(result);
            repoPlan.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact(DisplayName = "Get Plan By Id With Success")]
        [Trait("Category", "App Plan - Get plan by id")]
        public async Task AppPlan_GetById_ShouldBeSuccessful()
        {
            //Arrange             
            var plan = _testsFixtures.GenerateNewPlan();
            var repoPlan = new Mock<IPlanRepository>();

            repoPlan.Setup(r => r.GetById(plan.Id)).Returns(Task.FromResult(plan));

            var appPlan = new AppPlan(repoPlan.Object);

            //Act
            var result = await appPlan.GetById(plan.Id);

            //Assert
            Assert.NotNull(result);            
            repoPlan.Verify(r => r.GetById(plan.Id), Times.Once);
        }

        [Fact(DisplayName = "Remove Plan With Success")]
        [Trait("Category", "App Plan - Remove plan")]
        public async Task AppPlan_RemovePlan_ShouldBeRemovedWithSuccess()
        {
            //Arrange             
            var plan = _testsFixtures.GenerateNewPlan();
            var repoPlan = new Mock<IPlanRepository>();

            repoPlan.Setup(r => r.GetById(plan.Id)).Returns(Task.FromResult(plan));

            var appPlan = new AppPlan(repoPlan.Object);

            //Act
            await appPlan.Remove(plan.Id);

            //Assert
            repoPlan.Verify(r => r.Delete(plan), Times.Once);
        }

        [Fact(DisplayName = "Update Plan With Success")]
        [Trait("Category", "App Plan - Update plan")]
        public async Task AppPlan_UpdatePlan_ShouldBeUpdatedWithSuccess()
        {
            //Arrange             
            var plan = _testsFixtures.GenerateNewPlan();
            var repoPlan = new Mock<IPlanRepository>();

            repoPlan.Setup(r => r.GetById(plan.Id)).Returns(Task.FromResult(plan));

            var appPlan = new AppPlan(repoPlan.Object);

            //Act
            await appPlan.Update(plan.Id, new PlanViewModel(plan));

            //Assert
            repoPlan.Verify(r => r.Update(plan), Times.Once);
        }


    }
}
