using Microsoft.AspNetCore.Mvc.Filters;

namespace VigilyAPI.Filters
{
    public class ApiLogginFilter : IActionFilter
    {
        private readonly ILogger<ApiLogginFilter> _logger;

        public ApiLogginFilter(ILogger<ApiLogginFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(
                $"Executado, segue StatusCode: {context.HttpContext.Response.StatusCode}"
            );
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Executando.., segue ModelState: {context.ModelState.IsValid}");
        }
    }
}
