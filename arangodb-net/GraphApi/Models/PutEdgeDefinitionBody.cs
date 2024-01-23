using System.Collections.Generic;

namespace ArangoDBNet.GraphApi.Models
{
    public class PutEdgeDefinitionBody
    {
        public string Collection { get; set; }

        public IEnumerable<string> From { get; set; }

        public IEnumerable<string> To { get; set; }
    }
}
