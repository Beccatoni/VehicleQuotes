using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Api.Models;

[Index(nameof(Year), nameof(ModelStyleID), IsUnique = true)]
public class ModelStyleYear
{
    public int ID { get; set; }
    public string Year { get; set; }
    public string ModelStyleID { get; set; }
    
    public ModelStyle ModelStyle { get; set; }
}