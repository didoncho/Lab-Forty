using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Business.NewEntities;

[Table("UserInfo1")]
public class Class3
{
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Address { get; set; }
    
    [Required, Precision(18, 2)]
    public decimal d1 { get; set; }
    
    [Required, Column(TypeName = "decimal(18, 2)")]
    public decimal d2 { get; set; }
    
    [Required, Column(TypeName = "decimal(18, 2)"), NotMapped]
    public decimal d3 => d1 * d2;
    
    public int Class2Id { get; set; }
    
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Class2 Class2 { get; set; }
}