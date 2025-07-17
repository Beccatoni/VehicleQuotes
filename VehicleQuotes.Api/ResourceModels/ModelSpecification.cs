namespace VehicleQuotes.Api.ResourceModels;

public class ModelSpecification
{
    public string BodyType { get; set; }
    public string Size { get; set; }    
    
    public ModelSpecificationStyle[] Styles { get; set; }
}