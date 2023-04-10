using AutoFixture;
using Interfaces.Repositories;
using Interfaces.Services;
using Model.DTOs;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationTest.ServiceTests
{
    public class LogServiceTests
    {
        private readonly ILogService _sut;
        private readonly Mock<ICalculationRepository> _mockCalculatorRepository;
        private readonly Mock<IConfigurationService> _mockConfigurationService;
        private readonly Fixture _fixture = new Fixture();

        public LogServiceTests()
        {
            _mockCalculatorRepository = new Mock<ICalculationRepository>();
            _mockConfigurationService = new Mock<IConfigurationService>();

            _sut = new LogService(_mockCalculatorRepository.Object, _mockConfigurationService.Object);
        }

        [Fact]
        public async Task Add_LogsMessageToRepository_HappyPath()
        {
            // Arrange
            var calculationDto = _fixture.Build<CalculationDto>().Create();

            var expectedMessage = $"Date: {calculationDto.Date},\n" +
                                  $"Caculation Type: {calculationDto.Function},\n" +
                                  $"Inputs: P(A): {calculationDto.ProbabilityA} and " +
                                  $"P(B): {calculationDto.ProbabilityB},\n" +
                                  $"Result: {calculationDto.Result}";
            var expectedFilePath = "logFilePath";

            _mockConfigurationService.Setup(c => c.GetLogFilePath()).Returns(expectedFilePath);

            // Act
            await _sut.Add(calculationDto);

            // Assert
            _mockCalculatorRepository.Verify(c => c.Add(expectedMessage, expectedFilePath), Times.Once);
        }

        [Fact]
        public async Task LogError_LogsErrorToRepository_HappyPath()
        {
            // Arrange
            var expectedMessage = "Error: message";
            var expectedFilePath = "logFilePath";

            _mockConfigurationService.Setup(c => c.GetLogFilePath()).Returns(expectedFilePath);

            // Act
            await _sut.LogError("message");

            // Assert
            _mockCalculatorRepository.Verify(c => c.Add(expectedMessage, expectedFilePath), Times.Once);
        }

        [Fact]
        public async Task Add_Logserror_WhenAnExceptionIsThrown()
        {
            // Arrange
            CalculationDto calculationDto = null;
            var expectedFilePath = "logFilePath";
            var logServiceMock = new Mock<ILogService>();

            _mockConfigurationService.Setup(c => c.GetLogFilePath()).Returns(expectedFilePath);
            _mockCalculatorRepository.Setup(r => r.Add(It.IsAny<string>(), It.IsAny<string>()));            //logServiceMock.Setup(ls => ls.LogError(expectedMessage)).Verifiable();
            logServiceMock.Setup(ls => ls.LogError(It.IsAny<string>())).Verifiable();

            // Act
            await _sut.Add(calculationDto);

            // Assert
            _mockCalculatorRepository.Verify(c => c.Add(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }

}
