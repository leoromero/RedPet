using Microsoft.AspNetCore.Mvc;
using RedPet.API.Middleware;
using RedPet.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RedPet.API.Extensions
{
    public static class EntityResultExtensions
    {
        public static ActionResult<T> ConvertToActionResult<T>(this EntityResult<T> result, HttpStatusCode statusCode)
        {
            var value = GetReturnValue(result);

            var response = ResponseFactory.CreateResponseMethod<T>(statusCode);

            return result.IsValid ? response(value) : new ObjectResult(value) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        public static IActionResult ConvertToObjectResult<T>(this EntityResult<T> result, HttpStatusCode successStatusCode)
        {
            var statusCode = result.IsValid ? successStatusCode : HttpStatusCode.InternalServerError;

            var value = GetReturnValue(result);

            return value == null && successStatusCode == HttpStatusCode.OK
                ? (IActionResult)new OkResult()
                : new ObjectResult(value) { StatusCode = (int)statusCode };
        }

        private static object GetReturnValue<T>(EntityResult<T> result)
        {
            if (result.IsValid)
                return result.Entity;

            return new SlimValidationResult(result);
        }

        private static class ResponseFactory
        {
            public static Func<object, ActionResult<T>> CreateResponseMethod<T>(HttpStatusCode statusCode)
            {
                ActionResult<T> OkResponse(object x) => x != null ? (ActionResult)new OkObjectResult(x) : new OkResult();
                ActionResult<T> BadRequestResponse(object x) => x != null ? (ActionResult)new BadRequestObjectResult(x) : new BadRequestResult();
                ActionResult<T> DefaultResponse(object x) => (ActionResult)new ObjectResult(x) { StatusCode = (int)statusCode };

                return statusCode == HttpStatusCode.BadRequest
                    ? BadRequestResponse
                    : statusCode == HttpStatusCode.OK
                        ? OkResponse
                        : (Func<object, ActionResult<T>>)DefaultResponse;
            }
        }
    }
}