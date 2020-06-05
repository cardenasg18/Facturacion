using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Facturacion.Web.Data;
using Facturacion.Web.Models;

namespace Facturacion.Web.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private readonly DataContext _context;

        public NeighborhoodsController(DataContext context)
        {
            _context = context;
        }

        // GET: Neighborhoods
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Neighborhoods.Include(n => n.City);
            return View(await dataContext.ToListAsync());
        }

        // GET: Neighborhoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods
                .Include(n => n.City)
                .FirstOrDefaultAsync(m => m.NeighborhoodId == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // GET: Neighborhoods/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            return View();
        }

        // POST: Neighborhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NeighborhoodId,NeighborhoodName,CityId")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neighborhood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", neighborhood.CityId);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", neighborhood.CityId);
            return View(neighborhood);
        }

        // POST: Neighborhoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NeighborhoodId,NeighborhoodName,CityId")] Neighborhood neighborhood)
        {
            if (id != neighborhood.NeighborhoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neighborhood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeighborhoodExists(neighborhood.NeighborhoodId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", neighborhood.CityId);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods
                .Include(n => n.City)
                .FirstOrDefaultAsync(m => m.NeighborhoodId == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // POST: Neighborhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            _context.Neighborhoods.Remove(neighborhood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeighborhoodExists(int id)
        {
            return _context.Neighborhoods.Any(e => e.NeighborhoodId == id);
        }
    }
}
