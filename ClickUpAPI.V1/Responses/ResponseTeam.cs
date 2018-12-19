using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Responses.Model;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetTeamByID()
    /// </summary>
    public class ResponseTeam : Response
    {

        /// <summary>
        /// Team Model object with the information of the team
        /// </summary>
        [JsonProperty("team")]
        public ModelTeam Team { get; set; }

    }

}
