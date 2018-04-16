using CashFlow.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Base.Models
{
    public partial class Role
    {
        [Key]
        public System.Guid RoleId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
