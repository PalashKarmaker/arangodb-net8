﻿using System.Collections.Generic;

namespace ArangoDBNetStandard.AnalyzerApi.Models
{
    /// <summary>
    /// Properties of an Analyzer.
    /// See https://www.arangodb.com/docs/stable/analyzers.html#analyzer-properties
    /// </summary>
    public class AnalyzerProperties
    {
        /// <summary>
        /// One byte is considered as one character (default)
        /// </summary>
        public const string StreamTypeBinary = "binary";

        /// <summary>
        /// One Unicode codepoint is treated as one character
        /// </summary>
        public const string StreamTypeUTF8 = "utf8";

        /// <summary>
        /// Optional. When true, accented characters are preserved. 
        /// When false, accented characters are converted to 
        /// their base characters.
        /// </summary>
        public bool? Accent { get; set; }

        /// <summary>
        /// A locale in the format language[_COUNTRY][.encoding][@variant] 
        /// (square brackets denote optional parts), e.g. "de.utf-8" or 
        /// "en_US.utf-8". Only UTF-8 encoding is meaningful in ArangoDB. 
        /// The locale is forwarded to ICU without checks. An invalid 
        /// locale does not prevent the creation of the Analyzer.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// The case to use when normalizing the text. Possible values:
        /// "lower" to convert to all lower-case characters
        /// "upper" to convert to all upper-case characters
        /// "none" to not change character case (default)
        /// </summary>
        public string Case { get; set; }

        /// <summary>
        /// An Analyzer is capable of removing 
        /// specified tokens from the input.
        /// It uses binary comparison to 
        /// determine if an input token should
        /// be discarded. It checks for exact 
        /// matches. If the input contains only 
        /// a substring that matches one of the 
        /// defined stopwords, then it is not discarded.
        /// Longer inputs such as prefixes of
        /// stopwords are also not discarded.
        /// </summary>
        public List<string> StopWords { get; set; }

        /// <summary>
        /// Turn Stemming ON or OFF. 
        /// If true, the analyzer stems the text, 
        /// treated as a single token, for supported languages.
        /// Stemming support is provided by Snowball,
        /// which supports the languages listed at:
        /// https://www.arangodb.com/docs/stable/analyzers.html#stemming
        /// </summary>
        public bool? Stemming { get; set; }

        /// <summary>
        /// Introduced in 3.10 for minHash analyzers.
        /// An Analyzer-like definition with a type (string) 
        /// and a properties attribute (object)
        /// This is the inner analyzer to use for incoming data. 
        /// In case if omitted field or empty object falls back 
        /// to identity analyzer. 
        /// </summary>
        public Analyzer Analyzer { get; set; }

        /// <summary>
        /// Introduced in 3.10. for minHash analyzers.
        /// Specifies the size of min hash signature. 
        /// Must be greater or equal to 1. 
        /// The signature size defines the probalistic 
        /// error (err = rsqrt(numHashes)). For an error
        /// amount that does not exceed 5% (0.05), use a
        /// size of 1 / (0.05 * 0.05) = 400.
        /// </summary>
        public int? NumHashes { get; set; }

        /// <summary>
        /// Introduced in 3.10. The on-disk path to 
        /// the trained fastText supervised model.
        /// Note: if you are running this in an 
        /// ArangoDB cluster, this model must 
        /// exist on every machine in the cluster.
        /// Required for classification and 
        /// nearest_neighbors  analyzers. 
        /// </summary>
        public string Model_Location { get; set; }

        /// <summary>
        /// Introduced in 3.10. The number of class
        /// labels that will be produced per input
        /// (default: 1).
        /// Optional for classification and 
        /// nearest_neighbors analyzers.
        /// </summary>
        public int? Top_K { get; set; }

        /// <summary>
        /// Introduced in 3.10. The probability 
        /// threshold for which a label will be 
        /// assigned to an input. A fastText model
        /// produces a probability per class label, 
        /// and this is what will be filtered 
        /// (default: 0.99).
        /// Optional for Classification analyzers.
        /// </summary>
        public decimal? Threshold { get; set; }

        /// <summary>
        /// Unsigned integer for the minimum n-gram length
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Unsigned integer for the maximum n-gram length
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// When true: include the original value as well.
        /// When false: produce the n-grams based on <see cref="Min"/> 
        /// and <see cref="Max"/> only. 
        /// </summary>
        public bool PreserveOriginal { get; set; }

        /// <summary>
        /// This value will be prepended to n-grams which
        /// include the beginning of the input. Can be used
        /// for matching prefixes. Choose a character or 
        /// sequence as marker which does not occur in the input.
        /// </summary>
        public string StartMarker { get; set; }

        /// <summary>
        /// This value will be appended to n-grams which 
        /// include the end of the input. Can be used for 
        /// matching suffixes. Choose a character or sequence
        /// as marker which does not occur in the input.
        /// </summary>
        public string EndMarker { get; set; }

        /// <summary>
        /// Type of the input stream.
        /// Possible values are <see cref="StreamTypeBinary"/>
        /// and <see cref="StreamTypeUTF8"/>
        /// </summary>
        public string StreamType { get; set; }
    }
}