namespace BusinessLayer;

public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    
    public List<Fencer> Fencers { get; set; }
    
    public List<CompetitionResult> CompetitionResults { get; set; }
}