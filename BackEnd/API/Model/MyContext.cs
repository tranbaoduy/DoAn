using Microsoft.EntityFrameworkCore;
using Model.Model;
using Model.Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Functions> functions { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<groupFunctions> groupFunctions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer
        //}
    }
}
