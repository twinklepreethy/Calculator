using AutoFixture;
using Factory;
using Interfaces.Repositories;
using Interfaces.Services;
using Model.Enums;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CalculationTest.ServiceTests
{
    public class GetCalculationVMServiceTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly IGetCalculationVMService _sut;
        private readonly Mock<ICalculationRepository> _mockCalculationRepo;
        private readonly Mock<ILogService> _mockLogService;

        public GetCalculationVMServiceTests()
        {
            _mockCalculationRepo = new Mock<ICalculationRepository>();
            _mockLogService = new Mock<ILogService>();

            _sut = new GetCalculationVMService(_mockCalculationRepo.Object, _mockLogService.Object);
        }

        [Fact]
        public async Task GetCalculationVM_HappyPath()
        {
            // Arrange
            var functionFactories = new Dictionary<FunctionTypeEnum, Func<Function>>
            {
                { FunctionTypeEnum.Either, () => new EitherFunction() },
                { FunctionTypeEnum.CombinedWith, () => new CombinedWithFunction() }
            };

            _mockCalculationRepo.Setup(x => x.GetFunctionFactories()).ReturnsAsync(functionFactories);

            // Act
            var result = await _sut.GetCalculationVM();

            // Assert
            Assert.Equal(result.Functions.Count(), functionFactories.Count);
            foreach (var expectedFunction in functionFactories)
            {
                var actualFunction = result.Functions.FirstOrDefault(f => f.Id == (int)expectedFunction.Key);
                Assert.NotNull(actualFunction);
                Assert.Equal(expectedFunction.Value().Formula, actualFunction.Text);
            }
            Assert.Equal(0, result.Min);
            Assert.Equal(1, result.Max);
            Assert.Equal(0.01m, result.Step);
        }

        [Fact]
        public async Task GetCalculationVM_ThrowsException_WhenCalculationRepositoryThrowsException()
        {
            // Arrange
            _mockCalculationRepo.Setup(r => r.GetFunctionFactories())
                .ThrowsAsync(new Exception("Test Exception"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _sut.GetCalculationVM());
        }
    }
}
