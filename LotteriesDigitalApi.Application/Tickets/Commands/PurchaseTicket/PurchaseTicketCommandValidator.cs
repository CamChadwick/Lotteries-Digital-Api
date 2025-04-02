using FluentValidation;

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
