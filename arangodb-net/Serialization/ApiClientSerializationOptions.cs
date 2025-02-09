﻿namespace ArangoDBNet.Serialization
{
    /// <summary>
    /// The API client serialization options class.
    /// </summary>
    /// <remarks>
    /// Create serialization options.
    /// </remarks>
    /// <param name="useCamelCasePropertyNames">Whether property names should be serialized using camelCase.</param>
    /// <param name="ignoreNullValues">Whether null values should be ignored - i.e. not defined at all in the serialized string.</param>
    /// <param name="useStringEnumConversion">Whether to serialize enum values to a string value instead of an integer.</param>
    /// <param name="ignoreMissingMember">Whether missing members should be ignored.</param>
    /// <param name="applySerializationOptionsToDictionaryValues">Whether to apply serialization options to object values in dictionaries.</param>
    public class ApiClientSerializationOptions(
        bool useCamelCasePropertyNames,
        bool ignoreNullValues,
        bool useStringEnumConversion = false,
        bool ignoreMissingMember = true,
        bool applySerializationOptionsToDictionaryValues = false)
    {
        /// <summary>
        /// Use camel case if true, otherwise depends on
        /// the action will be implemented in the serializer.
        /// </summary>
        public bool UseCamelCasePropertyNames { get; set; } = useCamelCasePropertyNames;

        /// <summary>
        /// True to ignore null values, otherwise false.
        /// </summary>
        public bool IgnoreNullValues { get; set; } = ignoreNullValues;

        /// <summary>
        /// True to ignore missing members when deserializing, otherwise false.
        /// </summary>
        public bool IgnoreMissingMember { get; set; } = ignoreMissingMember;

        /// <summary>
        /// True to serialize enums to string values, 
        /// false to serialize enums to integer values (default).
        /// </summary>
        public bool UseStringEnumConversion { get; set; } = useStringEnumConversion;

        /// <summary>
        /// True to apply serialization options to object values 
        /// in dictionaries (i.e. CamelCaseMe => "camelCaseMe").
        /// False to not apply serialization options to object values
        /// in dictionaries (i.e. leave the names of properties of object values 
        /// in dictionaries as they are: DontCamelCaseMe => "DontCamelCaseMe")        
        /// </summary>
        public bool ApplySerializationOptionsToDictionaryValues { get; set; } = applySerializationOptionsToDictionaryValues;
    }
}