using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Enums;
using PaironsTech.ClickUpAPI.V1.JsonConverters;
using System;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Requests
{

    /// <summary>
    /// Request object for method CreateTaskInList()
    /// </summary>
    public class RequestCreateTaskInList : Request
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
        /// List of user id that will be added to this task
        /// </summary>
        [JsonProperty("assignees")]
        public List<long> Assignees { get; set; }

        /// <summary>
        /// Status of the task
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Prioriry of the task
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
        /// Constructor of RequestCreateTaskInList
        /// </summary>
        /// <param name="name">name of the new Task [Obligatory]</param>
        public RequestCreateTaskInList(string name)
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
