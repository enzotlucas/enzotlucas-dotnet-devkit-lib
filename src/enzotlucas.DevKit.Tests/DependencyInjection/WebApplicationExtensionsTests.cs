using enzotlucas.DevKit.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace enzotlucas.DevKit.Tests.DependencyInjection
{
    public class WebApplicationExtensionsTests
    {
        [Fact]
        public void UseDevKit_ApplyMiddlewaresAndApiDocumentation_ShouldReturnWebApplication()
        {
            //Arrange
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDevKit();
            var app = builder.Build();

            //Act
            var act = () => app.UseDevKit();

            //Assert
            act.Should().NotThrow();
        }
    }
}
