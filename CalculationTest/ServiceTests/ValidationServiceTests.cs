using AutoFixture;
using CalculationUI.Models;
using Interfaces.Services;
using Microsoft.AspNetCore.Routing;
using Model.Constants;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculationTest.ServiceTests
{
    public class ValidationServiceTests
    {
        private readonly IValidationService _sut;
        private readonly Mock<ILogService> _mockLogService;
        private Fixture _fixture = new Fixture();

        public ValidationServiceTests()
        {
            _mockLogService = new Mock<ILogService>();

            _sut = new ValidationService(_mockLogService.Object);
        }

        [Fact]
        public async Task ValidateInputData_HappyPath()
        {
            //Arrange
            var vm = _fixture.Build<CalculationViewModel>()
                             .With(x => x.ProbabilityA, 0.5m)
                             .With(x => x.ProbabilityB, 0.5m)
                             .With(x => x.Max, 1)
                             .With(x => x.Min, 0)
                             .With(x => x.SelectedFunctionId, 1).Create();

            //Act
            var result = await _sut.ValidateInputData(vm);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ValidateInputData_ReturnsFalse_WhenCalculationVMIsNull()
        {
            // Arrange
            CalculationViewModel vm = null;

            // Act
            var result = await _sut.ValidateInputData(vm);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task ValidateInputData_ReturnsFalseAndLogsError_WhenProbabilityAGreaterThanMax()
        {
            // Arrange
            var calculationViewModel = _fixture.Build<CalculationViewModel>()
                                               .With(x => x.ProbabilityA, CalculationConstants.Max + 1)
                                               .With(x => x.ProbabilityB, 0.5m)
                                               .With(x => x.SelectedFunctionId, 1).Create();

            // Act
            var result = await _sut.ValidateInputData(calculationViewModel);

            // Assert
            Assert.False(result);
            _mockLogService.Verify(ls => ls.LogError(ErrorMessagesConstant.ProbabilityAMaxValueErrorMsg), Times.Once);
        }

        [Fact]
        public async Task ValidateInputData_ReturnsFalseAndLogsError_WhenProbabilityBLesserThanMin()
        {
            // Arrange
            var calculationViewModel = _fixture.Build<CalculationViewModel>()
                                               .With(x => x.ProbabilityA, 0)
                                               .With(x => x.ProbabilityB, CalculationConstants.Min - 1)
                                               .With(x => x.SelectedFunctionId, 1).Create();

            // Act
            var result = await _sut.ValidateInputData(calculationViewModel);

            // Assert
            Assert.False(result);
            _mockLogService.Verify(ls => ls.LogError(ErrorMessagesConstant.ProbabilityBMinValueErrorMsg), Times.Once);
        }

        [Fact]
        public async Task ValidateInputData_ReturnsFalseAndLogsError_WhenInvalidFunctionSelected()
        {
            // Arrange
            var calculationViewModel = _fixture.Build<CalculationViewModel>()
                                               .With(x => x.ProbabilityA, 0)
                                               .With(x => x.ProbabilityB, 1)
                                               .With(x => x.SelectedFunctionId, CalculationConstants.EmptyFunction).Create();

            // Act
            var result = await _sut.ValidateInputData(calculationViewModel);

            // Assert
            Assert.False(result);
            _mockLogService.Verify(ls => ls.LogError(ErrorMessagesConstant.InvalidFunctionSelectedErrorMsg), Times.Once);
        }
    }
}
