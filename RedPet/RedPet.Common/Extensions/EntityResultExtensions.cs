using FluentValidation.Results;
using RedPet.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Common.Extensions
{
    public static class EntityResultExtensions
    {
        public static void AddError<T>(this EntityResult<T> entityResult, string message)
        {
            entityResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
    }
}
