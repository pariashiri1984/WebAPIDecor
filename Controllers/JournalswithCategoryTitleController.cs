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
    public class JournalswithCategoryTitleController : ControllerBase

    {
        private readonly decorContext _context;

        public JournalswithCategoryTitleController(decorContext context)
        {
            _context = context;
        }

        // GET: api/JournalswithCategoryTitle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalswithCategoryTitle>>> GetWallpaperJournal()
        {
            return await _context.JournalswithCategoryTitles.ToListAsync();
        }


    }
}
