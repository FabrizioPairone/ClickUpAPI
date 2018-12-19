using Newtonsoft.Json;
using System;

namespace PaironsTech.ClickUpAPI.V1.Requests
{

    /// <summary>
    /// Request object for method EditList()
    /// </summary>
    public class RequestEditList : Request
    {

        /// <summary>
        /// Name of the list
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }





        /// <summary>
        /// Constructor of RequestEditList
        /// </summary>
        /// <param name="name">name of the task [Obligatory]</param>
        public RequestEditList(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("name can't be empty or null!");

            Name = name;
        }

    }

}
