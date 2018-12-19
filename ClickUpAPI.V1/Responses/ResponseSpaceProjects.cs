using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetSpaceProjects()
    /// </summary>
    public class ResponseSpaceProjects : Response
    {

        /// <summary>
        /// List of Project Model with information of the Space
        /// </summary>
        [JsonProperty("projects")]
        public List<ModelProject> Projects { get; set; }

    }

}
