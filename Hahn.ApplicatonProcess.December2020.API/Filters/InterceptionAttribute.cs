using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.API.Filters
{
    public class InterceptionAttribute : TypeFilterAttribute
    {
        public InterceptionAttribute() : base(typeof(AutoLogActionFilterImpl))
        {

        }
        private class AutoLogActionFilterImpl : IActionFilter
        {
            private readonly ILogger _logger;
            public AutoLogActionFilterImpl(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<InterceptionAttribute>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                // perform some business logic work
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                _logger.LogInformation($"{System.Environment.NewLine} ---------------- " +
                    $"{System.Environment.NewLine} - Path: {context.HttpContext.Request.Path} " +
                    $"{System.Environment.NewLine} - Method: {context.HttpContext.Request.Method}" +
                    $"{System.Environment.NewLine} - Response : {context.HttpContext.Response.StatusCode}");

            }
        }
    }
}
