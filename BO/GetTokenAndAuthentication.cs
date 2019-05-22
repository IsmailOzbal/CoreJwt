using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Helpers;
using Core2_2ApiJwt.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core2_2ApiJwt.BO
{
    public class GetTokenAndAuthentication : IToken
    {
        private readonly AppSettings _appSettings;
        private IGetUser _user;
        public GetTokenAndAuthentication(IOptions<AppSettings> appSettings, IGetUser user)
        {
            _appSettings = appSettings.Value;
            _user = user;
        }

        public TokenResponse Authenticate(string username, string password)
        {
            var user = _user.GetUsers().SingleOrDefault(x => x.Username == username && x.Password == Cryptography.Encrypt(password,_appSettings.Secret));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            TokenResponse tokenRes = new TokenResponse
            {
                token = tokenHandler.WriteToken(token),
                expireDate = tokenDescriptor.Expires,
                UserId = user.Id
            };

            return tokenRes;
        }
    }
}
