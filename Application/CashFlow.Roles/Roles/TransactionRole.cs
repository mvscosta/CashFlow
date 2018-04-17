using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using CashFlow.Base.Interfaces;

namespace CashFlow.Role
{

    public class TransactionRole : ITransactionRole
    {
        ITransactionHandler _handler { get; set; }

        public TransactionRole(ITransactionHandler handler)
        {
            this._handler = handler;
        }

        public decimal? TransactionsAmountByDay(DateTime date)
        {
            return _handler.TransactionsByDate(date, date).Sum(t=>t.Amount);
        }
        public decimal? TransactionsAmountLast30Days(DateTime date)
        {
            return _handler.TransactionsByDate(date.AddDays(-30), date).Sum(t => t.Amount);
        }

        public int TransactionsCountByDay(DateTime date)
        {
            return _handler.TransactionsByDate(date, date).Count();
        }
    }
}
