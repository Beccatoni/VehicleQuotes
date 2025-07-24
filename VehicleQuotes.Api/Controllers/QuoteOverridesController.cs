using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Api.Data;
using VehicleQuotes.Api.ResourceModels;

namespace VehicleQuotes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuoteOverridesController: ControllerBase
{
    private readonly VehicleQuotesContext _context;

    public QuoteOverridesController(VehicleQuotesContext context)
    {
        _context = context;
    }
    
    //GET: api/QuoteOverrides
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuoteOverrideSpecification>>> GetQuoteOverides()
    {
        var quoteOverridersToReturn = _context.QuoteOverrides.Select(qo => new QuoteOverrideSpecification()
        {
            ID = qo.ID,
            Year = qo.ModelStyleYear.Year,
            Make = qo.ModelStyleYear.ModelStyle.Model.Name,
            BodyType = qo.ModelStyleYear.ModelStyle.BodyType.Name,
            Size = qo.ModelStyleYear.ModelStyle.Size.Name,
            Price = qo.Price
        });

        return await quoteOverridersToReturn.ToListAsync();
    }
    
    // GET: api/QuoteOverride/5
    [HttpGet("{id}")]
    public async Task<ActionResult<QuoteOverrideSpecification>> GetQuoteOverride(int id)
    {
        var quoteOverride = await _context.QuoteOverrides
            .Include(qo => qo.ModelStyleYear.ModelStyle.Model.Make)
            .Include(qo => qo.ModelStyleYear.ModelStyle.BodyType)
            .Include(qo => qo.ModelStyleYear.ModelStyle.Size)
            .FirstOrDefaultAsync(qo => qo.ID == id);

        if (quoteOverride == null) return NotFound();

        return new QuoteOverrideSpecification
        {
            ID = quoteOverride.ID,
            Year = quoteOverride.ModelStyleYear.Year,
            Make = quoteOverride.ModelStyleYear.ModelStyle.Model.Make.Name,
            BodyType = quoteOverride.ModelStyleYear.ModelStyle.BodyType.Name,
            Size = quoteOverride.ModelStyleYear.ModelStyle.Size.Name,
            Price = quoteOverride.Price
        };
    }
    
    // PUT:  api/QuoteOverrides/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuoteOverride(int id, QuoteOverrideSpecification quoteOverride)
    {
        if(id != quoteOverride.ID) return BadRequest();
        
        var quoteOverrideToUpdate = await _context.QuoteOverrides.FirstOrDefaultAsync(qo => qo.ID == id);

        if (quoteOverrideToUpdate == null) return NotFound();

        var modelStyleYearToOverride = await _context.ModelStyleYears.FirstOrDefaultAsync(msy => 
            msy.Year == quoteOverride.Year &&
            msy.ModelStyle.Model.Make.Name == quoteOverride.Make && 
            msy.ModelStyle.Model.Name == quoteOverride.Model &&
            msy.ModelStyle.BodyType.Name == quoteOverride.BodyType &&
            msy.ModelStyle.Size.Name == quoteOverride.Size

        );

        if (modelStyleYearToOverride == null)
        {
            return UnprocessableEntity("The specified vehicle model to override is not registered.");
        }
        quoteOverrideToUpdate.Price = quoteOverride.Price;
        quoteOverrideToUpdate.ModelStyleYear = modelStyleYearToOverride;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return Conflict();
        }

        return NoContent();
    }
    
    // POST: api/QuoteOverrider
    
    
}