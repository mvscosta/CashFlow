using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashFlow.Base.Models;
using CashFlow.Base.Interfaces;

namespace CashFlow.Role
{
    public class RoleRole : IRoleRole
    {
        IRoleHandler _handler { get; set; }

        public RoleRole(IRoleHandler handler)
        {
            this._handler = handler;
        }

        public IQueryable<Base.Models.Role> Roles()
        {
            return _handler.All().Where(pt=>pt.Active);
        }

        public bool ValidRole(Guid roleId)
        {
            return (_handler.Find(roleId) ?? new Base.Models.Role() { Active = false }).Active;
        }

        public bool ValidRole(string roleName)
        {
            var pt = _handler.All().Where(r => r.Name == roleName);

            if (!pt.Any() || pt.Count() > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
