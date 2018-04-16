using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Base.Interfaces
{
    public interface ITransactionHandler : IHandler<Transaction>
    {
        IQueryable<Transaction> TransactionsByDate(DateTime startDate, DateTime endDate, int? limit = null);
    }
}
