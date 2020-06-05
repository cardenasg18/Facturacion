﻿using System;
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
    public class SupplierTypesController : Controller
    {
        private readonly DataContext _context;

        public SupplierTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: SupplierTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupplierTypes.ToListAsync());
        }

        // GET: SupplierTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierTypes
                .FirstOrDefaultAsync(m => m.SupplierTypeId == id);
            if (supplierType == null)
            {
                return NotFound();
            }

            return View(supplierType);
        }

        // GET: SupplierTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierTypeId,Type")] SupplierType supplierType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierType);
        }

        // GET: SupplierTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierTypes.FindAsync(id);
            if (supplierType == null)
            {
                return NotFound();
            }
            return View(supplierType);
        }

        // POST: SupplierTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierTypeId,Type")] SupplierType supplierType)
        {
            if (id != supplierType.SupplierTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierTypeExists(supplierType.SupplierTypeId))
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
            return View(supplierType);
        }

        // GET: SupplierTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierTypes
                .FirstOrDefaultAsync(m => m.SupplierTypeId == id);
            if (supplierType == null)
            {
                return NotFound();
            }

            return View(supplierType);
        }

        // POST: SupplierTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierType = await _context.SupplierTypes.FindAsync(id);
            _context.SupplierTypes.Remove(supplierType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierTypeExists(int id)
        {
            return _context.SupplierTypes.Any(e => e.SupplierTypeId == id);
        }
    }
}
