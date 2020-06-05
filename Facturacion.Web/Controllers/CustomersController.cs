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
    public class CustomersController : Controller
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Customers.Include(c => c.Country).Include(c => c.CustomerType).Include(c => c.DocumentType);
            return View(await dataContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Country)
                .Include(c => c.CustomerType)
                .Include(c => c.DocumentType)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName");
            ViewData["CTypeId"] = new SelectList(_context.CustomerTypes, "CTypeId", "TypeCustomer");
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "TypeDocument");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,LastName,DocumentTypeId,Document,Number,Email,CTypeId,CountryId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", customer.CountryId);
            ViewData["CTypeId"] = new SelectList(_context.CustomerTypes, "CTypeId", "TypeCustomer", customer.CTypeId);
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "TypeDocument", customer.DocumentTypeId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", customer.CountryId);
            ViewData["CTypeId"] = new SelectList(_context.CustomerTypes, "CTypeId", "TypeCustomer", customer.CTypeId);
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "TypeDocument", customer.DocumentTypeId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,LastName,DocumentTypeId,Document,Number,Email,CTypeId,CountryId")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", customer.CountryId);
            ViewData["CTypeId"] = new SelectList(_context.CustomerTypes, "CTypeId", "TypeCustomer", customer.CTypeId);
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "TypeDocument", customer.DocumentTypeId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Country)
                .Include(c => c.CustomerType)
                .Include(c => c.DocumentType)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
