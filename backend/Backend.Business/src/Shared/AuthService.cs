using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.Business.src.Shared
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> VerifyCredentials(UserCredentialsDto credentials)
        {
            var foundUserByEmail = await _userRepository.FindOneByEmail(credentials.Email);
            var isAuthenticated = PasswordService.VerifyPassword(
                credentials.Password,
                foundUserByEmail.Password,
                foundUserByEmail.Salt
            );
            if (!isAuthenticated)
            {
                throw new Exception("Credentials do not match");
            }
            return GenerateToken(foundUserByEmail);
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var securityKey = new JsonWebKey("my-secret-key");
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor {
                Issuer = "ecommerce-backend",
                Expires = DateTime.UtcNow.AddMinutes(10),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return token.ToString();
        }
    }
}