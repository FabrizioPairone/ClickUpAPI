using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Multiple Assignees information response
    /// </summary>
    public class ModelMultipleAssignees : Model
    {

        /// <summary>
        /// Check if the Multiple Assignees are enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

    }

}
