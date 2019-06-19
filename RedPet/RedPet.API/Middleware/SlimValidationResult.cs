using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedPet.API.Middleware
{
    public class SlimValidationResult
    {
        public SlimValidationResult(ModelStateDictionary modelState, int statusCode = 400)
        {
            Errors = modelState.Keys.Any(key => modelState[key].Errors.Any(x => !string.IsNullOrEmpty(x.ErrorMessage)))
                ? modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => new Error(key, x.ErrorMessage))).ToList()
                : modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => new Error(key, x.Exception.Message))).ToList();
        }

        public SlimValidationResult(string error, int statusCode = 500)
        {
            Message =  error;
        }
        public SlimValidationResult(ValidationResult result, int statusCode = 500)
        {
            Status = statusCode;
            Errors = result.Errors.Select(x => new Error(x.PropertyName, x.ErrorMessage )).ToList();
        }
        public SlimValidationResult(Exception exception) : this(exception.Message) { }

        public int Status { get; }
        
        public string Message { get; }

        public List<Error> Errors { get; }

        public class Error
        {
            public Error(string field, string message)
            {
                Field = field;
                Message = message;
            }
            public Error(string message)
            {
                Message = message;
            }
            public string Field { get; }
            public string Message { get; }
        }
    }
}