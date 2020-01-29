using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using capstone_backend.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace capstone_backend.Services
{
  public class AuthService
  {

    private readonly IConfiguration configuration;

    public AuthService(IConfiguration config)
    {
      this.configuration = config;
    }


    public AuthenticatedData CreateToken(Models.User user)
    {
      var TokenKey = this.configuration["TOKEN_KEY"];

      var expirationTime = DateTime.UtcNow.AddHours(10);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
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