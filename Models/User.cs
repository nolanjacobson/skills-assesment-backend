using System.ComponentModel.DataAnnotations;

namespace capstone_backend.Models
{
  public class User
  {
    public int Id { get; set; }
    [Required]
    public string HashedPassword { get; set; }

    [Required]
    public string Email { get; set; }
    
  }
}