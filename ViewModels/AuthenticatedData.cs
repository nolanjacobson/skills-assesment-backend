using System;

namespace capstone_backend.ViewModels
{
  public class AuthenticatedData
  {
    public int UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpirationTime { get; set; }
  }
}