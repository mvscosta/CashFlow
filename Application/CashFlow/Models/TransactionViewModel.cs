using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashFlow.Models
{
    public class TransactionViewModel
    {
        public Guid TransactionId { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string TransactionDateTime { get; set; }
        public string PaymentTypeName { get; set; }
        public string ResourceName { get; set; }
    }
}