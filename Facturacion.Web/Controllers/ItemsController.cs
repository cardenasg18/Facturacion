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
    public class ItemsController : Controller
    {
        private readonly DataContext _context;

        public ItemsController(DataContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Items.Include(i => i.Brand).Include(i => i.Clasification).Include(i => i.Currency).Include(i => i.Status).Include(i => i.Supplier).Include(i => i.Unit);
            return View(await dataContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Brand)
                .Include(i => i.Clasification)
                .Include(i => i.Currency)
                .Include(i => i.Status)
                .Include(i => i.Supplier)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            ViewData["ClasificationId"] = new SelectList(_context.Clasifications, "ClasificationId", "ItemType");
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "CurrencyId", "CurrencyName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusOf");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName");
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,UnitsInStock,Comment,UnitPrice,ClasificationId,BrandId,CurrencyId,UnitId,StatusId,SupplierId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", item.BrandId);
            ViewData["ClasificationId"] = new SelectList(_context.Clasifications, "ClasificationId", "ItemType", item.ClasificationId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "CurrencyId", "CurrencyName", item.CurrencyId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusOf", item.StatusId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", item.SupplierId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", item.UnitId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", item.BrandId);
            ViewData["ClasificationId"] = new SelectList(_context.Clasifications, "ClasificationId", "ItemType", item.ClasificationId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "CurrencyId", "CurrencyName", item.CurrencyId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusOf", item.StatusId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", item.SupplierId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", item.UnitId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,UnitsInStock,Comment,UnitPrice,ClasificationId,BrandId,CurrencyId,UnitId,StatusId,SupplierId")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", item.BrandId);
            ViewData["ClasificationId"] = new SelectList(_context.Clasifications, "ClasificationId", "ItemType", item.ClasificationId);
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "CurrencyId", "CurrencyName", item.CurrencyId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusOf", item.StatusId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", item.SupplierId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", item.UnitId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Brand)
                .Include(i => i.Clasification)
                .Include(i => i.Currency)
                .Include(i => i.Status)
                .Include(i => i.Supplier)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
