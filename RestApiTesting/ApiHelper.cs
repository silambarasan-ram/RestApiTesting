using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace RestApiTesting
{
    public class ApiHelper
    {
        readonly string BaseUri = "https://reqres.in/";
        readonly string endPoint;

        public ApiHelper(string endPoint)
        {
            this.endPoint = endPoint;
        }

        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateDeleteRequest()
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse ExecuteAndGetResponse(RestRequest restRequest)
        {
            var ApiUri = Path.Combine(BaseUri, endPoint);
            var restClient = new RestClient(ApiUri);
            var restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public T GetContent<T>(IRestResponse restResponse)
        {
            var content = restResponse.Content;
            var jsonObject = JsonConvert.DeserializeObject<T>(content);
            return jsonObject;
        }
    }
}