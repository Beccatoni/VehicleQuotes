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
        public async Task<ActionResult<ModelSpecification>> GetModel([FromRoute]int makeId, int id)
        {
            var model = await _context.Models
                .Include(m => m.ModelStyles).ThenInclude(ms => ms.BodyType)
                .Include(m => m.ModelStyles).ThenInclude(ms => ms.Size)
                .Include(m => m.ModelStyles).ThenInclude(ms => ms.ModelStyleYears)
                .FirstOrDefaultAsync(m => m.MakeID == makeId && m.ID == id);

            if (model == null)
            {
                return NotFound();
            }

            return new ModelSpecification()
            {
                ID = model.ID,
                Name = model.Name,
                Styles = model.ModelStyles.Select(ms => new ModelSpecificationStyle
                {
                    BodyType = ms.BodyType.Name,
                    Size = ms.Size.Name,
                    Years = ms.ModelStyleYears.Select(msy => msy.Year).ToArray()
                }).ToArray()
            } ;
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel([FromRoute] int makeId, int id, ModelSpecification model)
        {
            if (id != model.ID) return BadRequest();
            
            
            // Get the 'models' record that we want to update. Include any related
            // data that we want to update as well.
            var modelToUpdate = await _context.Models
                .Include(m => m.ModelStyles)
                .FirstOrDefaultAsync(m => m.MakeID == makeId && m.ID == id);

            _context.Entry(model).State = EntityState.Modified;

            if (modelToUpdate == null) return NotFound();
            //Update the record with what came in the request payload.
            modelToUpdate.Name = model.Name;
            
            //Build EF Core entities based on the incoming Resource Model object.
            modelToUpdate.ModelStyles = model.Styles.Select(style => new ModelStyle
            {
                BodyType = _context.BodyTypes.Single(bodyType => bodyType.Name == style.BodyType),
                Size = _context.Sizes.Single(size => size.Name == style.Size),
                ModelStyleYears = style.Years.Select(year => new ModelStyleYear
                {
                    Year = year
                }).ToList()
            }).ToList();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // If there is an error updating, respond accordingly.
                return Conflict();
            }
            
            // Finally, return a 204 if everything went well.
            return NoContent();
        }

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelSpecification>> PostModel([FromRoute]int makeId, ModelSpecification model)
        {
            var make = await _context.Makes.FindAsync(makeId);

            if (make == null) return NotFound();

            var modelToCreate = new Model
            {
                Make = make,
                Name = model.Name,
                ModelStyles = model.Styles.Select(style => new ModelStyle
                {
                    //Notice how we search both body type and size by their name field.
                    // We can do that because their names are unique.
                    BodyType = _context.BodyTypes.Single(bodyType => bodyType.Name == style.BodyType),
                    Size = _context.Sizes.Single(size => size.Name == style.Size),
                    ModelStyleYears = style.Years.Select(year => new ModelStyleYear
                    {
                        Year = year
                    }).ToArray()
                }).ToArray()
            };

            _context.Add(modelToCreate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            model.ID = modelToCreate.ID;
            
            return CreatedAtAction(
                nameof(GetModel), 
                new { makeId = makeId, id = model.ID }, 
                model
                );
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        //Expect 'makeId' and 'id' from the URL.
        public async Task<IActionResult> DeleteModel([FromRoute]int makeId, int id)
        {
            // Try to find the record identified by the ids from the URL.
            var model = await _context.Models
                .FirstOrDefaultAsync(m => m.MakeID == makeId && m.ID == id);
            
            //Respond with a 404 if we can't find it.
            if (model == null) return NotFound();
            

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
