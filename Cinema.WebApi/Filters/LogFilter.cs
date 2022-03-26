using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.WebApi.Filters
{
    public class LogFilter : IActionFilter
    {
        private string fileAdress = @"C:\Users\Sergey\Desktop\back-end\Cinema.WebApi\Filters\Loger.txt";
        public void OnActionExecuted(ActionExecutedContext context)
        {
            using (StreamWriter writer = new StreamWriter(fileAdress))
            {
                writer.WriteLine("Method was executed");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            using (StreamWriter writer = new StreamWriter(fileAdress))
            {
                writer.WriteLine("Method start executing");
            }
        }
    }
}
