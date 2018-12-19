using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Responses
{

    /// <summary>
    /// Response object of the method GetTasks()
    /// </summary>
    public class ResponseTasks : Response
    {

        /// <summary>
        /// List of Model Task with information of Tasks received
        /// </summary>
        [JsonProperty("tasks")]
        public List<ModelTask> Tasks { get; set; }
        
    }

}
