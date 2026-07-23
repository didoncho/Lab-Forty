namespace BusinessLayer;

public class CompetitionResults
{
    public int Rank { get; set; }
    public int Points { get; set; }
    
    public int CompetitionID { get; set; }
    public Competition Competition { get; set; }
    
    public int FencerId { get; set; }
    public Fencer Fencer { get; set; }
}