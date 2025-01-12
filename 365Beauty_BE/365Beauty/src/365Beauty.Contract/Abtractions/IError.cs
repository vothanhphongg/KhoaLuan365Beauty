using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Errors;
using System.Text.Json.Serialization;

namespace _365Beauty.Contract.Abtractions
{
    /// <summary>
    /// Represent application error
    /// </summary>
    [JsonDerivedType(typeof(StackTraceError))]
    [JsonDerivedType(typeof(Error))]
    public interface IError
    {
        /// <summary>
        /// Indicate which type of error
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorType Type { get; }

        /// <summary>
        /// Code of error
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Use for providing more information
        /// </summary>
        public List<string>? Details { get; }
    }
}
