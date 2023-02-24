using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PeliculasAPI.Filters
{
    public class MyFilterAction : IActionFilter
    {
        private readonly ILogger<MyFilterAction> logger;

        public MyFilterAction(ILogger<MyFilterAction> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("Before execute the action");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("After execute the action");
        }

    }
}

