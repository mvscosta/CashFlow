using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using CashFlow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CashFlow.Controllers
{
    [Authorize]
    public class TransactionController : BaseController<Transaction>
    {
        private IPaymentTypeRole _paymentTypeRole { get; set; }

        public TransactionController(IResourceHandler resourceHandler, IPaymentTypeRole paymentTypeRole, ITransactionHandler handler)
            : base(resourceHandler, handler)
        {
            this._paymentTypeRole = paymentTypeRole;
        }

        internal override void LoadViewBag()
        {
            var isManager = ResourcePermission("Manager");
            ViewBag.Disabled = ResourcePermission("Employee") || isManager ? "" : " disabled";
            ViewBag.AdmDisabled =  isManager ? "" : " disabled";
            ViewBag.PaymentTypes = new SelectList(
                _paymentTypeRole.PaymentTypes().Select(p => new { p.PaymentTypeId, p.Name })
                , "PaymentTypeId", "Name"
            );
        }

        // GET: Transaction
        public ActionResult Index()
        {
            LoadViewBag();

            var transactions = Handler
                .All()
                .Include("PaymentType")
                .Include("Resource")
                .OrderByDescending(r => r.TransactionDate)
                .AsEnumerable()
                .Select(t => new TransactionViewModel()
                {
                    Amount = (t.Amount.HasValue ? t.Amount.Value : 0).ToString("C2"),
                    Description = t.Description,
                    TransactionDateTime = t.TransactionDate.ToString("MM/dd/yyyy HH:mm:ss"),
                    PaymentTypeName = t.PaymentType.Name,
                    ResourceName = t.Resource.Name,
                    TransactionId = t.TransactionId
                }
            );

            return View(transactions.ToList());
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            if (!ResourcePermission("Employee")
                && !ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return RedirectToAction("Index");
            }

            LoadViewBag();
            
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentTypeId,Amount,Description")] Transaction transaction)
        {
            if (!ResourcePermission("Employee")
                && (!ResourcePermission("Manager")))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                transaction.ResourceId = CurrentUser.ResourceId;
                transaction.TransactionDate = DateTime.Now;

                Handler.Add(transaction);
                Handler.Save();
                return RedirectToAction("Index");
            }

            LoadViewBag();

            return View(transaction);
        }

        // GET: Transaction/Edit
        public ActionResult Edit(Guid? id)
        {
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return RedirectToAction("Index");
            }

            Transaction transaction = Handler.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }

            LoadViewBag();

            return View(transaction);
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionId,PaymentTypeId,Amount,Description")] Transaction transaction)
        {
            if ((!ResourcePermission("Manager")))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                var orig = Handler.Find(transaction.TransactionId);
                orig.Amount = transaction.Amount;
                orig.Description = transaction.Description;
                orig.PaymentTypeId = transaction.PaymentTypeId;

                Handler.Update(orig);
                Handler.Save();
                return RedirectToAction("Index");
            }

            LoadViewBag();

            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return RedirectToAction("Index");
            }

            Transaction transaction = Handler.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TransactionViewModel()
            {
                Amount = (transaction.Amount.HasValue ? transaction.Amount.Value : 0).ToString("C2"),
                Description = transaction.Description,
                TransactionDateTime = transaction.TransactionDate.ToString("MM/dd/yyyy HH:mm:ss"),
                PaymentTypeName = transaction.PaymentType.Name,
                ResourceName = transaction.Resource.Name
            };

            return View(viewModel);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return RedirectToAction("Index");
            }

            Handler.Delete(id);
            Handler.Save();

            return RedirectToAction("Index");
        }
    }
}
