using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashFlow.Base.Models;
using CashFlow.Base.Interfaces;

namespace CashFlow.Role
{
    public class PaymentTypeRole : IPaymentTypeRole
    {
        IPaymentTypeHandler _handler { get; set; }

        public PaymentTypeRole(IPaymentTypeHandler handler)
        {
            this._handler = handler;
        }

        public IQueryable<PaymentType> PaymentTypes()
        {
            return _handler.All().Where(pt=>pt.Active);
        }

        public bool ValidPaymentType(Guid paymentTypeId)
        {
            return (_handler.Find(paymentTypeId) ?? new PaymentType() { Active = false }).Active;
        }

        public bool ValidPaymentType(string paymentTypeName)
        {
            var pt = _handler.All().Where(r => r.Name == paymentTypeName);

            if (!pt.Any() || pt.Count() > 1)
                return false;
            else
            {
                return true;
            }
        }

    }
}
