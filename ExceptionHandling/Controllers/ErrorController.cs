﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionHandling.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("/Error")]
        public IActionResult Index()
        {
            IExceptionHandlerPathFeature iExceptionHandlerFeature = HttpContext.Features.Get <IExceptionHandlerPathFeature>();
            if (iExceptionHandlerFeature != null)
            {
                string path = iExceptionHandlerFeature.Path;
                Exception exception =
                iExceptionHandlerFeature.Error;
                //Write code here to log the exception details
                return View("Error",
                iExceptionHandlerFeature);
            }
            return View();
        }
        [HttpGet("/Error/NotFound/{statusCode}")]
        public IActionResult NotFound(int statusCode)
        {
            var iStatusCodeReExecuteFeature =
            HttpContext.Features.Get
            <IStatusCodeReExecuteFeature>();
            return View("NotFound",
            iStatusCodeReExecuteFeature.OriginalPath);
        }
    }
}
