using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of List information response
    /// </summary>
    public class ModelList : Model
    {

        /// <summary>
        /// Id of the List
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the List
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

    }

}
