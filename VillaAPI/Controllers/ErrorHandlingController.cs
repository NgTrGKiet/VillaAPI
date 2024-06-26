﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VillaAPI.Controllers
{
    public class ErrorHandlingController : ControllerBase
    {
        public IActionResult ProcessError([FromServices] IHostEnvironment hostEnvironment)
        {
            if (hostEnvironment.IsDevelopment())
            {
                //custom logic
                var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();

                return Problem(
                    detail: feature.Error.StackTrace,
                    title: feature.Error.Message,
                    instance: hostEnvironment.EnvironmentName
                    );
            }
            else
            {
                return Problem();
            }
        }
    }
}
