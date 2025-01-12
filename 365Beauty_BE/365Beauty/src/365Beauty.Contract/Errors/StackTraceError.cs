﻿using _365Beauty.Contract.Abtractions;
using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Contract.Errors
{
    /// <summary>
    /// Provide error for domain, contain error type, stack trace, and messages
    /// </summary>
    public class StackTraceError : IError
    {
        public ErrorType Type { get; }
        public string ErrorCode { get; }
        public List<string>? Details { get; }
        public string StackTrace { get; }

        /// <summary>
        ///  Provide error for domain, contain error type, stack trace, and messages
        /// </summary>
        /// <param name="type"></param>
        /// <param name="errorCode"></param>
        /// <param name="stackTrace"></param>
        /// <param name="details"></param>
        public StackTraceError(ErrorType type, string errorCode, string stackTrace, params string[]? details)
        {
            Details = new List<string>();
            if (details is not null) Details.AddRange(details);
            Type = type;
            ErrorCode = errorCode;
            StackTrace = stackTrace;
        }
    }
}
