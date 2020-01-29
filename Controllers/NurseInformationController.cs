using Microsoft.AspNetCore.Mvc;
using capstone_backend.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace capstone_backend.Controllers
{
  [ApiController]
  [EnableCors]
  [Route("api/[controller]")]
  public class NurseInformationController : ControllerBase
  {

    private readonly DatabaseContext Db;

    public NurseInformationController(DatabaseContext context)
    {
      this.Db = context;
    }
    [HttpPost]

    public ActionResult PostNurseInformation(Nurse newNurse)
    {
      Db.Nurse.Add(newNurse);
      Db.SaveChanges();
      Email.SendEmail(newNurse);
      return Ok(newNurse);
    }

    [HttpGet("All")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public ActionResult GetAllNurses()
    {
      return Ok(Db.Nurse.Select(s => new { s.Id, s.FirstName, s.LastName, s.NurseEmail, s.PhoneNumber, s.RecruiterEmail, s.SkillsTestName, s.TimeSubmitted }));
    }
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public ActionResult GetANurse(int id)
    {
      var nurse = Db.Nurse.Where(theId => theId.Id == id).Select(theId => theId.TestDataPdf);
      if (id != 0)
      {
        return Ok(nurse);
      }
      else
      {
        return NotFound();
      }
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public ActionResult DeleteNurse(int id)
    {
      var nurse = Db.Nurse.FirstOrDefault(nurse => nurse.Id == id);
      Db.Nurse.Remove(nurse);
      Db.SaveChanges();
      return Ok($"Success! {nurse.FirstName} {nurse.LastName} has been deleted.");
    }

  }
}