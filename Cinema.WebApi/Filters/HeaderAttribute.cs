using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Cinema.WebApi.Filters
{
    public class HeaderAttribute : ActionFilterAttribute
    {
        private string _name;
        private string _value;

        public HeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            List<byte> arr = new List<byte>();
            context.HttpContext.Response.Headers.Add(_name, _value);
            base.OnResultExecuting(context);
        }
    }
}
