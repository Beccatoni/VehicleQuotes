namespace VehicleQuotes.Api.ResourceModels;

public class AuthenticationResponse
{
    public string Token { get; set; }   
    public DateTime ExpiresAt { get; set; }   
}