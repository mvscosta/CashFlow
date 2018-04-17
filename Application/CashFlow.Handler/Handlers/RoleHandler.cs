using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Handler
{
    public class RoleHandler : BaseHandler<Base.Models.Role>, IRoleHandler
    {
        public RoleHandler(CashFlowContext cashFlowContext)
            :base(cashFlowContext)
        {

        }

        public override Base.Models.Role Find(Guid? id, bool includeRelatedEntities = true)
        {
            return Context.Role.Find(id);
        }

        public override IQueryable<Base.Models.Role> All()
        {
            return Context.Role.AsQueryable();
        }
    }
}
