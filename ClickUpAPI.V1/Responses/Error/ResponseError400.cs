using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Error
{

    /// <summary>
    /// Response class of Error 400
    /// </summary>
    public class ResponseError400 : ResponseError
    {

        /// <summary>
        /// Message of the error
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
