using System.Collections.Generic;
using System.Net;

namespace ArangoDBNet.AqlFunctionApi.Models
{
    /// <summary>
    /// Represents a response returned when getting all AQL user functions.
    /// </summary>
    public class GetAqlFunctionsResponse
    {
        /// <summary>
        /// Indicates whether an error occurred (false in this case).
        /// </summary>
        /// <remarks>
        /// Note that in cases where an error occurs, the ArangoDBNet
        /// client will throw an <see cref="ApiErrorException"/> rather than
        /// populating this property. A try/catch block should be used instead
        /// for any required error handling.
        /// </remarks>
        public bool Error { get; set; }

        /// <summary>
        /// The HTTP status code.
        /// </summary>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// All functions, or the ones matching
        /// the <see cref="GetAqlFunctionsQuery.Namespace"/> parameter.
        /// </summary>
        public IList<AqlFunctionResult> Result { get; set; }
    }
}