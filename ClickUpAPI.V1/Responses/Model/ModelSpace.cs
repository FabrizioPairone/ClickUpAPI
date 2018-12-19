using Newtonsoft.Json;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Space information response
    /// </summary>
    public class ModelSpace : Model
    {

        /// <summary>
        /// Id of the Space
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the Space
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Check if the Space is Private
        /// </summary>
        [JsonProperty("private")]
        public bool? Private { get; set; }

        /// <summary>
        /// List of Model Status with the statuses of the Space
        /// </summary>
        [JsonProperty("statuses")]
        public List<ModelStatus> Statuses { get; set; }

        /// <summary>
        /// Check if it's active multiple assignees in this Space
        /// </summary>
        [JsonProperty("multiple_assignees")]
        public bool? MultipleAssignees { get; set; }
        
        /// <summary>
        /// Model Feature Object that contains the information about features of this Space
        /// </summary>
        [JsonProperty("features")]
        public ModelFeatures Features { get; set; }

        /// <summary>
        /// List of Model User Object with the informations about the members of the Space
        /// </summary>
        [JsonProperty("members")]
        public List<ModelUser> Members { get; set; }

    }

}
