using System.ComponentModel.DataAnnotations;

namespace BusinessLayer;

public class CompetitionFile
{
    public int Id { get; set; }
    public int FencerUID { get; set; }
    public DateTime TimeStamp { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Rank { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Points { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
}