using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashFlow.Models
{
    public class HomeViewModel
    {
        public int TransactionsToday { get; set; }
        public string ReceivedToday { get; set; }
        public string ReceivedLast30Days { get; set; }
        public bool AuthorizedUser { get; set; }
        public bool LoggedUser { get; set; }
    }
}