using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.OptionalParams;
using PaironsTech.ClickUpAPI.V1.Requests;
using PaironsTech.ClickUpAPI.V1.Responses;
using PaironsTech.ClickUpAPI.V1.Responses.Error;
using PaironsTech.ClickUpAPI.V1.Responses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaironsTech.ClickUpAPI.V1
{
    public class ClickUpAPI
    {
        
        // Private Static Attributes 
        private static readonly Uri _baseAddress = new Uri("https://api.clickup.com/api/v1/");


        // Private Attributes
        private string _accessToken { get; set; }


        // Constructors

        /// <summary>
        /// Create object with Personal Access Token
        /// </summary>
        /// <param name="accessToken">Personal Access Token</param>
        public ClickUpAPI(string accessToken)
        {
            _accessToken = accessToken;
        }

        /// <summary>
        /// Create Object with ClientId, ClientSecrect
        /// </summary>
        /// <param name="clientId">own clientId</param>
        /// <param name="clientSecret">own clientSecret</param>
        public ClickUpAPI(string clientId, string clientSecret, string code)
        {
            string requestUri = "oauth/token?client_id=" + clientId + "&client_secret=" + clientSecret + "&code=" + code;

            // Execute Async call, wait response, get access Token and set in private attribute
            Task.Run(async () =>
            {
                Response response = await ExecutePostCallAsync<ResponseAccessToken>(requestUri, null);

                if (response is ResponseAccessToken responseAccessToken)
                    _accessToken = responseAccessToken.AccessToken;

            }).Wait();
        }



        #region API Methods


        /// <summary>
        /// Get the user that belongs to this token
        /// </summary>
        /// <returns>ResponseAuthorizedUser object expected</returns>
        public Response GetAuthorizedUser()
        {
            string requestUri = "user";

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecuteGetCallAsync<ResponseAuthorizedUser>(requestUri);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Get the authorized teams for this token
        /// </summary>
        /// <returns>ResponseAuthorizedTeams expected</returns>
        public Response GetAuthorizedTeams()
        {
            string requestUri = "team";

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecuteGetCallAsync<ResponseAuthorizedTeams>(requestUri);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Get a team's details. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseTeam object expected</returns>
        public Response GetTeamByID(string teamId)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string requestUri = "team/" + teamId;

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecuteGetCallAsync<ResponseTeam>(requestUri);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Get a team's spaces. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseTeamSpace object expected</returns>
        public Response GetTeamSpace(string teamId)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string requestUri = "team/" + teamId + "/space";

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecuteGetCallAsync<ResponseTeamSpace>(requestUri);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Get a space's projects. The projects' lists will also be included.
        /// </summary>
        /// <param name="spaceId">spaceId</param>
        /// <returns>ResponseSpaceProjects object expected</returns>
        public Response GetSpaceProjects(string spaceId)
        {
            if (string.IsNullOrEmpty(spaceId)) throw new ArgumentException("spaceId can't be empty or null!");

            string requestUri = "space/" + spaceId + "/project";

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecuteGetCallAsync<ResponseSpaceProjects>(requestUri);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Create List in Project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="requestData">RequestCreateList object</param>
        /// <returns>ModelList object expected</returns>
        public Response CreateList(string projectId, RequestCreateList requestData)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("projectId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "project/" + projectId + "/list";

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecutePostCallAsync<ModelList>(requestUri, requestData);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Edit List informations
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestEditList object</param>
        /// <returns>ModelList object expected</returns>
        public Response EditList(string listId, RequestEditList requestData)
        {
            if (string.IsNullOrEmpty(listId)) throw new ArgumentException("listId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "list/" + listId;

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecutePutCallAsync<ModelList>(requestUri, requestData);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Get Tasks of the Team and filter its by optionalParams
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <param name="optionalParams">OptionalParamsGetTask object</param>
        /// <returns>ResponseTasks object expected</returns>
        public Response GetTasks(string teamId, OPGetTasks optionalParams)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string strParams = GenerateOptionalParams(optionalParams);
            string requestUri = "team/" + teamId + "/task" + (!string.IsNullOrEmpty(strParams) ? "?" + strParams : string.Empty);

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecuteGetCallAsync<ResponseTasks>(requestUri);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Create Task in List.
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestCreateTaskInList object</param>
        /// <returns>ModelTask object Expected</returns>
        public Response CreateTaskInList(string listId, RequestCreateTaskInList requestData)
        {
            if (string.IsNullOrEmpty(listId)) throw new ArgumentException("listId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "list/" + listId + "/task";

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecutePostCallAsync<ModelTask>(requestUri, requestData);
            })
            .Wait();

            return response;
        }

        /// <summary>
        /// Edit Task informations.
        /// </summary>
        /// <param name="taskId">taskId</param>
        /// <param name="requestData">RequestEditTask object</param>
        /// <returns>ResponseSuccess object expected</returns>
        public Task<Response> EditTaskAsync(string taskId, RequestEditTask requestData)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("taskId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "task/" + taskId;

            Response response = null;
            Task.Run(async () =>
            {
                response = await ExecutePutCallAsync<ResponseSuccess>(requestUri, requestData);
            })
            .Wait();

            return response;
        }


        #endregion


        #region API Methods Async


        /// <summary>
        /// Get the user that belongs to this token
        /// </summary>
        /// <returns>ResponseAuthorizedUser object expected</returns>
        public Task<Response> GetAuthorizedUserAsync()
        {
            string requestUri = "user";
            return ExecuteGetCallAsync<ResponseAuthorizedUser>(requestUri);
        }

        /// <summary>
        /// Get the authorized teams for this token
        /// </summary>
        /// <returns>ResponseAuthorizedTeams expected</returns>
        public Task<Response> GetAuthorizedTeamsAsync()
        {
            string requestUri = "team";
            return ExecuteGetCallAsync<ResponseAuthorizedTeams>(requestUri);
        }

        /// <summary>
        /// Get a team's details. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseTeam object expected</returns>
        public Task<Response> GetTeamByIDAsync(string teamId)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string requestUri = "team/" + teamId;
            return ExecuteGetCallAsync<ResponseTeam>(requestUri);
        }

        /// <summary>
        /// Get a team's spaces. This team must be one of the authorized teams for this token.
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns>ResponseTeamSpace object expected</returns>
        public Task<Response> GetTeamSpacesAsync(string teamId)
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string requestUri = "team/" + teamId + "/space";
            return ExecuteGetCallAsync<ResponseTeamSpace>(requestUri);
        }

        /// <summary>
        /// Get a space's projects. The projects' lists will also be included.
        /// </summary>
        /// <param name="spaceId">spaceId</param>
        /// <returns>ResponseSpaceProjects object expected</returns>
        public Task<Response> GetSpaceProjectsAsync(string spaceId)
        {
            if (string.IsNullOrEmpty(spaceId)) throw new ArgumentException("spaceId can't be empty or null!");

            string requestUri = "space/" + spaceId + "/project";
            return ExecuteGetCallAsync<ResponseSpaceProjects>(requestUri);
        }

        /// <summary>
        /// Create List in Project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="requestData">RequestCreateList object</param>
        /// <returns>ModelList object expected</returns>
        public Task<Response> CreateListAsync(string projectId, RequestCreateList requestData)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("projectId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "project/" + projectId + "/list";
            return ExecutePostCallAsync<ModelList>(requestUri, requestData);
        }

        /// <summary>
        /// Edit List informations
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestEditList object</param>
        /// <returns>ModelList object expected</returns>
        public Task<Response> EditListAsync(string listId, RequestEditList requestData)
        {
            if (string.IsNullOrEmpty(listId)) throw new ArgumentException("listId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");
            
            string requestUri = "list/" + listId;
            return ExecutePutCallAsync<ModelList>(requestUri, requestData);
        }

        /// <summary>
        /// Get Tasks of the Team and filter its by optionalParams
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <param name="optionalParams">OptionalParamsGetTask object</param>
        /// <returns>ResponseTasks object expected</returns>
        public Task<Response> GetTasksAsync(string teamId, OPGetTasks optionalParams)    
        {
            if (string.IsNullOrEmpty(teamId)) throw new ArgumentException("teamId can't be empty or null!");

            string strParams = GenerateOptionalParams(optionalParams);
            string requestUri = "team/" + teamId + "/task" + (!string.IsNullOrEmpty(strParams) ? "?" + strParams : string.Empty);
            return ExecuteGetCallAsync<ResponseTasks>(requestUri);
        }

        /// <summary>
        /// Create Task in List.
        /// </summary>
        /// <param name="listId">listId</param>
        /// <param name="requestData">RequestCreateTaskInList object</param>
        /// <returns>ModelTask object Expected</returns>
        public Task<Response> CreateTaskInListAsync(string listId, RequestCreateTaskInList requestData)
        {
            if (string.IsNullOrEmpty(listId)) throw new ArgumentException("listId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");

            string requestUri = "list/" + listId + "/task";
            return ExecutePostCallAsync<ModelTask>(requestUri, requestData);
        }

        /// <summary>
        /// Edit Task informations.
        /// </summary>
        /// <param name="taskId">taskId</param>
        /// <param name="requestData">RequestEditTask object</param>
        /// <returns>ResponseSuccess object expected</returns>
        public Task<Response> EditTaskAsync(string taskId, RequestEditTask requestData)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("taskId can't be empty or null!");
            if (requestData == null) throw new ArgumentException("requestData can't be empty or null!");
            string requestUri = "task/" + taskId;
            return ExecutePutCallAsync<ResponseSuccess>(requestUri, requestData);
        }


        #endregion


        #region Private Methods


        /****************************
         * 
         *  Manage Optional Params
         * 
         ***************************/

        private string GenerateOptionalParams(OptionalParams.OptionalParams optionalParams)
        {
            List<string> listParamKeyValue = new List<string>();
            PropertyInfo[] props = optionalParams.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object value = prop.GetValue(optionalParams);

                if (value != null)
                    listParamKeyValue.Add(SerializePropName(prop) + "=" + SerializePropValue(prop, value));
            }
            
            return string.Join("&", listParamKeyValue);
        }

        private string SerializePropName(PropertyInfo prop)
        {
            List<JsonPropertyAttribute> attrsJsonProperty = prop.GetCustomAttributes<JsonPropertyAttribute>(true).ToList();
            if (attrsJsonProperty.Count > 0) return attrsJsonProperty[0].PropertyName;
            return prop.Name;
        }

        private string SerializePropValue(PropertyInfo prop, object value)
        {
            if (value is DateTime dateTime) return new DateTimeOffset(((DateTime)value)).ToUnixTimeMilliseconds().ToString();
            if (value is TimeSpan timeSpan) return timeSpan.TotalMilliseconds.ToString();

            return value.ToString();
        }



        /*********************************
         * 
         *  Manage Response and Request
         * 
         ********************************/

        private Response ManageResponses<TResponse>(HttpStatusCode httpStatusCode, string responseData) where TResponse : Response
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.Accepted: throw new NotImplementedException();
                case HttpStatusCode.AlreadyReported: throw new NotImplementedException();
                case HttpStatusCode.Ambiguous: throw new NotImplementedException();
                case HttpStatusCode.BadGateway: throw new NotImplementedException();
                case HttpStatusCode.BadRequest: return DeserializeResponse<ResponseError400>(responseData);
                case HttpStatusCode.Conflict: throw new NotImplementedException();
                case HttpStatusCode.Continue: throw new NotImplementedException();
                case HttpStatusCode.Created: throw new NotImplementedException();
                case HttpStatusCode.EarlyHints: throw new NotImplementedException();
                case HttpStatusCode.ExpectationFailed: throw new NotImplementedException();
                case HttpStatusCode.FailedDependency: throw new NotImplementedException();
                case HttpStatusCode.Forbidden: throw new NotImplementedException();
                case HttpStatusCode.Found: throw new NotImplementedException();
                case HttpStatusCode.GatewayTimeout: throw new NotImplementedException();
                case HttpStatusCode.Gone: throw new NotImplementedException();
                case HttpStatusCode.HttpVersionNotSupported: throw new NotImplementedException();
                case HttpStatusCode.IMUsed: throw new NotImplementedException();
                case HttpStatusCode.InsufficientStorage: throw new NotImplementedException();
                case HttpStatusCode.InternalServerError: throw new NotImplementedException();
                case HttpStatusCode.LengthRequired: throw new NotImplementedException();
                case HttpStatusCode.Locked: throw new NotImplementedException();
                case HttpStatusCode.LoopDetected: throw new NotImplementedException();
                case HttpStatusCode.MethodNotAllowed: throw new NotImplementedException();
                case HttpStatusCode.MisdirectedRequest: throw new NotImplementedException();
                case HttpStatusCode.Moved: throw new NotImplementedException();
                case HttpStatusCode.MultiStatus: throw new NotImplementedException();
                case HttpStatusCode.NetworkAuthenticationRequired: throw new NotImplementedException();
                case HttpStatusCode.NoContent: throw new NotImplementedException();
                case HttpStatusCode.NonAuthoritativeInformation: throw new NotImplementedException();
                case HttpStatusCode.NotAcceptable: throw new NotImplementedException();
                case HttpStatusCode.NotExtended: throw new NotImplementedException();
                case HttpStatusCode.NotFound: return DeserializeResponse<ResponseError404>(responseData);
                case HttpStatusCode.NotImplemented: throw new NotImplementedException();
                case HttpStatusCode.NotModified: throw new NotImplementedException();
                case HttpStatusCode.OK: return DeserializeResponse<TResponse>(responseData);
                case HttpStatusCode.PartialContent: throw new NotImplementedException();
                case HttpStatusCode.PaymentRequired: throw new NotImplementedException();
                case HttpStatusCode.PermanentRedirect: throw new NotImplementedException();
                case HttpStatusCode.PreconditionFailed: throw new NotImplementedException();
                case HttpStatusCode.PreconditionRequired: throw new NotImplementedException();
                case HttpStatusCode.Processing: throw new NotImplementedException();
                case HttpStatusCode.ProxyAuthenticationRequired: throw new NotImplementedException();
                case HttpStatusCode.RedirectKeepVerb: throw new NotImplementedException();
                case HttpStatusCode.RedirectMethod: throw new NotImplementedException();
                case HttpStatusCode.RequestedRangeNotSatisfiable: throw new NotImplementedException();
                case HttpStatusCode.RequestEntityTooLarge: throw new NotImplementedException();
                case HttpStatusCode.RequestHeaderFieldsTooLarge: throw new NotImplementedException();
                case HttpStatusCode.RequestTimeout: throw new NotImplementedException();
                case HttpStatusCode.RequestUriTooLong: throw new NotImplementedException();
                case HttpStatusCode.ResetContent: throw new NotImplementedException();
                case HttpStatusCode.ServiceUnavailable: throw new NotImplementedException();
                case HttpStatusCode.SwitchingProtocols: throw new NotImplementedException();
                case HttpStatusCode.TooManyRequests: throw new NotImplementedException();
                case HttpStatusCode.Unauthorized: return DeserializeResponse<ResponseError401>(responseData);
                case HttpStatusCode.UnavailableForLegalReasons: throw new NotImplementedException();
                case HttpStatusCode.UnprocessableEntity: throw new NotImplementedException();
                case HttpStatusCode.UnsupportedMediaType: throw new NotImplementedException();
                case HttpStatusCode.Unused: throw new NotImplementedException();
                case HttpStatusCode.UpgradeRequired: throw new NotImplementedException();
                case HttpStatusCode.UseProxy: throw new NotImplementedException();
                case HttpStatusCode.VariantAlsoNegotiates: throw new NotImplementedException();

                default: throw new NotImplementedException();
            }
        }

        private TResponse DeserializeResponse<TResponse>(string responseData) where TResponse : Response
        {
            return JsonConvert.DeserializeObject<TResponse>(responseData);
        }

        private async Task<Response> ExecuteGetCallAsync<TResponseExpected>(string requestUri) where TResponseExpected : Response
        {
            Response response = null;

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", _accessToken);

                using (var httpResponse = await httpClient.GetAsync(requestUri))
                {
                    string responseData = await httpResponse.Content.ReadAsStringAsync();
                    response = ManageResponses<TResponseExpected>(httpResponse.StatusCode, responseData);
                }
            }

            return response;
        }

        private async Task<Response> ExecutePostCallAsync<TResponseExpected>(string requestUri, Request request) where TResponseExpected : Response
        {
            Response response = null;

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", _accessToken);

                using (var content = request != null ? new StringContent(JsonConvert.SerializeObject(request), Encoding.Default, "application/json") : new StringContent("{}", Encoding.Default, "application/json"))
                {
                    using (var httpResponse = await httpClient.PostAsync(requestUri, content))
                    {
                        string responseData = await httpResponse.Content.ReadAsStringAsync();
                        response = ManageResponses<TResponseExpected>(httpResponse.StatusCode, responseData);
                    }
                }
            }

            return response;
        }

        private async Task<Response> ExecutePutCallAsync<TResponseExpected>(string requestUri, Request request) where TResponseExpected : Response
        {
            Response response = null;

            using (var httpClient = new HttpClient { BaseAddress = _baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", _accessToken);

                using (var content = request != null ? new StringContent(JsonConvert.SerializeObject(request), Encoding.Default, "application/json") : new StringContent("{}", Encoding.Default, "application/json"))
                {
                    using (var httpResponse = await httpClient.PutAsync(requestUri, content))
                    {
                        string responseData = await httpResponse.Content.ReadAsStringAsync();
                        response = ManageResponses<TResponseExpected>(httpResponse.StatusCode, responseData);
                    }
                }
            }

            return response;
        }

        #endregion

    }
}
