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
        public async Task<string> GetCode()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.facebook.com/v12.0/dialog/oauth?client_id=961051304491808&redirect_uri=https%3A%2F%2Flocalhost%3A44334%2F&state=xyzABC123");
            var response = await _httpClient.SendAsync(request);
            
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                return dataObjects;
            }
            return null;
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
                
                Debug.WriteLine(jsonObj.AccessToken);
                return jsonObj.AccessToken;
            }
            return null;
        }
    }
}
