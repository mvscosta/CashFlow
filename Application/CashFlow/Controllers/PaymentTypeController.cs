using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;

namespace CashFlow.Controllers
{
    [Authorize]
    public class PaymentTypeController : BaseController<PaymentType>
    {
        public PaymentTypeController(IResourceHandler resourceHandler, IPaymentTypeHandler handler)
            :base(resourceHandler, handler)
        {

        }

        internal override void LoadViewBag()
        {
            //ViewBag.Disabled = UsuarioAdministrador() ? "" : " disabled";
        }

        // GET: PaymentType
        public ActionResult Index()
        {
            LoadViewBag();
            return View(Handler.All().OrderBy(c => c.Name).ToList());
        }

        // GET: PaymentType/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = Handler.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // GET: PaymentType/Create
        public ActionResult Create()
        {
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View();
            }
            return View();
        }

        // POST: PaymentType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,Name,Active")] PaymentType paymentType)
        {
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(paymentType);
            }
            if (ModelState.IsValid)
            {
                Handler.Add(paymentType);
                Handler.Save();
                return RedirectToAction("Index");
            }

            return View(paymentType);
        }

        // GET: PaymentType/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = Handler.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(paymentType);
            }
            return View(paymentType);
        }

        // POST: PaymentType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentTypeId,Description,Name,Active")] PaymentType paymentType)
        {
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(paymentType);
            }
            if (ModelState.IsValid)
            {
                Handler.Update(paymentType);
                Handler.Save();
                return RedirectToAction("Index");
            }
            return View(paymentType);
        }

        // GET: PaymentType/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: PaymentType/Delete/5
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
