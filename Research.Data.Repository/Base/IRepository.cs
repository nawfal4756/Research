using Research.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Repository.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> Commit();
    }
}
