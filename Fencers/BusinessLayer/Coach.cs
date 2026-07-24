using System.ComponentModel.DataAnnotations;

namespace BusinessLayer;

public class Coach
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    
    [MaxLength(10)]
    public string Egn { get; set; }
    
    public string BirthPlace { get; set; }
    
    [MaxLength(100)]
    public string Address { get; set; }
    
    public List<Fencer>  Fencers { get; set; }
}