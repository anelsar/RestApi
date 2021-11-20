using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RestApiData.Models;
using Microsoft.Extensions.Configuration;

namespace RestApiData.Services
{
    public class FacebookAuth : IFacebookAuth
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _myConfiguration;

        public FacebookAuth(HttpClient httpClient, IConfiguration myConfiguration)
        {
            _httpClient = httpClient;
            _myConfiguration = myConfiguration;
        }
        
        // Function for getting the user access token so we can authenticate the user and call facebook APIs
        public string GetAccessToken(string code)
        {
            _httpClient.BaseAddress = new Uri("https://graph.facebook.com/v12.0/oauth/");
            HttpResponseMessage response =  _httpClient.GetAsync($"access_token?client_id={_myConfiguration["MyConfiguration:ClientId"]}&redirect_uri={_myConfiguration["MyConfiguration:RedirectUri"]}&client_secret={_myConfiguration["MyConfiguration:ClientSecret"]}&code={code}").Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result; 
                var jsonObj = JsonConvert.DeserializeObject<AccesToken>(dataObjects);
                return jsonObj.AccessToken;
            }
            return null;
        }
    }
}
