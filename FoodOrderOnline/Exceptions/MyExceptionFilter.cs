using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderOnline.Exceptions
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                string msg = context.Exception.Message;

                context.Result = new ContentResult
                {
                    Content = msg,

                    StatusCode = StatusCodes.Status200OK,

                    ContentType = "application/json;charset=utf-8"
                };
            }
            context.ExceptionHandled = true; //异常已处理了
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);

            return Task.CompletedTask;
        }
    }
}
