using System;

namespace api.Contracts.V1.Exceptions
{
    public class BadRequestException : Exception
    {
        public ApiError Errors { get; set; }

        public BadRequestException(ApiError errors)
        {
            Errors = errors;
        }
    }
}