using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Repository.Base
{
    public class BaseDbContext<T> : DbContext, IDbContext where T : DbContext
    {
        public BaseDbContext(DbContextOptions<T> options) : base(options)
        {

        }

        public DbContext GetDbContext()
        {
            return this;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> Commit()
        {
            return await base.SaveChangesAsync();
        }
    }
}
