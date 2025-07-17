using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Api.Models;

[Index(nameof(ModelID), nameof(BodyTypeID), nameof(SizeID), IsUnique = true)]
public class ModelStyle
{
    public int ID { get; set; }
    public string ModelID { get; set; }
    public string BodyTypeID { get; set; }
    public string SizeID { get; set; }
    
    public Model Model { get; set; }
    public BodyType BodyType { get; set; }
    public Size Size { get; set; }
    
    public ICollection<ModelStyleYear> ModelStyleYears { get; set; }
}