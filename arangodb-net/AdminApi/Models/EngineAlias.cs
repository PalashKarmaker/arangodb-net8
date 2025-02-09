﻿using System.Collections.Generic;

namespace ArangoDBNet.AdminApi.Models
{
    public class EngineAlias
    {
        /// <summary>
        /// List of indexes and associated types
        /// </summary>
        public Dictionary<string, string> Indexes { get; set; }
    }
}