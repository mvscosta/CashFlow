using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CashFlow.Models
{
    public class TransactionViewModel
    {
        [Key]
        public Guid TransactionId { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        [DisplayName("Transaction Date")]
        public DateTime TransactionDateTime { get; set; }
        [DisplayName("Payment Type")]
        public string PaymentTypeName { get; set; }
        [DisplayName("Resource")]
        public string ResourceName { get; set; }

        public string TransactionDateTimeString
        {
            get { return TransactionDateTime.ToString("MM/dd/yyyy HH:mm:ss"); }
        }
    }
}