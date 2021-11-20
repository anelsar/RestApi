using RestApiData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiData.Services
{
    public interface IFacebookServices
    {
        // Ovdje cemo imenovati pozive za neki API
        RootInfo GetMyUserInfo(string AccessToken);
    }
}
