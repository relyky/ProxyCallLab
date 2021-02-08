using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace SimsBackendApi
{
    #region DTO
    public class ErrMsg
    {
        /// <summary>
        /// Enum: SUCCESS | ERROR | EXCEPTION
        /// </summary>
        public string errType { get; set; }
        public string errMsg { get; set; }
        public string errClass { get; set; }
    }
    #endregion

    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            context.HttpContext.Response.WriteAsJsonAsync<ErrMsg>(new ErrMsg
            {
                errType = context.Exception is ApplicationException ? "ERROR" : "EXCEPTION",
                errMsg = context.Exception.Message,
                errClass = context.Exception.GetType().Name
            });

            return Task.CompletedTask;
        }
    }
}
