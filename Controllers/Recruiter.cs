using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using capstone_backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace capstone_backend.Controllers
{
  [ApiController]
  [EnableCors]

  [Route("api/[controller]")]
  public class RecruiterInformationController : ControllerBase
  {

    private readonly DatabaseContext Db;

    public RecruiterInformationController(DatabaseContext context)
    {
      this.Db = context;
    }

    [HttpDelete("delete/{email}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public ActionResult DeleteRecruiter(string email)
    {
      var recruiter = Db.Recruiter.FirstOrDefault(recruiter => recruiter.RecruiterEmail == email);
      Db.Recruiter.Remove(recruiter);
      Db.SaveChanges();
      return Ok($"Success! {recruiter.RecruiterName} has been deleted.");
    }

    [HttpPost("/NewRecruiter")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public ActionResult PostNewRecruiter(Recruiters newRecruiter)
    {
      Db.Recruiter.Add(newRecruiter);
      Db.SaveChanges();
      return Ok(newRecruiter);
    }


    [HttpGet("/AllRecruiters")]

    public ActionResult GetAllRecruiters()
    {
      return Ok(Db.Recruiter.OrderBy(i => i.RecruiterName));
    }
  }
}