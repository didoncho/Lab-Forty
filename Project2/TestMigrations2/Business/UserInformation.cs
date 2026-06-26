using System.ComponentModel.DataAnnotations;

namespace Business;

public class UserInformation
{
    public int Id { get; set; }
    public string Egn { get; set; }

    [Required, MaxLength(100)]
    public string Address { get; set; }
    
    //public int UserId { get; set; }
    public User User { get; set; }
}