using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using AuthService.STS.Identity.Configuration.Interfaces;

namespace AuthService.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}







