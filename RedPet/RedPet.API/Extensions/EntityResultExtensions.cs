using Microsoft.AspNetCore.Mvc;
using RedPet.API.Middleware;
using RedPet.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Net;

namespace RedPet.API.Extensions
{
    public static class EntityResultExtensions
    {
        public static ActionResult<T> ConvertToActionResult<T>(this EntityResult<T> result, HttpStatusCode successStatusCode)
        {
            result.StatusCode = result.StatusCode ?? (int)successStatusCode;

            var value = GetReturnValue(result);

            var response = ResponseFactory.CreateResponseMethod<T>(result.StatusCode.Value);

            return response(value);
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

            return new SlimValidationResult(result, result.StatusCode ?? 500);
        }

        private static class ResponseFactory
        {
            public static Func<object, ActionResult<T>> CreateResponseMethod<T>(int statusCode)
            {
                var responsesDictionary = new Dictionary<int, Func<object, ActionResult<T>>>();
                ActionResult<T> OkResponse(object x) => x != null ? (ActionResult)new OkObjectResult(x) : new OkResult();
                ActionResult<T> BadRequestResponse(object x) => x != null ? (ActionResult)new BadRequestObjectResult(x) : new BadRequestResult();
                ActionResult<T> NotFoundResponse(object x) => x != null ? (ActionResult)new NotFoundObjectResult(x) : new NotFoundResult();
                ActionResult<T> ConflictResponse(object x) => x != null ? (ActionResult)new ConflictObjectResult(x) : new ConflictResult();
                ActionResult<T> DefaultResponse(object x) => (ActionResult)new ObjectResult(x) { StatusCode = statusCode };

                responsesDictionary.Add((int)HttpStatusCode.OK, OkResponse);
                responsesDictionary.Add((int)HttpStatusCode.BadRequest, BadRequestResponse);
                responsesDictionary.Add((int)HttpStatusCode.NotFound, NotFoundResponse);
                responsesDictionary.Add((int)HttpStatusCode.Conflict, ConflictResponse);

                if (responsesDictionary.TryGetValue(statusCode, out var response))
                    return response;

                return DefaultResponse;
            }
        }
    }
}