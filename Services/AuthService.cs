using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using capstone_backend.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace capstone_backend.Services
{
  public class AuthService
  {
    public AuthenticatedData CreateToken(Models.User user)
    {
      var TokenKey = Environment.GetEnvironmentVariable("TOKEN_KEY");

      var expirationTime = DateTime.UtcNow.AddHours(10);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim("id", user.Id.ToString()),
      }),
        Expires = expirationTime,

        SigningCredentials = new SigningCredentials(
               new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenKey)),
              SecurityAlgorithms.HmacSha256Signature
          )
      };
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
      return new AuthenticatedData
      {
        Token = token,
        UserId = user.Id,
        ExpirationTime = expirationTime

      }; ;
    }
  }
}