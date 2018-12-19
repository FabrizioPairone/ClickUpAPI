using Newtonsoft.Json;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Project information response
    /// </summary>
    public class ModelProject : Model
    {

        /// <summary>
        /// Id of the Project
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the Project
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Check if override statuses of the space for this project
        /// </summary>
        [JsonProperty("override_statuses")]
        public bool? OverrideStatuses { get; set; }

        /// <summary>
        /// List of List Model that contains the information of the lists in this project
        /// </summary>
        [JsonProperty("lists")]
        public List<ModelList> Lists { get; set; }

        /// <summary>
        /// List of Status Model that contains the information of Statuses (Only if Override Statuses is true)
        /// </summary>
        [JsonProperty("statuses")]
        public List<ModelStatus> Statuses { get; set; }

    }

}
