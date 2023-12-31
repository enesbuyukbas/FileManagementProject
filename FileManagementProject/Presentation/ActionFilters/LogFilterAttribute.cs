﻿using FileManagementProject.Entities.LogModel;
using FileManagementProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FileManagementProject.Presentation.ActionFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _logger;

        public LogFilterAttribute(ILoggerService logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(Log("OnActionExecuting", context.RouteData));
        }

        private string Log(string modelName, RouteData RouteData)
        {
            var logDetails = new LogDetails()
            {
                ModelName = modelName,
                Controller = RouteData.Values["controller"],
                Action = RouteData.Values["action"]
            };

            if(RouteData.Values.Count >= 3)
            {
                logDetails.Id = RouteData.Values["Id"];
            }
            return logDetails.ToString();
        }
    }
}
