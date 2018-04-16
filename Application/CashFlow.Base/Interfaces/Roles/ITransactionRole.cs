using System;

namespace CashFlow.Role
{
    public interface ITransactionRole
    {
        int TransactionsByDay(DateTime date);
    }
}