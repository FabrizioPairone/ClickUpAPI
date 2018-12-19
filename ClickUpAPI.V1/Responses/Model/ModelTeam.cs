using Newtonsoft.Json;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model Object of Team information response
    /// </summary>
    public class ModelTeam : Model
    {

        /// <summary>
        /// Id of the team
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the Team
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Theme Color of the Team
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// The Url of the Avatar of the Team
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// List of User Model object with the members of the Team
        /// </summary>
        [JsonProperty("members")]
        public List<ModelUser> Members { get; set; }

    }

}
