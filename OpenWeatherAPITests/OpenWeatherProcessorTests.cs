using OpenWeatherAPI;
using System;
using Xunit;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests : IDisposable
    {
        OpenWeatherProcessor _sut = OpenWeatherProcessor.Instance;

        [Fact]
        public async void GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentExceptionAsync()
        {
            // if null

            // Arrange
            _sut.ApiKey = null;

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetOneCallAsync());

            // if empty

            // Arrange
            _sut.ApiKey = "";

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetOneCallAsync());
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
