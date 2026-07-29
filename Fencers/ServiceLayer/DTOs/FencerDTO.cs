using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.DTOs;

public class FencerDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    public int UID { get; set; }
    public DateOnly DateOfBirth { get; set; }
    
    [Required(ErrorMessage = "Egn is required.")]
    [MaxLength(10)]
    public string Egn { get; set; } =  string.Empty;
    
    public string BirthPlace { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Coach is required.")]
    public int CoachId { get; set; }
}