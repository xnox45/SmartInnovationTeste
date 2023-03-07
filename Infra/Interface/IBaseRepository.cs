using System.Linq.Expressions;

namespace Infra.Interface
{
    public interface IBaseRepository <TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);

        TEntity Create(TEntity entity);

        bool Update(TEntity model);

        TEntity? Find(Expression<Func<TEntity, bool>> where);

        List<TEntity>? FindAll(Expression<Func<TEntity, bool>> where);

        TEntity? FindById(int id);

        bool Delete(TEntity model);
    }
}
