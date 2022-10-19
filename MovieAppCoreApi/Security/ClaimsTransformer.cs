using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieAppCoreApi.Security
{

        public class ClaimsTransformer : IClaimsTransformation
        {
            public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
            {
                var ci = (ClaimsIdentity)principal.Identity;
                var c = new Claim(ci.RoleClaimType, "Admin");
                ci.AddClaim(c);
                return Task.FromResult(principal);
            }
        }
    }


