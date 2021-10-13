using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuthService.Admin.EntityFramework.Shared.DbContexts;
using AuthService.STS.Identity.Helpers;

namespace AuthService.STS.Identity.Configuration.Test
{
    public class StartupTest : Startup
    {
        public StartupTest(IWebHostEnvironment environment, IConfiguration configuration) : base(environment, configuration)
        {
        }

        public override void RegisterDbContexts(IServiceCollection services)
        {
            services.RegisterDbContextsStaging<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, IdentityServerDataProtectionDbContext>();
        }
    }
}







