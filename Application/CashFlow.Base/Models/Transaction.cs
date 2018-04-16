using CashFlow.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Base.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
        }

        [Key]
        public System.Guid TransactionId { get; set; }
        public string Description { get; set; }
        [Required]
        public Nullable<decimal> Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        [Required]
        public System.Guid PaymentTypeId { get; set; }
        [Required]
        public System.Guid ResourceId { get; set; }
    }
}
