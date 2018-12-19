using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Custom Field information response
    /// </summary>
    public class ModelCustomFields : Model
    {

        /// <summary>
        /// Check if the Custom Fields are enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

    }
}
