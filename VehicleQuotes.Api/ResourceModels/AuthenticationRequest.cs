using System.ComponentModel.DataAnnotations;

namespace VehicleQuotes.Api.ResourceModels;

public class AuthenticationRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }   
}