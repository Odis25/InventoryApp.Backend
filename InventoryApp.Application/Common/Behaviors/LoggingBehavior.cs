using InventoryApp.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehavior(ILogger<TRequest> logger, ICurrentUserService currentUserService) =>
            (_logger, _currentUserService) = (logger, currentUserService);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var time = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            var requestName = typeof(TRequest).Name;
            var userName = _currentUserService.UserName;

            var text = new StringBuilder()
                .AppendLine($"[ --- Request Description --- ]")
                .AppendLine("{")
                .AppendLine($"  Request time: {time}")
                .AppendLine($"  Request name: {requestName}")
                .AppendLine($"  User Name: {userName}")
                .AppendLine($"  Request: {request}")
                .AppendLine("}")
                .ToString();

            _logger.LogInformation(text);

            return await next();
        }
    }
}
