using System.ComponentModel.DataAnnotations;
using VehicleQuotes.Api.Data;

namespace VehicleQuotes.Api.Validation;

public class VehicleSizeAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if(value == null) return ValidationResult.Success;

        var dbContext = validationContext.GetService(typeof(VehicleQuotesContext)) as VehicleQuotesContext;
        var sizes = dbContext.Sizes.Select(s => s.Name).ToList();

        if (!sizes.Contains(value))
        {
            var allowed = String.Join(", ", sizes);
            return new ValidationResult(
                $"Invalid vehicle size {value}. Allowed values are {allowed}.");
        }
        return ValidationResult.Success;
    }
}