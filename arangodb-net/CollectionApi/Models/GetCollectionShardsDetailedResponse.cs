using System.Collections.Generic;

namespace ArangoDBNet.CollectionApi.Models
{
    public class GetCollectionShardsDetailedResponse : CollectionShardsResponseBase
    {
        public Dictionary<string, List<string>> Shards { get; set; }
    }
}