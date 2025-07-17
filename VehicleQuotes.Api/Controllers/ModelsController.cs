using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Api.Data;
using VehicleQuotes.Api.Models;
using VehicleQuotes.Api.ResourceModels;

namespace VehicleQuotes.Api.Controllers
{
    [Route("api/Makes/{makeId}/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly VehicleQuotesContext _context;

        public ModelsController(VehicleQuotesContext context)
        {
            _context = context;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelSpecification>>> GetModels([FromRoute] int makeId)
        {
            // Look for the make identified by 'makeId'
            var make = await _context.Makes.FindAsync(makeId);

            //If we can't find the make, we return a 404
            if (make == null) return NotFound();

            //Build a query to fetch the relevant records from the
            //'models' table and build 'ModelSpecification' with the data.
            var modelsToReturn = _context.Models
                .Where(m => m.MakeID == makeId)
                .Select(m => new ModelSpecification
                {
                    ID = m.ID,
                    Name = m.Name,
                    Styles = m.ModelStyles.Select(ms => new ModelSpecificationStyle
                    {
                        BodyType = ms.BodyType.Name,
                        Size = ms.Size.Name,
                        Years = ms.ModelStyleYears.Select(msy => msy.Year).ToArray()
                    }).ToArray()
                });
            return await modelsToReturn.ToListAsync();
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model>> GetModel([FromRoute]int makeId, int id)
        {
            var model = await _context.Models.FirstOrDefaultAsync(m => m.MakeID == makeId && m.ID == id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(Model model)
        {
            _context.Models.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModel", new { id = model.ID }, model);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelExists(int id)
        {
            return _context.Models.Any(e => e.ID == id);
        }
    }
}
