﻿using System.Net;

namespace ArangoDBNet.CollectionApi.Models
{
    public class RenameCollectionResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public CollectionType Type { get; set; }

        public bool IsSystem { get; set; }

        public HttpStatusCode Code { get; set; }

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
