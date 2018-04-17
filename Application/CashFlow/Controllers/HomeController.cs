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

            var datetimeToday = DateTime.Today;
            var startDateMonth = new DateTime(datetimeToday.Year, datetimeToday.Month, 1);
            
            return View(
                new HomeViewModel()
                {
                    TransactionsToday = 0,
                    ReceivedLast30Days = _transactionRole.TransactionsByDay(startDateMonth, datetimeToday).ToString("C2"),
                    ReceivedToday = _transactionRole.TransactionsByDay(datetimeToday, datetimeToday).ToString("C2"),
                    LoggedUser = base.CurrentUser?.Role?.Active ?? false
                }
            );
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
