using System;

namespace CashFlow.Role
{
    public interface ITransactionRole
    {
        int TransactionsByDay(DateTime startDate, DateTime endDate, int? limit = null);
    }
}