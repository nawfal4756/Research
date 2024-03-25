﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Repository.Base
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        public Task<int> Commit();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbContext GetDbContext();
    }
}
