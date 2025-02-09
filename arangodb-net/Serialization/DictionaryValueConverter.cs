﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArangoDBNet.Serialization
{
    /// <summary>
    /// Provides special handling for dictionaries where we do not want to camel-case convert 
    /// nor ignore null values upon serialization.
    /// </summary>
    public class DictionaryValueConverter : JsonConverter
    {
        private ApiClientSerializationOptions _serializationOptions;

        public DictionaryValueConverter(ApiClientSerializationOptions serializationOptions)
        {
            _serializationOptions = serializationOptions;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Use a local serializer for writing instead of the passed-in serializer
            JsonSerializer mySerializer;
            if (_serializationOptions != null && _serializationOptions.ApplySerializationOptionsToDictionaryValues)
            {
                mySerializer = new JsonSerializer
                {
                    MissingMemberHandling = _serializationOptions.IgnoreMissingMember ? MissingMemberHandling.Ignore : MissingMemberHandling.Error,
                    NullValueHandling = _serializationOptions.IgnoreNullValues ? NullValueHandling.Ignore : NullValueHandling.Include
                };
                if (_serializationOptions.UseStringEnumConversion)
                {
                    var stringEnumConverter = new StringEnumConverter();
                    mySerializer.Converters.Add(stringEnumConverter);
                }
                if (_serializationOptions.UseCamelCasePropertyNames)
                {
                    mySerializer.ContractResolver = new CamelCasePropertyNamesExceptDictionaryContractResolver(_serializationOptions);
                }
            }
            else
            {
                mySerializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Include
                };
            }
            mySerializer.Serialize(writer, value);
        }
    }
}