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
    [Authorize]
    public class ResourceController : BaseController<Resource>
    {
        public ResourceController(IResourceHandler resourceHandler, IResourceHandler handler)
            : base(resourceHandler, handler)
        {

        }

        internal override void LoadViewBag()
        {
            ViewBag.Disabled = ResourcePermission("Manager") ? "" : " disabled";
        }

        // GET: 
        public ActionResult Index()
        {
            LoadViewBag();
            return View(Handler.All().OrderBy(f => f.Name).ToList());
        }

        // GET: Resource/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource funcionario = Handler.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View();
            }
            return View();
        }

        // POST: Resource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResourceId,Ative,Name,Username")] Resource resource)
        {
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(resource);
            }
            if (ModelState.IsValid)
            {
                Handler.Add(resource);
                Handler.Save();
                return RedirectToAction("Index");
            }

            return View(resource);
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = Handler.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(resource);
            }
            return View(resource);
        }

        // POST: Resource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResourceId,Active,Name,Username")] Resource resource)
        {
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(resource);
            }
            if (ModelState.IsValid)
            {
                Handler.Update(resource);
                Handler.Save();
                return RedirectToAction("Index");
            }
            return View(resource);
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = Handler.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(resource);
            }
            return View(resource);
        }

        // POST: Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Resource resource = Handler.Find(id);
            if (!ResourcePermission("Manager"))
            {
                ModelState.AddModelError("", "You don`t have permission.");
                return View(resource);
            }
            resource.Active = false;
            Handler.Update(resource);
            Handler.Save();
            return RedirectToAction("Index");
        }
    }
}
