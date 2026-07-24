using System.ComponentModel.DataAnnotations;

namespace BusinessLayer;

public class CompetitionResult
{
    public int Id { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Rank { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Points { get; set; }
    
    public int CompetitionID { get; set; }
    public Competition Competition { get; set; }
    
    public int FencerId { get; set; }
    public Fencer Fencer { get; set; }
}