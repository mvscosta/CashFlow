using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Base.Interfaces
{
    public interface IHandler<T> where T : class
    {
        void Add(T _item);
        void Update(T _item);
        void Delete(Guid id);
        T Find(Guid? id, bool includeRelatedEntities = true);
        IEnumerable<T> All();
        void Save();
        void Dispose();
    }
}
