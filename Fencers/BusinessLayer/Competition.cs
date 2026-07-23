namespace BusinessLayer;

public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public Dictionary<string, int> RankList { get; set; } // string or Fencer.Name????
    
    public List<Fencer> Fencers { get; set; }
    
    public List<CompetitionResults> CompetitionResults { get; set; }
}