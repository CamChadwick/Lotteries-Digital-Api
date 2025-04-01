using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Application.Common.Interfaces.Services
{
    public interface IServiceExcpetion
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}