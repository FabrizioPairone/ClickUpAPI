using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Time Tracking information response
    /// </summary>
    public class ModelTimeTracking : Model
    {

        /// <summary>
        /// Check if Time Tracking is Enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Check if Time Trackign is harvest
        /// </summary>
        [JsonProperty("harvest")]
        public bool? Harvest { get; set; }

    }

}
