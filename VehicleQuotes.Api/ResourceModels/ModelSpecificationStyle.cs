using System.ComponentModel.DataAnnotations;

namespace VehicleQuotes.Api.ResourceModels;

public class ModelSpecificationStyle
{
    [Required]
    public string BodyType { get; set; }
    [Required]
    public string Size { get; set; }   
    [Required]
    [MinLength(1)]
    public string[] Years { get; set; }
}