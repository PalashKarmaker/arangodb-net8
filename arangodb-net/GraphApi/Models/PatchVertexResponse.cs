﻿using System.Net;

namespace ArangoDBNet.GraphApi.Models
{
    public class PatchVertexResponse<T>
    {
        public T New { get; set; }

        public T Old { get; set; }

        public HttpStatusCode Code { get; set; }

        public PatchVertexResult Vertex { get; set; }

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
    }
}
