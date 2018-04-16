using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Handler
{
    public class ResourceHandler : BaseHandler<Resource>, IResourceHandler
    {
        public ResourceHandler(CashFlowContext cashFlowContext)
            :base(cashFlowContext)
        {

        }

        public override Resource Find(Guid? id, bool includeRelatedEntities = true)
        {
            if (includeRelatedEntities)
            {
                return Context.Resource.Include("Role").Where(r=>r.ResourceId.Equals(id)).FirstOrDefault();
            }

            return Context.Resource.Find(id);
        }

        public override IQueryable<Resource> All()
        {
            return Context.Resource.Include("Role").AsQueryable();
        }
    }
}
