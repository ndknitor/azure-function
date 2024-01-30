using System.Net;
using Localnow.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace KN.Function
{
    public class Main
    {
        private readonly ILogger<Main> _logger;

        public Main(ILogger<Main> logger)
        {
            _logger = logger;
        }

        [Function("main")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            OffsetPagingRequest pagingRequest = new OffsetPagingRequest(req.Query);
            return new OkObjectResult(Enumerable.Range((pagingRequest.Page - 1) * pagingRequest.Size, pagingRequest.Size));
        }
        [Function("main-single")]
        public IActionResult RunSingle([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "main/single")] HttpRequest req)
        {
            float a = 7.11f / 9.32f;
            return new OkObjectResult(new { number = a.ToString("0.000000000000000000000000000000000") });
        }
        [Function("main-date")]
        public IActionResult GetDate([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "main/date")] HttpRequest req)
        {
            return new OkObjectResult(new { date = DateTime.Now });
        }
        [Function("main-hostname")]
        public IActionResult GetHostname([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "main/hostname")] HttpRequest req)
        {
            return new OkObjectResult(Dns.GetHostName());
        }
    }
}
