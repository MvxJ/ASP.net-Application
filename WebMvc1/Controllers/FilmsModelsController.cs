using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMvc1.Data;
using WebMvc1.Models;

namespace WebMvc1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsModelsController : ControllerBase
    {
        private readonly WebMvc1Context _context;

        public FilmsModelsController(WebMvc1Context context)
        {
            _context = context;
        }

        // GET: api/FilmsModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmsModel>>> GetFilmsModel()
        {
            return await _context.FilmsModel.ToListAsync();
        }

        // GET: api/FilmsModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmsModel>> GetFilmsModel(int id)
        {
            var filmsModel = await _context.FilmsModel.FindAsync(id);

            if (filmsModel == null)
            {
                return NotFound();
            }

            return filmsModel;
        }

        // PUT: api/FilmsModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmsModel(int id, FilmsModel filmsModel)
        {
            if (id != filmsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsModelExists(id))
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

        // POST: api/FilmsModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmsModel>> PostFilmsModel(FilmsModel filmsModel)
        {
            _context.FilmsModel.Add(filmsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmsModel", new { id = filmsModel.Id }, filmsModel);
        }

        // DELETE: api/FilmsModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmsModel(int id)
        {
            var filmsModel = await _context.FilmsModel.FindAsync(id);
            if (filmsModel == null)
            {
                return NotFound();
            }

            _context.FilmsModel.Remove(filmsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmsModelExists(int id)
        {
            return _context.FilmsModel.Any(e => e.Id == id);
        }
    }
}
