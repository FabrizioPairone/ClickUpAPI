using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Tag information response
    /// </summary>
    public class ModelTag : Model
    {

        /// <summary>
        /// Name of the Tag
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Foreground color of the Tag
        /// </summary>
        [JsonProperty("tag_fg")]
        public string TagFg { get; set; }

        /// <summary>
        /// Background color of the Tag
        /// </summary>
        [JsonProperty("tag_bg")]
        public string TagBg { get; set; }

        /// <summary>
        /// Check if the Tag is enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
             
    }

}
