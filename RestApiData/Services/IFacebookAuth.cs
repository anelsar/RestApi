using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiData.Services
{
    public interface IFacebookAuth
    {
        Task<string> GetCode();
        string GetAccessToken(string code);
    }
}
