namespace BusinessLayer;

public class FencerInformation
{
    public int Id { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Egn { get; set; }
    public string BirthPlace { get; set; }
    public string Address { get; set; }
    
    public int FencerId { get; set; }
    public Fencer Fencer { get; set; }
}