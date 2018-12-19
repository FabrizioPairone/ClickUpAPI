using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetTeamSpaces()
    /// </summary>
    public class ResponseTeamSpace : Response
    {

        /// <summary>
        /// List of Space Model with information of authorized Team
        /// </summary>
        [JsonProperty("spaces")]
        public List<ModelSpace> Spaces { get; set; }

    }

}
