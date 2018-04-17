using System;
using System.Linq;
using CashFlow.Base.Models;

namespace CashFlow.Base.Interfaces
{
    public interface IRoleRole
    {
        IQueryable<Base.Models.Role> Roles();
        bool ValidRole(Guid roleId);
        bool ValidRole(string roleName);
    }
}