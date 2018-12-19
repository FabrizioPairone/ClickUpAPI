using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Dependency Warning information response
    /// </summary>
    public class ModelDependencyWarning : Model
    {

        /// <summary>
        /// Check if the Dependecy Warning are enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

    }

}
