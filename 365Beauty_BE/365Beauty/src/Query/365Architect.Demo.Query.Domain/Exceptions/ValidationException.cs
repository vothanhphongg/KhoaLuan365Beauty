﻿using _365Architect.Demo.Query.Contract.Extensions;

namespace _365Architect.Demo.Query.Domain.Exceptions
{
    /// <summary>
    /// Exception for failed when validate domain logic
    /// </summary>
    public class ValidationException : Exception
    {
        public IReadOnlyList<string> ValidationResults { get; private set; }

        public ValidationException(params string[] validationResults)
        {
            ValidationResults = validationResults;
            this.AddErrorCode(ExceptionCodeConstant.VALIDATION_PROBLEM);
        }
    }
}