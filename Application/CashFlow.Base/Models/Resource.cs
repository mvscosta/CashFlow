using CashFlow.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Base.Models
{
    public partial class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid ResourceId { get; set; }
        public bool Active { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [ForeignKey("Role")]
        public Guid? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
