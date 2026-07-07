using System.ComponentModel.DataAnnotations;

namespace Business;

public class Products
{
   public int Id { get; set; } 
   public string Name { get; set; }
   public double Number { get; set; }
   
   [Required, MaxLength(20)]
   public string Description { get; set; }
   
   public List<Order> Orders { get; set; }
}