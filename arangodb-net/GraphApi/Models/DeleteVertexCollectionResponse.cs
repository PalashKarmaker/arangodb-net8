using System.Net;

namespace ArangoDBNet.GraphApi.Models
{
    public class DeleteVertexCollectionResponse
    {
        /// <summary>
        /// Indicates whether an error occurred
        /// </summary>
        /// <remarks>
        /// Note that in cases where an error occurs, the ArangoDBNet
        /// client will throw an <see cref="ApiErrorException"/> rather than
        /// populating this property. A try/catch block should be used instead
        /// for any required error handling.
        /// </remarks>
        public bool Error { get; set; }

        public HttpStatusCode Code { get; set; }

        public GraphResult Graph { get; set; }
    }
}
