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
    public class TarefaController : Controller
    {
        private DBTarefaAnderlineEntities db = new DBTarefaAnderlineEntities();

        // GET: Tarefa
        public ActionResult Index()
        {
            var tarefa = db.Tarefa.Include(t => t.Prioridades).Include(t => t.StatusTarefa).Include(t => t.Usuario);
            return View(tarefa.ToList());
        }

        // GET: Tarefa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // GET: Tarefa/Create
        public ActionResult Create()
        {
            ViewBag.IDPrioridade = new SelectList(db.Prioridades, "ID", "Descricao");
            ViewBag.IDStatus = new SelectList(db.StatusTarefa, "ID", "Descricao");
            ViewBag.IDUsuario = new SelectList(db.Usuario, "ID", "Login");
            return View();
        }

        // POST: Tarefa/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDUsuario,IDPrioridade,IDStatus,Descricao,DataCriacao")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefa.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPrioridade = new SelectList(db.Prioridades, "ID", "Descricao", tarefa.IDPrioridade);
            ViewBag.IDStatus = new SelectList(db.StatusTarefa, "ID", "Descricao", tarefa.IDStatus);
            ViewBag.IDUsuario = new SelectList(db.Usuario, "ID", "Login", tarefa.IDUsuario);
            return View(tarefa);
        }

        // GET: Tarefa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPrioridade = new SelectList(db.Prioridades, "ID", "Descricao", tarefa.IDPrioridade);
            ViewBag.IDStatus = new SelectList(db.StatusTarefa, "ID", "Descricao", tarefa.IDStatus);
            ViewBag.IDUsuario = new SelectList(db.Usuario, "ID", "Login", tarefa.IDUsuario);
            return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDUsuario,IDPrioridade,IDStatus,Descricao,DataCriacao")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPrioridade = new SelectList(db.Prioridades, "ID", "Descricao", tarefa.IDPrioridade);
            ViewBag.IDStatus = new SelectList(db.StatusTarefa, "ID", "Descricao", tarefa.IDStatus);
            ViewBag.IDUsuario = new SelectList(db.Usuario, "ID", "Login", tarefa.IDUsuario);
            return View(tarefa);
        }

        // GET: Tarefa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefa tarefa = db.Tarefa.Find(id);
            db.Tarefa.Remove(tarefa);
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
