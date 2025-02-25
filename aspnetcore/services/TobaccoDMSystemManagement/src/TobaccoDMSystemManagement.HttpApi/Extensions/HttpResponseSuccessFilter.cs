﻿using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TobaccoDMSystemManagement.Extensions
{
    public class HttpResponseSuccessFilter : IActionFilter
    {

        /// <summary>
        /// 请求时长计时开始
        /// </summary>
        private readonly Stopwatch watch = new Stopwatch();


        /// <summary>
        /// 返回结果执行之前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            watch.Start();//开始  
        }

        /// <summary>
        /// 返回结果执行之后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            watch.Stop();
            //根据实际需求进行具体实现
            if (context.Result is ObjectResult && context.Exception == null)
            {
                var objectResult = context.Result as ObjectResult;
                if (objectResult == null)
                {
                    context.Result = new ObjectResult(new HttpResponseSuccess(HttpStatusCode.NotFound, null, "未找到资源!", DateTime.Now, watch.ElapsedMilliseconds));
                }
                else
                {
                    context.Result = new ObjectResult(new HttpResponseSuccess(HttpStatusCode.OK, objectResult.Value, "请求成功！", DateTime.Now, watch.ElapsedMilliseconds));
                }
            }

        }

    }

    
    public record HttpResponseSuccess(HttpStatusCode Code, object Data, string Message, DateTime ServiceTime, long TimeOut);
}
