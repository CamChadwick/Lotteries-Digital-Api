using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Application.Tickets.Commands.PurchaseTicket
{
    public class PurchaseTicketCommandValidator:AbstractValidator<PurchaseTicketCommand>
    {
        public PurchaseTicketCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.NumberofTickets).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Timestamp).NotEmpty();
            RuleFor(x => x.Drawid).NotEmpty().GreaterThan(0);
        }
    }
}
