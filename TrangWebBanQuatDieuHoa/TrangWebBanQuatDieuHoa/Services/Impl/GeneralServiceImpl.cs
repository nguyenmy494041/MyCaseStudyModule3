using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Services.Impl
{
    
    public abstract class GeneralServiceImpl<TEntity, TRepository> where TEntity : class where TRepository : IGeneralRepository<TEntity>
    {
        private readonly TRepository repository;

        public GeneralServiceImpl(TRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
           return await repository.Add(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await repository.Update(entity);
        }

        public async Task<TEntity> Get(int id)
        {
            return await repository.Get(id);
        }

        public async Task<TEntity> Delete(int id)
        {
            return await repository.Delete(id);
        }

    }
}
