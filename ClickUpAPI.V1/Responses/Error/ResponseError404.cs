using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Error
{

    /// <summary>
    /// Reponse Class of Error 404
    /// </summary>
    public class ResponseError404 : ResponseError
    {

        /// <summary>
        /// Message of the Error
        /// </summary>
        [JsonProperty("err")]
        public string Err { get; set; }

        /// <summary>
        /// Code of the Error
        /// </summary>
        [JsonProperty("ECODE")]
        public string ECode { get; set; }

    }

}
