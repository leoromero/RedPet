using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedPet.API.Middleware
{
    public class SlimValidationResult
    {
        public SlimValidationResult(ModelStateDictionary modelState)
        {
            Errors = modelState.Keys.Any(key => modelState[key].Errors.Any(x => !string.IsNullOrEmpty(x.ErrorMessage)))
                ? modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => $"{key}: {x.ErrorMessage}")).ToList()
                : modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => $"{key}: {x.Exception.Message}")).ToList();
        }

        public SlimValidationResult(string error)
        {
            Errors = new List<string> { error };
        }
        public SlimValidationResult(ValidationResult result)
        {
            Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        }
        public SlimValidationResult(Exception exception) : this(exception.Message) { }

        public List<string> Errors { get; }
    }
}