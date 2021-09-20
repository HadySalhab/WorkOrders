using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrders.Model;

namespace WorkOrders.Database
{
    public class WOrdersDbContext : DbContext
    {
        public WOrdersDbContext(DbContextOptions<WOrdersDbContext> options):base(options) { }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<State> State { get; set; }
    }
}
