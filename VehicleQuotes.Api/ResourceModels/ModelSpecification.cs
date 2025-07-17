namespace VehicleQuotes.Api.ResourceModels;

public class ModelSpecification
{
    public int ID { get; set; }
    public string Name { get; set; }    
    
    public ModelSpecificationStyle[] Styles { get; set; }
}