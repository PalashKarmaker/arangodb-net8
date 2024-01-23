using System.Collections.Generic;

namespace ArangoDBNet.CollectionApi.Models
{
    public class GetCollectionShardsResponse : CollectionShardsResponseBase
    {
        public List<string> Shards { get; set; }
    }
}