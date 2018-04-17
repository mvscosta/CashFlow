using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using CashFlow.Models;
using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using CashFlow.Role;

namespace CashFlow.Controllers
{
    public class HomeController : BaseController<Transaction>
    {
        private IResourceHandler _resourceHandler { get; set; }
        private ITransactionRole _transactionRole { get; set; }

        public HomeController(IResourceHandler resourceHandler, ITransactionHandler handler, ITransactionRole transactionRole)
            : base(resourceHandler, handler)
        {
            this._resourceHandler = resourceHandler;
            this._transactionRole = transactionRole;
        }

        internal override void LoadViewBag()
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Cash Flow, welcome!";

            var viewModel = new HomeViewModel()
            {
                LoggedUser = !string.IsNullOrEmpty(base.CurrentUser.Username),
                AuthorizedUser = base.CurrentUser.Role?.Active ?? false
            };

            if (viewModel.AuthorizedUser)
            {
                var datetimeToday = DateTime.Today;

                viewModel.TransactionsToday = _transactionRole.TransactionsCountByDay(datetimeToday);
                viewModel.ReceivedLast30Days = _transactionRole.TransactionsAmountLast30Days(datetimeToday)?.ToString("C2");
                viewModel.ReceivedToday = _transactionRole.TransactionsAmountByDay(datetimeToday)?.ToString("C2");
            }

            return View(viewModel);
        }

        public ActionResult AddTransaction()
        {
            return RedirectToAction("Create", "Transaction");
        }

        [Authorize]
        public ActionResult Claims()
        {
            Claim displayName = ClaimsPrincipal.Current.FindFirst(ClaimsPrincipal.Current.Identities.First().NameClaimType);
            ViewBag.DisplayName = displayName != null ? displayName.Value : string.Empty;
            return View();
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
