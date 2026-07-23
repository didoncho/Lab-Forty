using System.ComponentModel.DataAnnotations;

namespace BusinessLayer;

public class Fencer
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    public int UID { get; set; }
    
    public int FencerInformationId { get; set; }
    public FencerInformation FencerInformation { get; set; }
    
    public int CoachId { get; set; }
    public Coach Coach { get; set; }
    
    public List<CompetitionResult> CompetitionResults { get; set; }
}