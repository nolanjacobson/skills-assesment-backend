using System;

namespace capstone_backend.Models
{
  public class Nurse
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NurseEmail { get; set; }
    public string PhoneNumber { get; set; }
    public string RecruiterEmail { get; set; }
    public string SkillsTestName { get; set; }
    public string TestDataPdf { get; set; }
    public DateTime TimeSubmitted { get; set; } = DateTime.UtcNow;

  }
}