using System.Collections.Generic;

namespace ArangoDBNet.AdminApi.Models
{
    public class EngineSupports
    {
        public bool DFDB { get; set; }
        public IEnumerable<string> Indexes { get; set; }
        public EngineAlias Aliases { get; set; }
    }
}
