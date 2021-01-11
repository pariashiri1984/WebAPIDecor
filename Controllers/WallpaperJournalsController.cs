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
    public class WallpaperJournalsController : ControllerBase
    {
        private readonly decorContext _context;

        public WallpaperJournalsController(decorContext context)
        {
            _context = context;
        }

        // GET: api/WallpaperJournals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WallpaperJournal>>> GetWallpaperJournal()
        {
            return await _context.WallpaperJournal.ToListAsync();
        }

       

        // GET: api/WallpaperJournals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WallpaperJournal>> GetWallpaperJournal(int id)
        {
            var wallpaperJournal = await _context.WallpaperJournal.FindAsync(id);

            if (wallpaperJournal == null)
            {
                return NotFound();
            }

            return wallpaperJournal;
        }

        // PUT: api/WallpaperJournals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallpaperJournal(int id, WallpaperJournal wallpaperJournal)
        {
            if (id != wallpaperJournal.Id)
            {
                return BadRequest();
            }

            _context.Entry(wallpaperJournal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WallpaperJournalExists(id))
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

        // POST: api/WallpaperJournals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WallpaperJournal>> PostWallpaperJournal(WallpaperJournal wallpaperJournal)
        {
            _context.WallpaperJournal.Add(wallpaperJournal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWallpaperJournal", new { id = wallpaperJournal.Id }, wallpaperJournal);
        }

        // DELETE: api/WallpaperJournals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WallpaperJournal>> DeleteWallpaperJournal(int id)
        {
            var wallpaperJournal = await _context.WallpaperJournal.FindAsync(id);
            if (wallpaperJournal == null)
            {
                return NotFound();
            }

            _context.WallpaperJournal.Remove(wallpaperJournal);
            await _context.SaveChangesAsync();

            return wallpaperJournal;
        }

        private bool WallpaperJournalExists(int id)
        {
            return _context.WallpaperJournal.Any(e => e.Id == id);
        }
    }
}
