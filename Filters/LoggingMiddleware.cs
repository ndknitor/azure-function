using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
namespace Localnow.Middlewares;
public class LoggingMiddleware : IFunctionsWorkerMiddleware
{
    private ILogger<LoggingMiddleware> logger;
    public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
    {
        this.logger = logger;
    }
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        logger.LogInformation("Code before function execution here");
        await next(context);
        logger.LogInformation("Code after function execution here");
    }
}
