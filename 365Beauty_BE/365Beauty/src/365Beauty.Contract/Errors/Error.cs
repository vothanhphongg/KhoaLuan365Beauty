using _365Beauty.Contract.Abtractions;
using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Contract.Errors
{
    /// <summary>
    /// Provide error for domain, contain error type and messages
    /// </summary>
    public class Error : IError
    {
        public List<string>? Details { get; }
        public ErrorType Type { get; }
        public string ErrorCode { get; }

        /// <summary>
        /// Provide error for domain, contain error type and messages
        /// </summary>
        /// <param name="type">Type of error</param>
        /// <param name="errorCode"></param>
        /// <param name="details">Error messages to provide more information</param>
        public Error(ErrorType type, string errorCode, params string[]? details)
        {
            Details = new List<string>();
            if (details is not null) Details.AddRange(details);
            Type = type;
            ErrorCode = errorCode;
        }
    }
}
