using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using CashFlow.Models;
using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;

namespace CashFlow.Controllers
{
    public class HomeController : BaseController<Transaction>
    {
        public HomeController(IResourceHandler resourceHandler, ITransactionHandler handler)
            : base(resourceHandler, handler)
        {

        }

        internal override void LoadViewBag()
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Cash Flow, welcome!";

            return View(
                new HomeViewModel()
                {
                    TransactionsToday = 0,
                    LoggedUser = base.CurrentUser != null
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
