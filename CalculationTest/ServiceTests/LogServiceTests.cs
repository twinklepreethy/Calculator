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
        private readonly Fixture _fixture = new Fixture();

        public LogServiceTests()
        {
            _mockCalculatorRepository = new Mock<ICalculationRepository>();

            _sut = new LogService(_mockCalculatorRepository.Object);
        }

        [Fact]
        public async Task Add_LogsMessageToRepository_HappyPath()
        {
            // Arrange
            var calculationDto = _fixture.Build<CalculationDto>().Create();

            var expectedMessage = $"Date: {calculationDto.Date}, " +
                                  $"'\n' Caculation Type: {calculationDto.Function}, '\n' " +
                                  $"Inputs: P(A) - {calculationDto.ProbabilityA} and " +
                                  $"P(B) - {calculationDto.ProbabilityB}, '\n'" +
                                  $"Result: {calculationDto.Result}";

            // Act
            await _sut.Add(calculationDto);

            // Assert
            _mockCalculatorRepository.Verify(x => x.Add(expectedMessage), Times.Once);
        }

        [Fact]
        public async Task Add_ThrowsArgumentNullException_WhenCalculationDtoIsNull()
        {
            //Arrange
            CalculationDto calculationDto = null;

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(async () => await _sut.Add(calculationDto));
        }
    }

}
