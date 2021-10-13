using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;

namespace AuthService.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}







