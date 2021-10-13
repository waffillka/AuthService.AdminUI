using AuthService.Admin.EntityFramework.Shared.Entities.Identity;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Shared.Overrides
{
    public class IdentityProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<UserIdentity> _claimsFactory;
        private readonly UserManager<UserIdentity> _userManager;
        public IdentityProfileService(IUserClaimsPrincipalFactory<UserIdentity> claimsFactory, UserManager<UserIdentity> userManager)
        {
            _claimsFactory = claimsFactory;
            _userManager = userManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var principal = await _claimsFactory.CreateAsync(user);
            var claims = principal.Claims.ToList();
            context.IssuedClaims = claims;
        }
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
