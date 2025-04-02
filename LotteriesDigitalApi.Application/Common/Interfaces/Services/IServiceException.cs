using System.Net;

namespace LotteriesDigitalApi.Application.Common.Interfaces.Services
{
    public interface IServiceExcpetion
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}