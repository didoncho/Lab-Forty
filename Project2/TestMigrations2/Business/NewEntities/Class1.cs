using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.NewEntities;

[Table("Product1")]
public class Class1
{
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }
    
    public List<Class2>  Classe2s { get; set; }
}