using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestApiData.Models;
using RestApiData.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiData.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _myConfiguration;

        public LoginController(IConfiguration myConfiguration)
        {
            _myConfiguration = myConfiguration;
        }
        public IActionResult Index()
        {      
            // redirecting to the facebook login page
            return Redirect($"https://www.facebook.com/v12.0/dialog/oauth?client_id={_myConfiguration["MyConfiguration:ClientId"]}&redirect_uri={_myConfiguration["MyConfiguration:RedirectUri"]}&state=xyzABC123");
        }
        
    }
}
