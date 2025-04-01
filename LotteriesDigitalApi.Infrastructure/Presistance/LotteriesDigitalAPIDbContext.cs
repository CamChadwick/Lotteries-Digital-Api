using LotteriesDigitalApi.Domain.Ticket;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Infrastructure.Presistance
{
    public class LotteriesDigitalAPIDbContext:DbContext
    {
        public LotteriesDigitalAPIDbContext(DbContextOptions<LotteriesDigitalAPIDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<TicketPurchase> TicketPurchases { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(LotteriesDigitalAPIDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
