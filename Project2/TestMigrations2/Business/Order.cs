using System;
using System.Collections.Generic;
using System.Text;

namespace Business;

public class Order
{
    public int ID { get; set; }
    public decimal Price { get; set; }
    public DateOnly ShippingDate { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public List<Products>  Products { get; set; }
}