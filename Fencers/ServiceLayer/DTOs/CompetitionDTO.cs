using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.DTOs;

public class CompetitionDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Date is required.")]
    public DateOnly Date { get; set; }
}