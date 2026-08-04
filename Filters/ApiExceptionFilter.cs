using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VigilyAPI.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext x)
        {
            if (x.Exception is UnauthorizedAccessException)
            {
                _logger.LogWarning(x.Exception, "Tentativa de login nao autorizada: status 401");

                x.Result = new ObjectResult(x.Exception.Message)
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
                return;
            }

            _logger.LogError(x.Exception, $"Ocorreu um exceção nao tratada: status 500");

            x.Result = new ObjectResult("Ocorreu um erro ao tratar sua solicitação")
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
