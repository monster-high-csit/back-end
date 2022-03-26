using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.WebApi.Filters
{
    public class ResponseFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //if (context.Result is EmptyResult)
            //{
            //    context.Cancel = true;
            //    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //}
            //context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            //context.Cancel = true;
        }
    }
}
