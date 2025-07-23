using System.ComponentModel.DataAnnotations;

namespace VehicleQuotes.Api.ResourceModels;

public class ModelSpecification
{
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }    
    [Required]
    public ModelSpecificationStyle[] Styles { get; set; }
}