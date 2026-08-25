using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.DTOs;

public class CompetitionResultDTO
{
    public int Id { get; set; }
    
    [Required]
    public int Rank { get; set; }
    
    [Required]
    public int Points { get; set; }
    
    [Required]
    public int FencerUID { get; set; }
}