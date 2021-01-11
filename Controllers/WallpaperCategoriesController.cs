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
    public class WallpaperCategoriesController : ControllerBase
    {
        private readonly decorContext _context;

        public WallpaperCategoriesController(decorContext context)
        {
            _context = context;
        }

        // GET: api/WallpaperCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WallpaperCategory>>> GetWallpaperCategory()
        {
            return await _context.WallpaperCategory.ToListAsync();
        }

        // GET: api/WallpaperCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WallpaperCategory>> GetWallpaperCategory(int id)
        {
            var wallpaperCategory = await _context.WallpaperCategory.FindAsync(id);

            if (wallpaperCategory == null)
            {
                return NotFound();
            }

            return wallpaperCategory;
        }

        // PUT: api/WallpaperCategories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallpaperCategory(int id, WallpaperCategory wallpaperCategory)
        {
            if (id != wallpaperCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(wallpaperCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WallpaperCategoryExists(id))
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

        // POST: api/WallpaperCategories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WallpaperCategory>> PostWallpaperCategory(WallpaperCategory wallpaperCategory)
        {
            _context.WallpaperCategory.Add(wallpaperCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWallpaperCategory", new { id = wallpaperCategory.Id }, wallpaperCategory);
        }

        // DELETE: api/WallpaperCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WallpaperCategory>> DeleteWallpaperCategory(int id)
        {
            var wallpaperCategory = await _context.WallpaperCategory.FindAsync(id);
            if (wallpaperCategory == null)
            {
                return NotFound();
            }

            _context.WallpaperCategory.Remove(wallpaperCategory);
            await _context.SaveChangesAsync();

            return wallpaperCategory;
        }

        private bool WallpaperCategoryExists(int id)
        {
            return _context.WallpaperCategory.Any(e => e.Id == id);
        }
    }
}
