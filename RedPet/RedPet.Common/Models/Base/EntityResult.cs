using FluentValidation.Results;
using RedPet.Common.Extensions;
using System;

namespace RedPet.Common.Models.Base
{
    public class EntityResult<T> : ValidationResult
    {
        public EntityResult()
        {
            var type = typeof(T);

            if (!type.IsSimple())
            {
                Entity = Activator.CreateInstance<T>();
            }
        }

        public T Entity { get; set; }
        public int? StatusCode { get; set; }
    }
}