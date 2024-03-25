using Microsoft.EntityFrameworkCore;
using Research.Data.Model;
using Research.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Repository.Context
{
    public class ResearchContext : BaseDbContext<ResearchContext>
    {
        public ResearchContext(DbContextOptions<ResearchContext> options) : base(options)
        {
            
        }

        public DbSet<Designations> Designations => Set<Designations>();
        public DbSet<Feature_Permissions> Feature_Permissions => Set<Feature_Permissions>();
        public DbSet<Reports> Reports => Set<Reports>();
        public DbSet<Security_Group_Feature_Permissions_Map> Security_Group_Feature_Permissions_Map => Set<Security_Group_Feature_Permissions_Map>();
        public DbSet<Security_Groups> Security_Groups => Set<Security_Groups>();
        public DbSet<Status> Status => Set<Status>();
        public DbSet<User_Report_Map> User_Report_Map => Set<User_Report_Map>();
        public DbSet<User_Security_Group_Map> User_Security_Group_Map => Set<User_Security_Group_Map>();
        public DbSet<Users> Users => Set<Users>();
    }
}
