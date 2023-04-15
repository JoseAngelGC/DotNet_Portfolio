using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS.Application.Interfaces.CategoryServices.Commands.SaveItem;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;
using POS.Utilities.Commons.Consts;

namespace POS.Test.CategoryApi.V1.EndPoints.SaveCategory
{
    [TestClass]
    public class SaveCategoryEndPointV1Test
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task SaveCategory_WhenSendingNullOrEmptyValues_ValidationErrors()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IAddCategoryApplication>();

            //Arrange
            string? Name = "";
            string? Description = "";
            int State = 1;
            var expectedMessage = ReplyMessage.MESSAGE_VALIDATE;
            var expectedStatusHttp = StatusCodes.Status400BadRequest;


            //Act
            var result = await context!.SaveItemAsync(new CategoryRequestDto
            {
                Name = Name,
                Description = Description,
                State = State,
            });
            var currentMessage = result.MessageResponse;
            var currentStatusHttp = result.StatusResponse;

            //Assert
            Assert.AreEqual(expectedMessage, currentMessage);
            Assert.AreEqual(expectedStatusHttp, currentStatusHttp);
        }

        [TestMethod]
        public async Task SaveCategory_WhenSendingCorrectValues_RegisteredSuccesful()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IAddCategoryApplication>();

            //Arrange
            string? Name = "UnitTest";
            string? Description = "Category about UnitTest";
            int State = 1;
            var expectedMessage = ReplyMessage.MESSAGE_SAVE;
            var expectedStatusHttp = StatusCodes.Status201Created;


            //Act
            var result = await context!.SaveItemAsync(new CategoryRequestDto
            {
                Name = Name,
                Description = Description,
                State = State,
            });
            var currentMessage = result.MessageResponse;
            var currentStatusHttp = result.StatusResponse;

            //Assert
            Assert.AreEqual(expectedMessage, currentMessage);
            Assert.AreEqual(expectedStatusHttp, currentStatusHttp);
        }
    }
}
