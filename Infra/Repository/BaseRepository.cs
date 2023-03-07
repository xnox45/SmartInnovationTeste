using Infra.DataContext;
using Infra.Entities;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        protected readonly CadastroContext _context;

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public BaseRepository(CadastroContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return DbSet.AsNoTracking().Where(where);
            }
            catch
            {
                throw;
            }
        }

        public TEntity? Find(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(where);
            }
            catch
            {
                throw;
            }
        }

        public TEntity? FindById(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity>? FindAll(Expression<Func<TEntity, bool>> where) => DbSet.AsNoTracking().Where(where).ToList();

        public TEntity Create(TEntity entity)
        {
            if (entity is BaseEntity)
            {
                (entity as BaseEntity).CreationDate = DateTime.Now;
            }

            DbSet.Add(entity);

            Save();

            return entity;
        }

        public bool Update(TEntity model)
        {
            try
            {
                if (model is BaseEntity)
                {
                    (model as BaseEntity).UpdateDate = DateTime.Now;
                }

                var entry = _context.Entry(model);

                DbSet.Attach(model);

                entry.State = EntityState.Modified;

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Delete(TEntity model)
        {
            try
            {
                if (model is BaseEntity)
                {
                    (model as BaseEntity).IsDeleted = true;

                    var _entry = _context.Entry(model);

                    DbSet.Attach(model);

                    _entry.State = EntityState.Modified;
                }
                else
                {
                    var _entry = _context.Entry(model);
                    DbSet.Attach(model);
                    _entry.State = EntityState.Deleted;
                }

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (_context != null)
                    _context.Dispose();

                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
