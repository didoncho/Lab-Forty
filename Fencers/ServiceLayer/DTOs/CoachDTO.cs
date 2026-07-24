using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.DTOs;

//DTO = Data transfer object
public class CoachDTO
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of birth is required.")]
    public DateOnly DateOfBirth { get; set; }

    public string Egn { get; set; } = string.Empty;
    public string BirthPlace { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}