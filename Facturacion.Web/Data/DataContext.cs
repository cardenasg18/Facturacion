using Facturacion.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Data
{
    public class DataContext : DbContext   
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Clasification> Clasifications { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierType> SupplierTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Facturacion.Web.Models.Order> Order { get; set; }
        public DbSet<Facturacion.Web.Models.OrderDetail> OrderDetail { get; set; }
        public DbSet<Facturacion.Web.Models.PurchaseDetail> PurchaseDetail { get; set; }
        public DbSet<Facturacion.Web.Models.PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<Facturacion.Web.Models.Product> Products { get; set; }
        public DbSet<Facturacion.Web.Models.Chair> Chairs { get; set; }
        public DbSet<Facturacion.Web.Models.Usuario> Usuarios { get; set; }
        public DbSet<Facturacion.Web.Models.Role> Role { get; set; }
        public DbSet<Facturacion.Web.Models.Login> Login { get; set; }



    }
}
