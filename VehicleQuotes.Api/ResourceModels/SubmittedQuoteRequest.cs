

namespace VehicleQuotes.Api.ResourceModels;

public class SubmittedQuoteRequest: QuoteRequest
{
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal OfferedQuote { get; set; }
    public string Message { get; internal set; }
}