
using capstone_backend.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace capstone_backend.Controllers
{
  public class Email
  {
    public static IRestResponse SendEmail(Nurse newNurse)
    {
      byte[] bytes = System.Convert.FromBase64String(newNurse.TestDataPdf.Substring(51));
      var apiKey = Environment.GetEnvironmentVariable("MAIL_GUN");

      RestClient client = new RestClient();
      client.BaseUrl = new Uri("https://api.mailgun.net/v3");
      client.Authenticator =
          new HttpBasicAuthenticator("api", apiKey);
      RestRequest request = new RestRequest();
      request.AddParameter("domain", "nurse2nurse.travel", ParameterType.UrlSegment);
      request.Resource = "{domain}/messages";
      request.AddParameter("from", "<new-submission@nurse2nursestaffing.com>");
      request.AddParameter("to", $"{newNurse.RecruiterEmail}");
      request.AddParameter("subject", "New Skills Assessment Test");
      request.AddParameter("text", $"First Name: {newNurse.FirstName} Last Name: {newNurse.LastName} Email: {newNurse.NurseEmail} Phone Number: {newNurse.PhoneNumber}");
      request.AddFileBytes("attachment", bytes, $"{newNurse.FirstName} {newNurse.LastName} - {newNurse.SkillsTestName} - {newNurse.TimeSubmitted.ToString("yyyy-MM-dd")}", "application/pdf");
      request.Method = Method.POST;
      return client.Execute(request);
    }
  }

}