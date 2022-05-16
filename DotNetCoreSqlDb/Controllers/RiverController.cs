using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DotNetCoreSqlDb.Controllers
{
    public class RiverController : Controller
    {
        private readonly RiverDatabaseContext _context;

        public RiverController(RiverDatabaseContext context)
        {
            _context = context;
        }
        // GET: RiverController
        public async Task<IActionResult> Index()
        {
            var rivers = new List<River>();

            // This allows the home page to load if migrations have not been run yet.
            try
            {
                rivers = await _context.River.ToListAsync();
                
            }
            catch (Exception e)
            {

                return View(rivers);
            }

            return View(rivers);
        }

        // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var river = await _context.River
                .FirstOrDefaultAsync(m => m.ID == id);
            if (river == null)
            {
                return NotFound();
            }

            return View(river);
        }
    }
}
