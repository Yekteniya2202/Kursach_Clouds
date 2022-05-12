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

        // GET: Todos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Length,Square,Ocean,CountryFile")] River river)
        {
            if (ModelState.IsValid)
            {
                using (var target = new MemoryStream())
                {
                    river.CountryFile.CopyTo(target);
                    river.Country = target.ToArray();
                }
                _context.Add(river);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(river);
        }

        // GET: Todos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var river = await _context.River.FindAsync(id);
            if (river == null)
            {
                return NotFound();
            }
            return View(river);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Length,Square,Ocean,CountryFile")] River river)
        {
            if (id != river.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var target = new MemoryStream())
                    {

                        river.CountryFile.CopyTo(target);
                        river.Country = target.ToArray();
                    }
                    _context.Update(river);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(river.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(river);
        }

        // GET: Todos/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var river = await _context.River.FindAsync(id);
            _context.River.Remove(river);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(int id)
        {
            return _context.River.Any(e => e.ID == id);
        }
    }
}
