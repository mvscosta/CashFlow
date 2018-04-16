using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Handler
{
    public class PaymentTypeHandler : BaseHandler<PaymentType>, IPaymentTypeHandler
    {
        public PaymentTypeHandler(CashFlowContext cashFlowContext)
            :base(cashFlowContext)
        {

        }

        public override PaymentType Find(Guid? id, bool includeRelatedEntities = true)
        {
            return Context.PaymentType.Find(id);
        }

        public override IEnumerable<PaymentType> All()
        {
            return Context.PaymentType.ToList();
        }
    }
}
