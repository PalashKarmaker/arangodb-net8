﻿using System.Collections.Generic;

namespace ArangoDBNet.IndexApi.Models
{
    /// <summary>
    /// Represents an index. Some attributes will depend on the type of index the object represents.
    /// </summary>
    /// <inheritdoc/>
    public class IndexResponseBase : ResponseBase, IIndexResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Fields { get; set; }

        public bool? Sparse { get; set; }

        public string Type { get; set; }

        public bool? Unique { get; set; }

        public bool? Estimates { get; set; }

        public double? SelectivityEstimate { get; set; }

        public bool? Deduplicate { get; set; }

        public bool? GeoJson { get; set; }

        public int? ExpireAfter { get; set; }

        public int? MinLength { get; set; }

        public bool? IsNewlyCreated { get; set; }

        public int? MaxNumCoverCells { get; set; }

        public int? BestIndexedLevel { get; set; }

        public int? WorstIndexedLevel { get; set; }

        public List<string> StoredValues { get; set; }

        /// <summary>
        /// Introduced in v3.10.
        /// If true, an in-memory cache is enabled for 
        /// index values for persistent indexes.
        /// </summary>
        public bool? CacheEnabled { get; set; }


        /// <summary>
        /// Introduced in v3.10.
        /// A geo index with legacyPolygons set to true
        /// will use the old, pre-3.10 rules for the parsing
        /// GeoJSON polygons. This allows you to let old 
        /// indexes produce the same, potentially wrong 
        /// results as before an upgrade. A geo index with
        /// legacyPolygons set to false will use the new, 
        /// correct and consistent method for parsing of
        /// GeoJSON polygons.
        /// </summary>
        public bool? LegacyPolygons { get; set; }
    }
}