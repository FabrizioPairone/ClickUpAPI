using Newtonsoft.Json;
using System;

namespace PaironsTech.ClickUpAPI.V1.Requests
{

    /// <summary>
    /// Request object for method CreateList()
    /// </summary>
    public class RequestCreateList : Request
    {

        /// <summary>
        /// Name of the new list
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// Constructor of RequestCreateList
        /// </summary>
        /// <param name="name">name of the new list [Obligatory]</param>
        public RequestCreateList(string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentException("name can't be empty or null!");

            Name = name;
        }

    }

}
