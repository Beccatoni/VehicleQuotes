using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Api.Models;

[Index(nameof(ModelStyleYearID), IsUnique = true)]
public class QuoteOverride
{
    public int ID { get; set; }
    public string ModelStyleYearID { get; set; }
    public decimal Price { get; set; }
    
    public ModelStyleYear ModelStyleYear { get; set; }
}