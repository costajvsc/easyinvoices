using System;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}