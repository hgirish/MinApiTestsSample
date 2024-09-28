using Microsoft.AspNetCore.Authentication;

namespace IntegrationTests.Helpers;

public class TestAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
    public string IsAdmin { get; set; } = "false";
}
