using System.Collections.Generic;

namespace ArangoDBNet.IndexApi.Models
{
    /// <summary>
    /// Response from <see cref="IndexApiClient.GetAllCollectionIndexesAsync"/>
    /// </summary>
    public class GetAllCollectionIndexesResponse : ResponseBase
    {
        /// <summary>
        /// The list of all indexes for the collection.
        /// </summary>
        public IEnumerable<IndexResponseBase> Indexes { get; set; }

        /// <summary>
        /// All the indexes for the collection as a dictionary where each key is the index ID.
        /// </summary>
        public Dictionary<string, IndexResponseBase> Identifiers { get; set; }
    }
}
