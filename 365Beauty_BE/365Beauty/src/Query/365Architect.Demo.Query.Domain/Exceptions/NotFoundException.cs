﻿using _365Architect.Demo.Query.Contract.Extensions;

namespace _365Architect.Demo.Query.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Exception for common not found entities
        /// </summary>
        /// <param name="message">Message for providing more information</param>
        public NotFoundException(string? message = null) : base(message)
        {
            this.AddErrorCode(ExceptionCodeConstant.NOT_FOUND);
        }
    }
}