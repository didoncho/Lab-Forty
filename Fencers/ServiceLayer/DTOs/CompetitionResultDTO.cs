using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace ServiceLayer.DTOs;

public class CompetitionResultDTO
{
    [Ignore]
    public int Id { get; set; }
    
    [Required]
    public int Rank { get; set; }
    
    [Required]
    public int Points { get; set; }
    
    [Required]
    public int FencerUID { get; set; }
    
    [Ignore]
    public int FencerId { get; set; }
    
    [Ignore]
    public int CompetitionId { get; set; }
}