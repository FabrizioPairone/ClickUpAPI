using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Enums;
using PaironsTech.ClickUpAPI.V1.JsonConverters;
using PaironsTech.ClickUpAPI.V1.Requests.SupportModels;
using System;

namespace PaironsTech.ClickUpAPI.V1.Requests
{

    /// <summary>
    /// Request object for method EditTask()
    /// </summary>
    public class RequestEditTask : Request
    {

        /// <summary>
        /// Name of the task
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Content of the task
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
        
        
        /// <summary>
        /// List of users id added or removed to the task
        /// </summary>
        [JsonProperty("assignees")]
        public SupportModel Assignees { get; set; }


        /// <summary>
        /// Status of the Task
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }


        /// <summary>
        /// Priority of the Task
        /// </summary>
        [JsonProperty("priority")]
        public TaskPriority? Priority { get; set; }


        /// <summary>
        /// Due Date of the task
        /// </summary>
        [JsonProperty("due_date")]
        [JsonConverter(typeof(JsonConverterDateTime))]
        public DateTime? DueDate { get; set; }





        /// <summary>
        /// Constructor of RequestEditTask
        /// </summary>
        /// <param name="name">name of the Task [Obligatory]</param>
        public RequestEditTask(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("name can't be empty or null!");

            Name = name;
            Content = null;
            Assignees = null;
            Status = null;
            Priority = null;
            DueDate = null;
        }

    }

}
