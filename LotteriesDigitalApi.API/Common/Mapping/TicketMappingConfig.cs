using LotteriesDigitalApi.Application.Tickets.Commands.PurchaseTicket;
using LotteriesDigitalApi.Contracts.PurchaseTickets;
using LotteriesDigitalApi.Domain.Ticket;
using Mapster;

namespace LotteriesDigitalApi.API.Common.Mapping
{
    public class TicketMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<PurchaseTicketRequest, PurchaseTicketCommand>();

            config.NewConfig<TicketPurchase, PurchaseTicketResponse>()
                .Map(dest => dest.TotalCost, src => src.TotalPurcahsePrice)
                .Map(dest => dest.TicketsPurchased, src => src.Purchased);
        }
    }
}
