﻿using CustomerDataProcessingApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerDataProcessingApp.Api.Dal
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
                
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
