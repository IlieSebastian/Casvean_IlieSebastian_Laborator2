using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casvean_IlieSebastian_Laborator2.Models;
using Microsoft.EntityFrameworkCore;

namespace Casvean_IlieSebastian_Laborator2.DataAccess
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Order>().ToTable("Order");
        }

    }
}
