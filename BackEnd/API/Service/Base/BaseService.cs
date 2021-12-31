using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Base
{
    public interface IBaseService<T> where T : class
    {
        PageModel<T> Paging(PageParameter pagePara, Expression<Func<T, bool>> expression);
        IQueryable<T> getAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T Entity);
        void CreateMany(List<T> lst);
        void Update(T Entity);
        void Delete(T Entity);
        void DeleteMany(List<T> lst);
        void Save();

        T FinbyId(Expression<Func<T, bool>> expression);
    }
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly MyContext dbcontex;

        public BaseService(MyContext _dbcontext)
        {
            dbcontex = _dbcontext;
        }

        public MyContext context
        {
            get { return dbcontex; }
        }

        public virtual PageModel<T> Paging(PageParameter pagePara, Expression<Func<T, bool>> expression)
        {
            var result = new PageModel<T>();
            result.data = dbcontex.Set<T>().AsNoTracking().Where(expression).Skip(pagePara.PageSize * pagePara.Page - pagePara.PageSize).Take(pagePara.PageSize).ToList();
            result.cout = dbcontex.Set<T>().AsNoTracking().Count();
            result.TotalPage = result.cout % pagePara.PageSize == 0 ? result.cout / pagePara.PageSize : result.cout / pagePara.PageSize + 1;
            return result;
        }



        public virtual IQueryable<T> getAll()
        {
            return dbcontex.Set<T>().AsNoTracking();
        }



        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return dbcontex.Set<T>().Where(expression);
        }

        public virtual T FinbyId(Expression<Func<T, bool>> expression)
        {
            return dbcontex.Set<T>().AsNoTracking().FirstOrDefault(expression);
        }

        public virtual void Create(T Entity)
        {
            dbcontex.Set<T>().Add(Entity);
        }

        public virtual void CreateMany(List<T> lst)
        {
            dbcontex.Set<T>().AddRange(lst);
        }

        public virtual void Update(T Entity)
        {
            dbcontex.Set<T>().Update(Entity);
        }

        public virtual void Delete(T Entity)
        {
            dbcontex.Set<T>().Remove(Entity);
        }

        public virtual void DeleteMany(List<T> lst)
        {
            dbcontex.Set<T>().RemoveRange(lst);
        }

        public void Save()
        {
            dbcontex.SaveChanges();
        }

        
    }
}
