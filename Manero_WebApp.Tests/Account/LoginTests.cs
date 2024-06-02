using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;
using Manero_WebApp.Services;
using Microsoft.AspNetCore.Components;
using Manero_WebApp.Data;
using Microsoft.AspNetCore.Http;

public class LoginServiceTests
{
    [Fact]
    public async Task LoginUser_SuccessfulLogin_RedirectsToProductHome()
    {
        // Arrange
        var mockUserManager = new Mock<UserManager<ApplicationUser>>(
            Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

        var mockSignInManager = new Mock<SignInManager<ApplicationUser>>(
            mockUserManager.Object,
            Mock.Of<IHttpContextAccessor>(),
            Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
            null, null, null, null);

        var mockNavigationManager = new Mock<NavigationManager>(MockBehavior.Loose, null);
        var mockRedirectManager = new Mock<IdentityRedirectManager>(mockNavigationManager.Object);

        mockSignInManager
            .Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
            .ReturnsAsync(SignInResult.Success);

        var loginService = new LoginService(mockSignInManager.Object, mockRedirectManager.Object);

        var loginInput = new LoginService.InputModel
        {
            Email = "test@example.com",
            Password = "password",
            RememberMe = true
        };
        loginService.Input = loginInput;

        // Act
        await loginService.LoginUser();

        // Assert
        mockRedirectManager.Verify(redirect => redirect.RedirectTo("/producthome"), Times.Once);
    }
}
