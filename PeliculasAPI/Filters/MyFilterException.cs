using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PeliculasAPI.Filters
{
	public class MyFilterException: ExceptionFilterAttribute
	{
        private readonly ILogger<MyFilterException> logger;

        public MyFilterException(ILogger<MyFilterException> logger)
		{
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }

    }
}

