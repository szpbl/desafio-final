using bibliotecaAPI.Services.Auth.Jwt.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bibliotecaAPI.Services.Auth.Jwt
{
    public class JwtAuthManager : IJwtAuthManager
    {
        #region Properties

        private readonly JwtConfigurations _jwtConfigurations;

        #endregion


        #region Constructor

        public JwtAuthManager(IOptions<JwtConfigurations> jwtConfigurations)
        {
            this._jwtConfigurations = jwtConfigurations.Value;
        }

        #endregion


        #region Methods

        public JwtAuth GenerateToken(JwtCredentials credentials)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, credentials.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, credentials.Role)
            };

            var key = Encoding.ASCII.GetBytes(_jwtConfigurations.Secret);

            var jwtToken = new JwtSecurityToken(
                    _jwtConfigurations.Issuer,
                    _jwtConfigurations.Audience,
                    claims,
                    expires: DateTime.Now.AddMilliseconds(_jwtConfigurations.ValidMinutes),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature));

            var acessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new JwtAuth
            {
                AccessToken = acessToken,
                TokenType = "bearer",
                ExpiresIn = _jwtConfigurations.ValidMinutes * 60
            };
        }

        #endregion

    }
}
