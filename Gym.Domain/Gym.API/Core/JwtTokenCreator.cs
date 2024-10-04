using Gym.DataAccess;
using Gym.Implementation.Exceptions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gym.API.Core
{
    public class JwtTokenCreator
    {
        private readonly GymContext _context;
        private readonly JwtSettings _settings;
        private readonly ITokenStorage _storage;

        public JwtTokenCreator(GymContext context, JwtSettings settings, ITokenStorage storage)
        {
            _context = context;
            _settings = settings;
            _storage = storage;
        }

        public string Create(string email, string password)
        {
            var user = _context.Users.Where(x => x.Email == email).Select(x => new
            {
                x.Email,
                x.Password,
                x.Name,
                x.LastName,
                x.Id,
                x.IsActivated,
                UseCaseIds = x.UseCases.Select(x => x.UseCaseId)
            }).FirstOrDefault();

            if (user == null )
            {
                throw new UnauthorizedAccessException();
            }

            if (!user.IsActivated)
            {
                throw new NotActivated("Your account needs to be activated by an admin.");
            }


            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new UnauthorizedAccessException();
            }

            Guid tokenGuid = Guid.NewGuid();

            string tokenId = tokenGuid.ToString();

            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Jti, tokenId, ClaimValueTypes.String),
                 new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer, ClaimValueTypes.String),
                 new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                 new Claim("Email", user.Email),
                 new Claim("FirstName", user.Name),
                 new Claim("LastName", user.LastName),
                 new Claim("Id", user.Id.ToString()),
                 new Claim("UseCaseIds", JsonConvert.SerializeObject(user.UseCaseIds)),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(_settings.Seconds),
                signingCredentials: credentials);

            _storage.Add(tokenGuid);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

