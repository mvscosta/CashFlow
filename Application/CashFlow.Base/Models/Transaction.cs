using CashFlow.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Base.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid TransactionId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Nullable<decimal> Amount { get; set; }
        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [ForeignKey("PaymentType")]
        [DisplayName("Payment Type")]
        [Required(ErrorMessage = "Must Choose a Payment Type")]
        public System.Guid PaymentTypeId { get; set; }
        [Required]
        [ForeignKey("Resource")]
        [DisplayName("Created By")]
        public System.Guid ResourceId { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
