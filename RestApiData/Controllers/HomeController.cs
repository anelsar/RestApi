using Microsoft.AspNetCore.Mvc;
using RestApiData.Models;
using RestApiData.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestApiData.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        
        private readonly IFacebookAuth _facebookAuth;
        private readonly IFacebookServices _facebookServices;
        private AccesToken _accessToken;
        private RootInfo _rootInfo;
        
        public HomeController(IFacebookAuth facebookAuth, IFacebookServices facebookServices, AccesToken accessToken, RootInfo rootInfo)
        {
            _facebookAuth = facebookAuth;
            _facebookServices = facebookServices;
            _accessToken = accessToken;
            _rootInfo = rootInfo;
        }

        public  IActionResult Index()
        {          
           
            string code =  Request.Query["code"]; // getting the access code after the login, we need it for the access token
          
            if (code!=null)
            {
                // using the access code to get the access token
                 _accessToken.AccessToken = _facebookAuth.GetAccessToken(code);
                // after fully authenticated, getting the user information from the currently signed user
                 _rootInfo = _facebookServices.GetMyUserInfo(_accessToken.AccessToken);
            }           
            return View("Index", _rootInfo);
        }

        public IActionResult SaveData(RootInfo model)
        {
            // Saving the data that we got frome the API (changed or original) to the .json file
            var obj = JsonConvert.SerializeObject(model, Formatting.Indented);
            string filePath = @"..\RestApiData\JsonDb\json.json";
            System.IO.File.WriteAllText(filePath, obj);
            return View("SaveDataView");
        }
        public IActionResult About()
        {
            return View("About");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
