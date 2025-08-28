using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Api.Data;
using VehicleQuotes.Api.Models;

namespace VehicleQuotes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly VehicleQuotesContext _context;

        public SizesController(VehicleQuotesContext context)
        {
            _context = context;
        }

        // GET: api/Sizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Size>>> GetSizes()
        {
            return await _context.Sizes.ToListAsync();
        }
        
    }
}
