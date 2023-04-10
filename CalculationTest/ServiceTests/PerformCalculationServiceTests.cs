using AutoFixture;
using CalculationUI.Models;
using Factory;
using Interfaces.Services;
using Model.DTOs;
using Model.Enums;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationTest.ServiceTests
{
    public class PerformCalculationServiceTests
    {
        private readonly IPerformCalculationService _sut;
        private readonly Mock<IFunctionFactoryWrapper> _mockFunctionFactoryWrapper;
        private readonly Mock<ILogService> _mockLogService;
        private readonly Fixture _fixture = new Fixture();

        public PerformCalculationServiceTests()
        {
            _mockFunctionFactoryWrapper = new Mock<IFunctionFactoryWrapper>();
            _mockLogService = new Mock<ILogService>();
            _sut = new PerformCalculationService(_mockFunctionFactoryWrapper.Object, _mockLogService.Object);
        }

        [Fact]
        public async Task PerformCalculation_CombinedWithSelected_HappyPath()
        {
            // Arrange
            var calculationVM = _fixture.Build<CalculationViewModel>()
                                        .With(x => x.ProbabilityA, 0.5m)
                                        .With(x => x.ProbabilityB, 0.5m)
                                        .With(x => x.SelectedFunctionId, (int)FunctionTypeEnum.CombinedWith)
                                        .Create();

            var function = _fixture.Build<CombinedWithFunction>().Create();

            _mockFunctionFactoryWrapper.Setup(f => f.CreateFunctionFactory(FunctionTypeEnum.CombinedWith))
                .ReturnsAsync(function);

            // Act
            var result = await _sut.PerformCalculation(calculationVM);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0.25m, result.Result);
            Assert.Equal(calculationVM.ProbabilityA, result.ProbabilityA);
            Assert.Equal(calculationVM.ProbabilityB, result.ProbabilityB);
            Assert.Equal(function.Formula, result.Function);
        }

        [Fact]
        public async Task PerformCalculation_EitherSelected_HappyPath()
        {
            // Arrange
            var calculationVM = _fixture.Build<CalculationViewModel>()
                                        .With(x => x.ProbabilityA, 0.5m)
                                        .With(x => x.ProbabilityB, 0.5m)
                                        .With(x => x.SelectedFunctionId, (int)FunctionTypeEnum.Either)
                                        .Create();

            var function = _fixture.Build<EitherFunction>().Create();

            _mockFunctionFactoryWrapper.Setup(f => f.CreateFunctionFactory(FunctionTypeEnum.Either))
                .ReturnsAsync(function);

            // Act
            var result = await _sut.PerformCalculation(calculationVM);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0.75m, result.Result);
            Assert.Equal(calculationVM.ProbabilityA, result.ProbabilityA);
            Assert.Equal(calculationVM.ProbabilityB, result.ProbabilityB);
            Assert.Equal(function.Formula, result.Function);
        }

        [Fact]
        public async Task PerformCalculation_ReturnsNull_WhenFunctionFactoryIsNull()
        {
            // Arrange
            var calculationVM = _fixture.Build<CalculationViewModel>()
                                        .With(x => x.ProbabilityA, 0.5m)
                                        .With(x => x.ProbabilityB, 0.5m)
                                        .With(x => x.SelectedFunctionId, 0)
                                        .Create();

            // Act
            var result = await _sut.PerformCalculation(calculationVM);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task PerformCalculation_ThrowsException_WhenFunctionFactoryWrapperThrowsException()
        {
            // Arrange
            var calculationVM = _fixture.Build<CalculationViewModel>().Create();

            _mockFunctionFactoryWrapper.Setup(r => r.CreateFunctionFactory(It.IsAny<FunctionTypeEnum>()))
                .ThrowsAsync(new Exception("Test Exception"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _sut.PerformCalculation(calculationVM));
        }

        [Fact]
        public async Task PerformCalculation_DecimalMaxValue_ThrowsOverflowException()
        {
            // Arrange
            var calculationVM = _fixture.Build<CalculationViewModel>()
                                        .With(x => x.ProbabilityA, decimal.MaxValue)
                                        .With(x => x.ProbabilityB, 10)
                                        .With(x => x.SelectedFunctionId, (int)FunctionTypeEnum.CombinedWith)
                                        .Create();

            var function = _fixture.Build<CombinedWithFunction>().Create();

            _mockFunctionFactoryWrapper.Setup(f => f.CreateFunctionFactory(FunctionTypeEnum.CombinedWith))
                .ReturnsAsync(function);

            // Act & Assert
            await Assert.ThrowsAsync<OverflowException>(() => _sut.PerformCalculation(calculationVM));
        }

        [Fact]
        public async Task PerformCalculation_DecimalMinValue_ThrowsOverflowException()
        {
            // Arrange
            var calculationVM = _fixture.Build<CalculationViewModel>()
                                        .With(x => x.ProbabilityA, decimal.MinValue)
                                        .With(x => x.ProbabilityB, 10)
                                        .With(x => x.SelectedFunctionId, (int)FunctionTypeEnum.CombinedWith)
                                        .Create();

            var function = _fixture.Build<CombinedWithFunction>().Create();

            _mockFunctionFactoryWrapper.Setup(f => f.CreateFunctionFactory(FunctionTypeEnum.CombinedWith))
                .ReturnsAsync(function);

            // Act & Assert
            await Assert.ThrowsAsync<OverflowException>(() => _sut.PerformCalculation(calculationVM));
        }

        [Fact]
        public async Task PerformCalculation_PrecisionGreaterThan28_HappyPath()
        {
            // Arrange
            var calculationVM = _fixture.Build<CalculationViewModel>()
                                        .With(x => x.ProbabilityA, 0.4444444444444444444444444444555m)
                                        .With(x => x.ProbabilityB, 1)
                                        .With(x => x.SelectedFunctionId, (int)FunctionTypeEnum.CombinedWith)
                                        .Create();

            var function = _fixture.Build<CombinedWithFunction>().Create();

            _mockFunctionFactoryWrapper.Setup(f => f.CreateFunctionFactory(FunctionTypeEnum.CombinedWith))
                .ReturnsAsync(function);

            // Act
            var result = await _sut.PerformCalculation(calculationVM);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0.4444m, result.Result);
            Assert.Equal(calculationVM.ProbabilityA, result.ProbabilityA);
            Assert.Equal(calculationVM.ProbabilityB, result.ProbabilityB);
            Assert.Equal(function.Formula, result.Function);
        }
    }
}
