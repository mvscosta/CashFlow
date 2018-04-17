using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CashFlow.Handler
{
    public class TransactionHandler : BaseHandler<Transaction>, ITransactionHandler
    {
        public TransactionHandler(CashFlowContext cashFlowContext)
            : base(cashFlowContext)
        {

        }

        public override Transaction Find(Guid? id, bool includeRelatedEntities = true)
        {
            if (includeRelatedEntities)
            {
                return Context.Transaction
                    .Include("Resource")
                    .Include("PaymentType")
                    .Where(pt => pt.TransactionId.Equals(id.Value))
                    .FirstOrDefault();
            }

            return Context.Transaction.Find(id);
        }

        public override IQueryable<Transaction> All()
        {
            return Context.Transaction.AsQueryable();
        }

        public IQueryable<Transaction> TransactionsByDate(DateTime startDate, DateTime endDate, int? limit = null)
        {
            var query = Context.Transaction.Where(
                t => DbFunctions.TruncateTime(t.TransactionDate) >= DbFunctions.TruncateTime(startDate)
                && DbFunctions.TruncateTime(t.TransactionDate) <= DbFunctions.TruncateTime(endDate));

            if (limit.HasValue)
            {
                query = query.Take(limit.Value);
            }

            return query;
        }
    }
}
