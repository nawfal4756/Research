using Research.Data.Model.Base;
using Research.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Service.Base
{
    public interface IService<T>
        where T : BaseEntity
    {
        Task<Response<List<T>>> GetAll();
        Task<Response<T>> GetById(int id);
        Task<Response<int>> Add(T entity);
        Task<Response<int>> Update(T entity);
        Task<Response<int>> Delete(int id);
    }
}
