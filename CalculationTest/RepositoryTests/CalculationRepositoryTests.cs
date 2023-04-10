using Factory;
using Interfaces.Repositories;
using Moq;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationTest.RepositoryTests
{

    public class CalculationRespositoryTests
    {
        private readonly Mock<IFunctionFactoryWrapper> _mockFunctionFactoryWrapper;
        private readonly ICalculationRepository _sut;

        public CalculationRespositoryTests()
        {
            _mockFunctionFactoryWrapper = new Mock<IFunctionFactoryWrapper>();

            _sut = new CalculationRespository(_mockFunctionFactoryWrapper.Object);
        }

        [Fact]
        public async Task Add_ShouldCreateLogFile_WhenDirectoryDoesNotExist()
        {
            // Arrange
            var message = "Test message";
            var path = "C:\\logsTestWithoutDirectory";

            // Act
            await _sut.Add(message, path);

            // Assert
            var files = Directory.GetFiles(path, "log*.txt");
            Assert.Single(files);
        }

        [Fact]
        public async Task Add_ShouldCreateLogFile_WhenDirectoryExists()
        {
            // Arrange
            var message = "Test message";
            var path = "C:\\logsTestWithDirectory";

            Directory.CreateDirectory(path);

            // Act
            await _sut.Add(message, path);

            // Assert
            var files = Directory.GetFiles(path, "log*.txt");
            Assert.Single(files);
        }

        [Fact]
        public async Task Add_ShouldThrowException_WhenLoggingFails()
        {
            // Arrange
            var message = "Test message";
            string path = null;

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _sut.Add(message, path));
        }
    }

}
