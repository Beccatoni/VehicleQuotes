using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Api.Models;


[Index(nameof(Name), IsUnique = true)]
public class Size
{
    public int ID { get; set; }
    public string Name { get; set; } 
}