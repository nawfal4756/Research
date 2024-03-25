using Research.Data.Model;
using Research.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Repository.Interface
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> Login(string email, string password);
    }
}
