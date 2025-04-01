using LotteriesDigitalApi.Application.Tickets.Commands.PurchaseTicket;
using LotteriesDigitalApi.Contracts.PurchaseTickets;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace LotteriesDigitalApi.API.Controllers
{
    [Route("ticket")]
    public class TicketController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public TicketController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _mediator = sender;
        }
        [Route("purchase")]
        [HttpPost]
        public async Task<IActionResult> PurchaseTicket([FromBody]PurchaseTicketRequest request)
        {
           
            var command = _mapper.Map<PurchaseTicketCommand>((request));

            var purchaseTicketResult = await _mediator.Send(command);

          

            return purchaseTicketResult.Match(
                ticket => Ok(_mapper.Map<PurchaseTicketResponse>(ticket)),
                errors => Problem(errors));
        }
    }
}
