using NSubstitute;
using Bunit;
using Moq;
using Xunit;
using Manero_WebApp.Components.Account;
using Manero_WebApp.Components.Account.Pages;
using Manero_WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.

public class LoginTests : TestContext
{
    [Fact]
    public async Task LoginUser_RedirectsToProductHome_WhenLoginSucceeds()
    {
        // Arrange
        var services = new TestServiceProvider().AddTestAuthorization();

        // Set up any necessary dependencies
        // For example, you might need to mock a database context or set up a test database

        // Add the Login component to the test context with mocked dependencies
        var loginComponent = RenderComponent<Login>(
            ("SignInManager", Substitute.For<SignInManager<ApplicationUser>>(/* mock SignInManager dependencies */)),
            ("Logger", Substitute.For<ILogger<Login>>()),
            ("RedirectManager", Substitute.For<IdentityRedirectManager>())
        );

        // Act
        await loginComponent.Instance.LoginUser();

        // Assert
        // Verify that the RedirectManager is called with the correct URL
        // You might need to use a different method to assert the redirection
        // depending on how the RedirectManager is implemented
        // For example, you might need to check if the URL in the browser has changed
    }
}