using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBTarefaAnderline.Models;

namespace DBTarefaAnderline.Controllers
{
    public class PrioridadeController : Controller
    {
        private DBTarefaAnderlineEntities db = new DBTarefaAnderlineEntities();

        // GET: Prioridade
        public ActionResult Index()
        {
            return View(db.Prioridades.ToList());
        }

        // GET: Prioridade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridades prioridades = db.Prioridades.Find(id);
            if (prioridades == null)
            {
                return HttpNotFound();
            }
            return View(prioridades);
        }

        // GET: Prioridade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prioridade/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descricao")] Prioridades prioridades)
        {
            if (ModelState.IsValid)
            {
                db.Prioridades.Add(prioridades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prioridades);
        }

        // GET: Prioridade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridades prioridades = db.Prioridades.Find(id);
            if (prioridades == null)
            {
                return HttpNotFound();
            }
            return View(prioridades);
        }

        // POST: Prioridade/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descricao")] Prioridades prioridades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prioridades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prioridades);
        }

        // GET: Prioridade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridades prioridades = db.Prioridades.Find(id);
            if (prioridades == null)
            {
                return HttpNotFound();
            }
            return View(prioridades);
        }

        // POST: Prioridade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prioridades prioridades = db.Prioridades.Find(id);
            db.Prioridades.Remove(prioridades);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
