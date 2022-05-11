using RetailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailAPI.Services
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateCredentials(AuthCredentials credentials);
        Task<string> CreateToken();
    }
}
