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
        public TransactionController(IResourceHandler resourceHandler, ITransactionHandler handler)
            : base(resourceHandler, handler)
        {

        }

        internal override void LoadViewBag()
        {
            //ViewBag.Disabled = UsuarioAdministrador() ? "" : " disabled";
            //ViewBag.IdCategoria = new SelectList(db.Categorias, "Id", "Titulo");
            //ViewBag.IdModalidade = new SelectList(db.Modalidades, "Id", "Titulo");

        }

        // GET: Restaurantes
        public ActionResult Index()
        {
            throw new NotImplementedException();

            //LoadViewBag();
            //var restaurantes = db.Restaurantes.Include(r => r.Categoria).Include(r => r.Modalidade);
            //return View(restaurantes.OrderBy(r => r.Nome).ToList());
        }

        // GET: Restaurantes/Details/5
        public ActionResult Details(int? id)
        {
            throw new NotImplementedException();

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Restaurante restaurante = db.Restaurantes.Find(id);
            //if (restaurante == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(restaurante);
        }

        // GET: Restaurantes/Create
        public ActionResult Create()
        {
            LoadViewBag();
            //if (!ResourcePermission("Manager"))
            //{
            //    ModelState.AddModelError("", "You don`t have permission.");
            //    return View();
            //}
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCategoria,IdModalidade,DistanciaMedia,Endereco,Nome,ValorMedio,Ativo")] IDbTransaction transaction)
        {
            throw new NotImplementedException();

            //LoadViewBag();
            //if (!UsuarioAdministrador())
            //{
            //    ModelState.AddModelError("", "You don`t have permission.");
            //    return View(restaurante);
            //}
            //if (ModelState.IsValid)
            //{
            //    db.Restaurantes.Add(restaurante);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(restaurante);
        }

        // GET: Restaurantes/Edit/5
        public ActionResult Edit(int? id)
        {
            throw new NotImplementedException();

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Restaurante restaurante = db.Restaurantes.Find(id);
            //if (restaurante == null)
            //{
            //    return HttpNotFound();
            //}
            //LoadViewBag();
            //if (!UsuarioAdministrador())
            //{
            //    ModelState.AddModelError("", "You don`t have permission.");
            //    return View(restaurante);
            //}
            //return View(restaurante);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCategoria,IdModalidade,DistanciaMedia,Endereco,Nome,ValorMedio,Ativo")] IDbTransaction transaction)
        {
            throw new NotImplementedException();

            //LoadViewBag();
            //if (!UsuarioAdministrador())
            //{
            //    ModelState.AddModelError("", "You don`t have permission.");
            //    return View(restaurante);
            //}
            //if (ModelState.IsValid)
            //{
            //    db.Entry(restaurante).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(restaurante);
        }

        // GET: Restaurantes/Delete/5
        public ActionResult Delete(int? id)
        {
            throw new NotImplementedException();

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Restaurante restaurante = db.Restaurantes.Find(id);
            //if (restaurante == null)
            //{
            //    return HttpNotFound();
            //}
            //if (!ResourcePermission("Manager"))
            //{
            //    ModelState.AddModelError("", "You don`t have permission.");
            //    return View(restaurante);
            //}
            //return View(restaurante);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();

            //Restaurante restaurante = db.Restaurantes.Find(id);
            //if (!ResourcePermission("Manager"))
            //{
            //    ModelState.AddModelError("", "You don`t have permission.");
            //    return View(restaurante);
            //}
            //restaurante.Ativo = false;
            //db.Entry(restaurante).State = EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }
    }
}
