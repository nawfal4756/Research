using Microsoft.EntityFrameworkCore;
using Research.Data.Model;
using Research.Data.Repository.Base;
using Research.Data.Repository.Context;
using Research.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Repository.Repositories
{
    public class UserRepository : BaseRepository<Users, ResearchContext>, IUserRepository
    {
        private readonly DbSet<Users> Users;

        public UserRepository(ResearchContext context) : base(context)
        {
            Users = context.Users;
        }

        public async Task<Users> Login(string email, string password)
        {
            return await Users
                            .Include(x => x.User_Security_Groups)
                            .ThenInclude(x => x.Security_Group)
                            .ThenInclude(x => x.Security_Group_Feature_Permissions)
                            .ThenInclude(x => x.Feature_Permissions)
                            .FirstOrDefaultAsync(x => x.User_Email.Equals(email) && x.User_Password.Equals(password));
        }

        public override async Task<Users> GetById(int id)
        {
            return await Users
                            .Include(x => x.User_Security_Groups)
                            .ThenInclude(x => x.Security_Group)
                            .ThenInclude(x => x.Security_Group_Feature_Permissions)
                            .ThenInclude(x => x.Feature_Permissions)
                            .FirstOrDefaultAsync(x => x.User_ID == id);
        }
    }
}
