namespace BusinessLayer;

public class Coach
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Egn { get; set; }
    public string BirthPlace { get; set; }
    public string Address { get; set; }
    
    public List<Fencer>  Fencers { get; set; }
}