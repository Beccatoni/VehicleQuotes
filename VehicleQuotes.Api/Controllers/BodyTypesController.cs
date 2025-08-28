using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Api.Data;
using VehicleQuotes.Api.Models;

namespace VehicleQuotes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypesController : ControllerBase
    {
        private readonly VehicleQuotesContext _context;

        public BodyTypesController(VehicleQuotesContext context)
        {
            _context = context;
        }

        // GET: api/BodyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyType>>> GetBodyTypes()
        {
            return await _context.BodyTypes.ToListAsync();
        }

        private bool BodyTypeExists(int id)
        {
            return _context.BodyTypes.Any(e => e.ID == id);
        }
    }
}
