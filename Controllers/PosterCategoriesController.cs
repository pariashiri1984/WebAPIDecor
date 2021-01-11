using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDecor.Models;

namespace WebAPIDecor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosterCategoriesController : ControllerBase
    {
        private readonly decorContext _context;

        public PosterCategoriesController(decorContext context)
        {
            _context = context;
        }

        // GET: api/PosterCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosterCategory>>> GetPosterCategory()
        {
            return await _context.PosterCategory.ToListAsync();
        }

        // GET: api/PosterCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosterCategory>> GetPosterCategory(int id)
        {
            var posterCategory = await _context.PosterCategory.FindAsync(id);

            if (posterCategory == null)
            {
                return NotFound();
            }

            return posterCategory;
        }

        // PUT: api/PosterCategories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosterCategory(int id, PosterCategory posterCategory)
        {
            if (id != posterCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(posterCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosterCategoryExists(id))
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

        // POST: api/PosterCategories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PosterCategory>> PostPosterCategory(PosterCategory posterCategory)
        {
            _context.PosterCategory.Add(posterCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosterCategory", new { id = posterCategory.Id }, posterCategory);
        }

        // DELETE: api/PosterCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosterCategory>> DeletePosterCategory(int id)
        {
            var posterCategory = await _context.PosterCategory.FindAsync(id);
            if (posterCategory == null)
            {
                return NotFound();
            }

            _context.PosterCategory.Remove(posterCategory);
            await _context.SaveChangesAsync();

            return posterCategory;
        }

        private bool PosterCategoryExists(int id)
        {
            return _context.PosterCategory.Any(e => e.Id == id);
        }
    }
}
