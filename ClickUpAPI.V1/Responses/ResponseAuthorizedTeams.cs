using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetAuthorizedTeams()
    /// </summary>
    public class ResponseAuthorizedTeams : Response
    {

        /// <summary>
        /// List of Team Model with information of authorized Teams
        /// </summary>
        [JsonProperty("teams")]
        public List<ModelTeam> Teams { get; set; }

    }

}
