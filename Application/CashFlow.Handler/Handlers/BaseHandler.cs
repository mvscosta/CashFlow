using CashFlow.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Handler
{
    public abstract class BaseHandler<T> : IDisposable where T : class
    {
        protected CashFlowContext Context { get; private set; }

        public BaseHandler(CashFlowContext cashFlowContext)
        {
            this.Context = cashFlowContext;
        }
        
        public abstract T Find(Guid? id, bool includeRelatedEntities = true);
        public abstract IQueryable<T> All();

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var set = Context.Set<T>();
            var entity = set.Find(id);
            set.Remove(entity);
            Context.SaveChanges();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
