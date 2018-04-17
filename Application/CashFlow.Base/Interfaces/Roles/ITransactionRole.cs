using System;

namespace CashFlow.Role
{
    public interface ITransactionRole
    {
        decimal? TransactionsAmountByDay(DateTime date);

        decimal? TransactionsAmountLast30Days(DateTime date);

        int TransactionsCountByDay(DateTime date);

    }
}