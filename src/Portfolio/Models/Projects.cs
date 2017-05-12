using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NuGet.Protocol.Core.v3;

namespace Portfolio.Models
{
    public class Projects
    {
        public static JArray GetProjects()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/users/" + EnvironmentVariables.UserName + "/repos", Method.GET);
            request.AddHeader("Accept", "application / vnd.github.v3 + json");
            request.AddHeader("User-Agent", EnvironmentVariables.UserName);

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray result = JsonConvert.DeserializeObject<JArray>(response.Content);

            return result;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
