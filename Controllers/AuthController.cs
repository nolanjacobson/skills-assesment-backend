using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using capstone_backend.Services;
using capstone_backend.Models;
using capstone_backend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AuthExample.Controllers
{
  [Route("auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly DatabaseContext db;
    private readonly AuthService authService;

    public AuthController(DatabaseContext context, AuthService auth)
    {
      this.db = context;
      this.authService = auth;
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUpUser(NewUserModel userData)
    {
      var existingUser = await this.db.Users.FirstOrDefaultAsync(f => f.Email.ToLower() == userData.Email.ToLower());
      var secret = Environment.GetEnvironmentVariable("SECRET_HASH");
      if (userData.SecretHash == secret)
      {
        var user = new User
        {
          Email = userData.Email,
          HashedPassword = "",
          SecretHash = ""
        };

        var hashed = new PasswordHasher<User>().HashPassword(user, userData.Password);
        user.HashedPassword = hashed;

        this.db.Users.Add(user);
        await this.db.SaveChangesAsync();
        var rv = this.authService.CreateToken(user);
        return Ok(rv);
      }
      else if (existingUser != null)
      {
        return BadRequest(new { Message = "user already exists" });
      }
      else
      {
        return BadRequest();
      }
    }



    [HttpPost("login")]
    public async Task<ActionResult> LoginUser(LoginViewModel loginData)
    {
      var user = await this.db.Users.FirstOrDefaultAsync(f => f.Email.ToLower() == loginData.Email.ToLower());
      if (user == null)
      {
        return BadRequest(new { Message = "User does not exist" });
      }

      var verificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, loginData.Password);

      if (verificationResult == PasswordVerificationResult.Success)
      {
        var rv = this.authService.CreateToken(user);
        return Ok(rv);
      }
      else
      {
        return BadRequest(new { message = "Wrong password" });
      }
    }
    [HttpPut("update/password")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public async Task<ActionResult> UpdatePassword(NewUserModel updatedData)
    {
      var secret = Environment.GetEnvironmentVariable("SECRET_HASH");

      var existingUser = this.db.Users.FirstOrDefault(f => f.Email == updatedData.Email);
      if (updatedData.SecretHash == secret)
      {
        existingUser.Email = updatedData.Email;
        existingUser.HashedPassword = "";
        existingUser.SecretHash = "";
        var hashed = new PasswordHasher<User>().HashPassword(existingUser, updatedData.Password);
        existingUser.HashedPassword = hashed;
        await this.db.SaveChangesAsync();
        var rv = this.authService.CreateToken(existingUser);
        return Ok(rv);
      }
      else if (existingUser != null)
      {
        return BadRequest(new { Message = "user already exists" });
      }
      else
      {
        return BadRequest();
      }

    }

  }
}