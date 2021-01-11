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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostersController : ControllerBase
    {
        private readonly decorContext _context;

        public PostersController(decorContext context)
        {
            _context = context;
        }

        // GET: api/Posters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poster>>> GetPoster()
        {
            return await _context.Poster.ToListAsync();
        }

        // GET: api/Posters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poster>> GetPoster(int id)
        {
            var poster = await _context.Poster.FindAsync(id);

            if (poster == null)
            {
                return NotFound();
            }

            return poster;
        }
        // GET: api/Posters/GetPosterWithCategoryTitle
        [HttpGet]
        public IActionResult GetPosterWithCategoryTitle()
        {
            var result = from p in _context.Poster
                         join pc in _context.PosterCategory on p.CategoryId equals pc.Id
                         select new
                         {
                             PosterId = p.Id,
                             CategoryId = p.CategoryId,
                             CategoryTitle = pc.Title,
                             ImgUrl = p.ImgUrl
                         };
            return Ok(result);
        }

        // GET: api/GetPosterOfbyCategoryId/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Poster>>> GetPosterOfbyCategoryId(string id)
        {
            int i = Int32.Parse(id);
            var poster = await _context.Poster
                .Where(p => p.CategoryId == i).ToListAsync();

            if (poster == null)
            {
                return NotFound();
            }

            return poster;
        }

        // PUT: api/Posters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoster(int id, Poster poster)
        {
            if (id != poster.Id)
            {
                return BadRequest();
            }

            _context.Entry(poster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosterExists(id))
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

        // POST: api/Posters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Poster>> PostPoster(Poster poster)
        {
            _context.Poster.Add(poster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoster", new { id = poster.Id }, poster);
        }

        // DELETE: api/Posters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poster>> DeletePoster(int id)
        {
            var poster = await _context.Poster.FindAsync(id);
            if (poster == null)
            {
                return NotFound();
            }

            _context.Poster.Remove(poster);
            await _context.SaveChangesAsync();

            return poster;
        }

        private bool PosterExists(int id)
        {
            return _context.Poster.Any(e => e.Id == id);
        }
    }
}
