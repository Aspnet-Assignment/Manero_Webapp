using Moq;
using Bunit;
using Xunit;
using Manero_WebApp.Components.Account;
using Manero_WebApp.Components.Account.Pages;
using Manero_WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components; // Adjust namespace as needed

public class LoginTests : TestContext
{
    [Fact]
    public async Task LoginUser_ShouldRedirectToProductHome_WhenLoginSucceeds()
    {
        // Arrange
        // Mock dependencies
        var signInResult = SignInResult.Success;
        var signInManagerMock = new Mock<SignInManager<ApplicationUser>>(userManager, null, null, null, null, null, null);
        signInManagerMock.Setup(s => s.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), false))
                         .ReturnsAsync(signInResult);

        var loggerMock = new Mock<ILogger<Login>>();
        var navigationManagerMock = new Mock<NavigationManager>();
        var redirectManagerMock = new Mock<IdentityRedirectManager>();

        var loginComponent = RenderComponent<Login>(
            ("SignInManager", signInManagerMock.Object),
            ("Logger", loggerMock.Object),
            ("NavigationManager", navigationManagerMock.Object),
            ("RedirectManager", redirectManagerMock.Object)
        );

        // Act
        await loginComponent.Instance.LoginUser();

        // Assert
        // Verify that the logger logs the user in
        loggerMock.Verify(l => l.LogInformation("User logged in."), Times.Once);

        // Verify that the redirect manager redirects to the product home page
        redirectManagerMock.Verify(r => r.RedirectTo("/producthome"), Times.Once);
    }
}
