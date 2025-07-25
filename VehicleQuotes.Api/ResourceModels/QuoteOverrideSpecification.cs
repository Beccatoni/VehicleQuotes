using System.ComponentModel.DataAnnotations;

namespace VehicleQuotes.Api.ResourceModels;

public class QuoteOverrideSpecification
{
    public int ID { get; set; }
    
    [Required]
    public string Year { get; set; }
    
    [Required]
    public string Make { get; set; }
    
    [Required]
    public string Model { get; set; }
    
    [Required]
    public string BodyType { get; set; }
    
    [Required]
    public string Size { get; set; }
    
    [Required]
    public decimal Price { get; set; }
}