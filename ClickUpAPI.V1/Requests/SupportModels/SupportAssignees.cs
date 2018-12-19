using Newtonsoft.Json;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Requests.SupportModels
{

    /// <summary>
    /// Support Models for assigness user at the task
    /// </summary>
    public class SupportAssignees : SupportModel
    {
        
        /// <summary>
        /// List of integer id of the user added to the task
        /// </summary>
        [JsonProperty("add")]
        public List<long> Add { get; set; }


        /// <summary>
        /// List of integer id of the user removed to the task
        /// </summary>
        [JsonProperty("rem")]
        public List<long> Rem { get; set; }

    }

}
