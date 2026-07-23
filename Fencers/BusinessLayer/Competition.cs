using System.ComponentModel.DataAnnotations;

namespace BusinessLayer;

public class Competition
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    
    public List<CompetitionResult> CompetitionResults { get; set; }
}