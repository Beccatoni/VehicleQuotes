using VehicleQuotes.Api.Data;
using VehicleQuotes.Api.Models;
using VehicleQuotes.Api.Services;
using VehicleQuotes.Tests.Fixtures;
using Xunit;

namespace VehicleQuotes.Tests.Service;

public class QuoteServiceTests: IClassFixture<DatabaseFixture>, IDisposable
{
    private VehicleQuotesContext dbContext;

    public QuoteServiceTests(DatabaseFixture fixture)
    {
        dbContext = fixture.Dbcontext;

        dbContext.Database.BeginTransaction();
    }

    public void Dispose()
    {
        dbContext.Database.RollbackTransaction();
    }

    // to run detailed tests:  ______dotnet test --logger "console;verbosity=detailed"______
    [Fact]
    public async void GetAllQuotesReturnsAsyncEmptywhenThereIsNoDataStored()
    {
        // Given
        var service = new QuoteService(dbContext, null);
        // When
        var result = await service.GetAllQuotes();
        // Then
        Assert.Empty(result);
    }

    [Fact]
    public async void GetAllQuotesReturnsAsyncTheStoredData()
    {
        // Given
        var quote = new Quote
        {
           OfferedQuote = 100,
           Message = "test_quote_message",
           
           Year = "2000",
           Make = "Toyota",
           Model = "Corolla",
           BodyTypeID = dbContext.BodyTypes.Single(bt => bt.Name == "Sedan").ID,
           SizeID = dbContext.Sizes.Single(s => s.Name == "Compact").ID,
           
           ItMoves = true,
           HasAllWheels = true,
           HasAlloyWheels = true,
           HasAllTires = true,
           HasKey = true,
           HasTitle = true,
           RequiresPickup = true,
           HasEngine = true,
           HasTransmission = true,
           HasCompleteInterior = true,
           
           CreatedAt = DateTime.UtcNow
        };


        dbContext.Quotes.Add(quote);

        await dbContext.SaveChangesAsync();

        var service = new QuoteService(dbContext, null);
        
        // When
        var result = await service.GetAllQuotes();
        
        // Then
        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Equal(quote.ID, result.First().ID);
        Assert.Equal(quote.OfferedQuote, result.First().OfferedQuote);
        Assert.Equal(quote.Message, result.First().Message);

    }
    
    

}