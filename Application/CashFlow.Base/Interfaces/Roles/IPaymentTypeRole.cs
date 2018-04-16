using System;
using System.Linq;
using CashFlow.Base.Models;

namespace CashFlow.Base.Interfaces
{
    public interface IPaymentTypeRole
    {
        IQueryable<PaymentType> PaymentTypes();
        bool ValidPaymentType(Guid paymentTypeId);
        bool ValidPaymentType(string paymentTypeName);
    }
}