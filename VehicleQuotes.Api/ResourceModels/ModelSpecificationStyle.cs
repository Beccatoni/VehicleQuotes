using System.ComponentModel.DataAnnotations;
using VehicleQuotes.Api.Validation;

namespace VehicleQuotes.Api.ResourceModels;

public class ModelSpecificationStyle
{
    [Required]
    [VehicleBodyType]
    public string BodyType { get; set; }
    [Required]
    [VehicleSize]
    public string Size { get; set; }   
    [Required]
    [MinLength(1)]
    [ContainsYears]
    public string[] Years { get; set; }
}