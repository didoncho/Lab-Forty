using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Business.NewEntities;

[Table("User1")]
public class Class2
{
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Email { get; set; }
    
    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal Balance { get; set; }
    
    public List<Class1>  Classe1s { get; set; }
    
    public Class3 Class3 { get; set; }
}