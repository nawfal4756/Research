using Research.Data.Model;
using Research.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Service
{
    public interface IAuthService
    {
        Task<Response<LoginResponse>> Login(string email, string password);
        Task<Response<LoginResponse>> RefreshToken(string accessToken, string refreshToken);
    }
}
