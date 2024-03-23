using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;

namespace MVC.Helpers
{
    public class JwtHelper
    {
        public static Dictionary<string, string> DecodeJwtToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var claims = new Dictionary<string, string>();

            foreach (var claim in token.Claims)
            {
                claims.Add(claim.Type, claim.Value);
            }

            return claims;
        }
    }
}
