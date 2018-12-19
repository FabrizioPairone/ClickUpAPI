using Newtonsoft.Json;
using System;

namespace PaironsTech.ClickUpAPI.V1.JsonConverters
{

    /// <summary>
    /// Json Converter class of DateTime object
    /// </summary>
    public class JsonConverterDateTime : JsonConverter
    {

        /// <summary>
        /// Check if can convert this type of object. (Can only convert DateTime)
        /// </summary>
        /// <param name="objectType">object Type</param>
        /// <returns>Bool if can convert this object</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(DateTime).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Read long with milliseconds and convert to Datetime with Unix method
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse((string)reader.Value)).DateTime;
        }

        /// <summary>
        /// Get Datetime and serialize it to long for Unix method
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, new DateTimeOffset(((DateTime)value)).ToUnixTimeMilliseconds());
        }

    }
}
