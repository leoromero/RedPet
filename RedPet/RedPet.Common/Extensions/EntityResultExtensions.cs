using FluentValidation.Results;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Extensions
{
    public static class EntityResultExtensions
    {
        public static void AddError<T>(this EntityResult<T> entityResult, string message, int statusCode = 500)
        {
            entityResult.StatusCode = statusCode;
            entityResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
        public static void AddError<T>(this EntityResult<T> entityResult, string field, string message, int statusCode = 500)
        {
            entityResult.StatusCode = statusCode;
            entityResult.Errors.Add(new ValidationFailure(field, message));
        }
    }
}
