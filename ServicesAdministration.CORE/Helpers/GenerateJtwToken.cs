using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServicesAdministration.CORE.Helpers.Interfaces;
using ServicesAdministration.MODELS.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServicesAdministration.CORE.Helpers
{
    public class GenerateJtwToken : IGenerateJtwToken
    {

        #region Dependency
        private readonly AppSettings _appSettings;
        #endregion

        #region Constructor
        public GenerateJtwToken(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        #endregion

        #region Methods
        public async Task<string> GenerateJwtToken(UserModel user)
        {
            // generate token that is valid for 15 Minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }
        #endregion
    }
}
