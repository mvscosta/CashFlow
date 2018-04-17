﻿using System;
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

        public int TransactionsByDay(DateTime startDate, DateTime endDate, int? limit = null)
        {
            return _handler.TransactionsByDate(startDate, endDate, limit).Count();
        }
    }
}
