using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Time Estimates information response
    /// </summary>
    public class ModelTimeEstimates : Model
    {

        /// <summary>
        /// Check if Time Estimates is enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

    }

}
