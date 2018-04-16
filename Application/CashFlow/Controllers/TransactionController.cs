using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
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
            ViewBag.Disabled = ResourcePermission("Employee") ? "" : " disabled";
            ViewBag.AdmDisabled = ResourcePermission("Manager") ? "" : " disabled";
            ViewBag.PaymentTypes = new SelectList(
                _paymentTypeRole.PaymentTypes().Select(p=> new { p.PaymentTypeId, p.Name })
                , "PaymentTypeId", "Name"
            );
        }

        // GET: Transaction
        public ActionResult Index()
        {
            LoadViewBag();

            var transactions = Handler.All();
            return View(transactions.OrderByDescending(r => r.TransactionDate).ToList());
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            LoadViewBag();
            if (!ResourcePermission("Employee")
                || !ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View();
            }
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentTypeId,Amount,Description")] Transaction transaction)
        {
            LoadViewBag();

            if (!ResourcePermission("Employee")
                || (!ResourcePermission("Manager")))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(transaction);
            }

            if (ModelState.IsValid)
            {
                transaction.ResourceId = CurrentUser.ResourceId;
                transaction.TransactionDate = DateTime.Now;

                Handler.Add(transaction);
                Handler.Save();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        // GET: Transaction/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    throw new NotImplementedException();

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Restaurante restaurante = db.Restaurantes.Find(id);
        //    if (restaurante == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    LoadViewBag();
        //    if (!UsuarioAdministrador())
        //    {
        //        ModelState.AddModelError("", "You don`t have permission.");
        //        return View(restaurante);
        //    }
        //    return View(restaurante);
        //}

        //// POST: Transaction/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,IdCategoria,IdModalidade,DistanciaMedia,Endereco,Nome,ValorMedio,Ativo")] IDbTransaction transaction)
        //{
        //    throw new NotImplementedException();

        //    LoadViewBag();
        //    if (!UsuarioAdministrador())
        //    {
        //        ModelState.AddModelError("", "You don`t have permission.");
        //        return View(restaurante);
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(restaurante).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(restaurante);
        //}

        // GET: Transaction/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = Handler.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(transaction);
            }
            return View(transaction);
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
