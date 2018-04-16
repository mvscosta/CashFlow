using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Handler
{
    public class TransactionHandler : BaseHandler<Transaction>, ITransactionHandler
    {
        public TransactionHandler(CashFlowContext cashFlowContext)
            :base(cashFlowContext)
        {

        }

        public override Transaction Find(Guid? id, bool includeRelatedEntities = true)
        {
            return Context.Transaction.Find(id);
        }

        public override IEnumerable<Transaction> All()
        {
            return Context.Transaction.ToList();
        }
    }
}
