using Newtonsoft.Json;
using RestApiData.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestApiData.Services
{
    public class FacebookServices : IFacebookServices
    {
        private HttpClient _httpClient;

        public FacebookServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public RootInfo GetMyUserInfo(string AccessToken)
        {
            
            _httpClient.BaseAddress = new Uri("https://graph.facebook.com/");
            HttpResponseMessage response = _httpClient.GetAsync($"me?metadata=1&access_token={AccessToken}").Result;
            if(response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<RootInfo>(dataObjects);
                Debug.WriteLine(model.Metadata.Fields);
                return model;
            }
            return null;
        }
    }
}
