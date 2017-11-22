using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;

namespace Cube {
    public static class GetClaimsIdentity {
        public static IEnumerable<Claim> GetInfo() {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            return identity.Claims;
        }
    }
}
