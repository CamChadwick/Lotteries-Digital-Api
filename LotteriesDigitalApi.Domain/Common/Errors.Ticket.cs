using ErrorOr;
namespace LotteriesDigitalApi.Domain.Common
{
    public static partial class Errors
    {
        public static class Ticket
        {
            public static Error DupplicateTicketRequest => Error.Conflict(code: "Ticket.DupplicateRequest", description: "Ticket request has already been made");

        }
    }
}
