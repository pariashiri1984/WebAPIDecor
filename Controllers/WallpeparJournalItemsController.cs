using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
    public class WallpeparJournalItemsController : ControllerBase
    {
        private readonly decorContext _context;

        public WallpeparJournalItemsController(decorContext context)
        {
            _context = context;
        }

        // GET: api/WallpeparJournalItems

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WallpeparJournalItem>>> GetWallpeparJournalItem()
        {
            return await _context.WallpeparJournalItem.ToListAsync();
        }

        [HttpGet]
        public IEnumerable GetAllWallpeparJournalItemWithCategoryTitle()
        {
            List<WallpeparJournalItem> _WallpeparJournalItem =  _context.WallpeparJournalItem.ToList();
            List<WallpaperJournal> _WallpaperJournal =  _context.WallpaperJournal.ToList();

            var q = from wji in _WallpeparJournalItem
                    join wi in _WallpaperJournal
                    on wji.WallpaperJournalId equals wi.Id
                    select new
                    {
                       id = wji.Id, journalTitle = wi.Title, imgURL = wji.ImgUrl
                    };

            /*return Ok(new
            {
                value = q
            });*/

            return q;
            // ObjectSet<SalesOrderDetail> details = context.SalesOrderDetails;
        }





        [HttpGet("{id}")]
        //api/WallpeparJournalItems/getAllByJournalId/id
        public async Task<ActionResult<IEnumerable<WallpeparJournalItem>>> getAllByJournalId(string id)
        {
            // System.Console.Write(id);
            int i = Int32.Parse(id);
            return await _context.WallpeparJournalItem
                 .Where(p => p.WallpaperJournalId == i).ToListAsync();
              
        }


        [HttpGet("{id}")]
        //api/WallpeparJournalItems/GetCountOf/1
        public ActionResult GetCountOf(string id)
        {
            // System.Console.Write(id);
            int i = Int32.Parse(id);
           int n =  _context.WallpeparJournalItem
                .Where(p => p.WallpaperJournalId == i)
                .Count();

            return Ok(new
            {
                value = n
            });


        }

        

        // GET: api/WallpeparJournalItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WallpeparJournalItem>> GetWallpeparJournalItem(int id)
        {
            var wallpeparJournalItem = await _context.WallpeparJournalItem.FindAsync(id);

            if (wallpeparJournalItem == null)
            {
                return NotFound();
            }

            return wallpeparJournalItem;
        }

        // PUT: api/WallpeparJournalItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallpeparJournalItem(int id, WallpeparJournalItem wallpeparJournalItem)
        {
            if (id != wallpeparJournalItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(wallpeparJournalItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WallpeparJournalItemExists(id))
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

        // POST: api/WallpeparJournalItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WallpeparJournalItem>> PostWallpeparJournalItem(WallpeparJournalItem wallpeparJournalItem)
        {
            _context.WallpeparJournalItem.Add(wallpeparJournalItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWallpeparJournalItem", new { id = wallpeparJournalItem.Id }, wallpeparJournalItem);
        }

        // DELETE: api/WallpeparJournalItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WallpeparJournalItem>> DeleteWallpeparJournalItem(int id)
        {
            var wallpeparJournalItem = await _context.WallpeparJournalItem.FindAsync(id);
            if (wallpeparJournalItem == null)
            {
                return NotFound();
            }

            _context.WallpeparJournalItem.Remove(wallpeparJournalItem);
            await _context.SaveChangesAsync();

            return wallpeparJournalItem;
        }

        private bool WallpeparJournalItemExists(int id)
        {
            return _context.WallpeparJournalItem.Any(e => e.Id == id);
        }
    }
}
