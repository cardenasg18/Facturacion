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

namespace Facturacion.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Order.Include(o => o.Customer).Include(o => o.Payment).Include(o => o.Shipping);
            return View(await dataContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Shipping)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            var orderview = new OrderView();
            var orderdetail = new OrderDetail();

            orderview.Order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Shipping)
                .FirstOrDefaultAsync(m => m.OrderId == id);

            var dataorder = _context.OrderDetail.Include(od => od.Order).Include(od => od.Item).Where(od => od.OrderId.Equals(id)).ToList();
            orderview.Details = dataorder;

            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", orderdetail.OrderId);
            ViewData["PaymentId"] = new SelectList(_context.Order, "PaymentId", "Pway", orderdetail.OrderId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", orderdetail.ItemId);

            return View(orderview);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Pway");
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippWay");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,PaymentId,ShippingId,OrderTime,comentario,SubTotal,Valueimp")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Pway", order.PaymentId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippWay", order.ShippingId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Pway", order.PaymentId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippWay", order.ShippingId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,PaymentId,ShippingId,OrderTime,comentario,SubTotal,Valueimp")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Pway", order.PaymentId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "ShippingId", "ShippWay", order.ShippingId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Shipping)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);

        }

        //POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }

        public async Task<IActionResult> AdicionarProducto([Bind("DetailId,ItemId,Quantity,UnitPrice,TotalValue,OrderId")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);

                int id = orderDetail.OrderId;
                int id_producto = orderDetail.ItemId;

                Models.Item item = _context.Items.Find(id_producto);
                decimal precio = item.UnitPrice;

                decimal cantidad = Convert.ToDecimal(orderDetail.Quantity);
                decimal preciot = cantidad * Convert.ToDecimal(precio);
                decimal impuesto;

                orderDetail.UnitPrice = Convert.ToInt32(precio);
                orderDetail.TotalValue = preciot;

                await _context.SaveChangesAsync();

                Order order = _context.Order.Find(id);
                order.SubTotal += preciot;
                order.Valueimp = Convert.ToDecimal(0.18);
                decimal precioimp = order.Valueimp;
                impuesto = preciot * precioimp;
                preciot = preciot + impuesto;
                order.TotalValue += preciot;
                _context.Update(order);
                _context.SaveChanges();

                return RedirectToAction("Details", new {id = id});

            }

            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Comment", orderDetail.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", orderDetail.OrderId);
            return View(orderDetail);

        }
    
    }

}

