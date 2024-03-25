using Research.Data.Model.Base;
using Research.Data.Repository.Base;
using Research.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Service.Base
{
    public class BaseService<TEntity, TRepo>
        where TEntity : BaseEntity
        where TRepo : IRepository<TEntity>
    {
        private readonly IRepository<TEntity> _repo;
        public BaseService(TRepo repo)
        {
            _repo = repo;
        }

        public virtual async Task<Response<List<TEntity>>> GetAll()
        {
            var items = await _repo.GetAll();
            if (!items.Any())
            {
                return new Response<List<TEntity>>()
                {
                    Success = false,
                    Message = "No items found"
                };
            }

            return new Response<List<TEntity>>()
            {
                Success = true,
                Message = $"{items.Count} Items found",
                Data = items
            };
        }

        public virtual async Task<Response<TEntity>> GetById(int id)
        {
            var item = await _repo.GetById(id);
            if (item == null)
            {
                return new Response<TEntity>()
                {
                    Success = false,
                    Message = $"Item with id {id} not found"
                };
            }

            return new Response<TEntity>()
            {
                Success = true,
                Message = $"Item with id {id} found",
                Data = item
            };
        }

        public virtual async Task<Response<int>> Add(TEntity entity)
        {
            _repo.Insert(entity);
            var result = await _repo.Commit();
            if (result == 0)
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = $"Item not inserted"
                };
            }

            return new Response<int>()
            {
                Success = true,
                Message = $"Item inserted",
                Data = entity.id
            };
        }

        public virtual async Task<Response<int>> Update(TEntity entity)
        {
            _repo.Update(entity);
            var result = await _repo.Commit();
            if (result == 0)
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = $"Item not updated"
                };
            }

            return new Response<int>()
            {
                Success = true,
                Message = $"Item updated",
                Data = entity.id
            };
        }

        public virtual async Task<Response<int>> Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if (entity == null)
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = $"Item with id {id} not found"
                };
            }
            _repo.Delete(entity);
            var result = await _repo.Commit();
            if (result == 0)
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = $"Item not deleted"
                };
            }

            return new Response<int>()
            {
                Success = true,
                Message = $"Item deleted",
                Data = entity.id
            };
        }
    }
}
