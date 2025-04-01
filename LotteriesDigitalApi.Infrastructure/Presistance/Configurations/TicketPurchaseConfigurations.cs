using LotteriesDigitalApi.Domain.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Infrastructure.Presistance.Configurations
{
    public class TicketPurchaseConfigurations : IEntityTypeConfiguration<TicketPurchase>
    {
        public void Configure(EntityTypeBuilder<TicketPurchase> builder)
        {
            ConfigureTicketPurchaseBuilder(builder); 
        }

        private void ConfigureTicketPurchaseBuilder(EntityTypeBuilder<TicketPurchase> builder)
        {
          
            builder.HasKey(m => m.Id);
           

        }
    }
}
