using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Facturacion.Web.Data;
using Facturacion.Web.Models;
using Facturacion.Web.ViewModels;
using Rotativa.AspNetCore;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.X509;
using Facturacion.Web.Migrations;
using System.Runtime.Serialization;

namespace Facturacion.Web.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private readonly DataContext _context;

        public PurchaseOrdersController(DataContext context)
        
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.PurchaseOrder.Include(o => o.Chair).Include(o => o.Customer).Include(o => o.Payment).Include(o => o.Shipping);
            return View(await dataContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.PurchaseOrder
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Shipping)
                .Include(o => o.Chair)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (orden == null)
            {
                return NotFound();
            }

            var purchaseview = new PurchaseOrderView();
            var purchasedetail = new PurchaseDetail();

            purchaseview.PurchaseOrder = await _context.PurchaseOrder
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Shipping)
                .Include(o => o.Chair)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);

            var datapurchase = _context.PurchaseDetail.Include(od => od.PurchaseOrder).Include(od => od.Item).Where(od => od.PurchaseId.Equals(id)).ToList();
            purchaseview.PurchaseDetails = datapurchase;

            ViewData["PurchaseId"] = new SelectList(_context.PurchaseOrder, "PurchaseId", "PurchaseId", purchasedetail.PurchaseId);
            ViewData["PaymentId"] = new SelectList(_context.PurchaseOrder, "PaymentId", "Pway", purchasedetail.PurchaseId);
            ViewData["ChairID"] = new SelectList(_context.PurchaseOrder, "ChairID", "ChairName", purchasedetail.PurchaseId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", purchasedetail.ItemId);

            return View(purchaseview);


        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Pway");
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippWay");
            ViewData["ChairID"] = new SelectList(_context.Chairs, "ChairID", "ChairName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseId,CustomerId,PaymentId,ShippingId,ChairID,OrderTime,comentario,SubTotal,Valueimp")] PurchaseOrder orden)
        {
   
                if (ModelState.IsValid)
                {
                    _context.Add(orden);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", orden.CustomerId);
                ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Pway", orden.PaymentId);
                ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippWay", orden.ShippingId);
                ViewData["ChairID"] = new SelectList(_context.Chairs, "ChairID", "ChairName", orden.ChairID);
                return View(orden);

            
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.PurchaseOrder.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", orden.CustomerId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Pway", orden.PaymentId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippWay", orden.ShippingId);
            ViewData["ChairID"] = new SelectList(_context.Chairs, "ChairID", "ChairName", orden.ChairID);
            return View(orden);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseId,CustomerId,PaymentId,ShippingId,ChairID,OrderTime,comentario,SubTotal,Valueimp")] PurchaseOrder orden)
        {
            if (id != orden.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(orden.PurchaseId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", orden.CustomerId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Pway", orden.PaymentId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippWay", orden.ShippingId);
            ViewData["ChairID"] = new SelectList(_context.Chairs, "ChairID", "ChairName", orden.ChairID);
            return View(orden);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.PurchaseOrder
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Shipping)
                .Include(o => o.Chair)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);

        }

        //POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orden = await _context.PurchaseOrder.FindAsync(id);
            _context.PurchaseOrder.Remove(orden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.PurchaseOrder.Any(e => e.PurchaseId == id);
        }

        public async Task<IActionResult> AdicionarProducto([Bind("PurchaseDetailId,ItemId,Quantity,UnitPrice,TotalValue,PurchaseId")] PurchaseDetail purchasedetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchasedetail);

                int id = purchasedetail.PurchaseId;
                int id_producto = purchasedetail.ItemId;

                Models.Item item = _context.Items.Find(id_producto);
                decimal price = item.UnitPrice;

                if (item.UnitsInStock < purchasedetail.Quantity)
                {
                    TempData["Mensaje"] = "La cantidad de productos que intenta facturar excede lo almacenado actualmente, favor verifique inventario y vuelva intentarlo.";
                    //return Content("La cantidad que intenta facturar excede lo almacenado actualmente, favor intente nuevamente");
                    return RedirectToAction("Details", new { id = id });

                } 

                else
                {
                    item.UnitsInStock -= Convert.ToInt32(purchasedetail.Quantity);
                    _context.Update(item);
                    _context.SaveChanges();

                    decimal quantity = Convert.ToDecimal(purchasedetail.Quantity);
                    decimal pricet = quantity * Convert.ToDecimal(price);
                    decimal tax;

                    purchasedetail.UnitPrice = Convert.ToInt32(price);
                    purchasedetail.TotalValue = pricet;

                    await _context.SaveChangesAsync();

                    PurchaseOrder orden = _context.PurchaseOrder.Find(id);
                    orden.SubTotal += pricet;
                    orden.Valueimp = Convert.ToDecimal(0.18);
                    decimal pricetax = orden.Valueimp;
                    tax = pricet * pricetax;
                    orden.Valueimp = tax;
                    pricet = pricet + tax;
                    orden.TotalValue += pricet;
                    _context.Update(orden);
                    _context.SaveChanges();

                    return RedirectToAction("Details", new { id = id });
                }


            }

            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Comment", purchasedetail.ItemId);
            ViewData["PurchaseId"] = new SelectList(_context.PurchaseOrder, "PurchaseId", "PurchaseId", purchasedetail.PurchaseId);
            return View(purchasedetail);

        }

        public async Task<IActionResult> PrintPDF(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.PurchaseOrder
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Shipping)
                .Include(o => o.Chair)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);

            if (orden == null)
            {
                return NotFound();
            }

            var purchaseview = new PurchaseOrderView();
            var purchasedetail = new PurchaseDetail();

            purchaseview.PurchaseOrder = await _context.PurchaseOrder
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Shipping)
                .Include(o => o.Chair)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);

            var dataorder = _context.PurchaseDetail.Include(od => od.PurchaseOrder).Include(od => od.Item).Where(od => od.PurchaseId.Equals(id)).ToList();
            purchaseview.PurchaseDetails = dataorder;

            ViewData["PurchaseId"] = new SelectList(_context.PurchaseOrder, "PurchaseId", "PurchaseId", purchasedetail.PurchaseId);
            ViewData["PaymentId"] = new SelectList(_context.PurchaseOrder, "PaymentId", "Pway", purchasedetail.PurchaseId);
            ViewData["ChairID"] = new SelectList(_context.PurchaseOrder, "ChairID", "ChairName", purchasedetail.PurchaseId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", purchasedetail.ItemId);

            return View(purchaseview);

        }

    }

}