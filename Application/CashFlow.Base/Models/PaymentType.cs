using CashFlow.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Base.Models
{
    public partial class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid PaymentTypeId { get; set; }
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}