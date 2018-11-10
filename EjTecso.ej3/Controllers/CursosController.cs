using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjTecso.ej3;

namespace EjTecso.ej3.Controllers
{
    public class CursosController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Cursoes
        public ActionResult Index()
        {
            var curso = db.Curso.Include(c => c.Docente).Include(c => c.Materia);
            return View(curso.ToList());
        }

        // GET: Cursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursoes/Create
        public ActionResult Create()
        {
            ViewBag.IDDocente = new SelectList(db.Docente, "IDDocente", "Nombre");
            ViewBag.IDMateria = new SelectList(db.Materia, "IDMateria", "Nombre");
            return View();
        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCurso,IDMateria,CupoMaximo,IDDocente,FechaInscripcionInicio,FechaInscripcionFin,FechaInicioCursada,FechaFinCursada")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Curso.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDocente = new SelectList(db.Docente, "IDDocente", "Nombre", curso.IDDocente);
            ViewBag.IDMateria = new SelectList(db.Materia, "IDMateria", "Nombre", curso.IDMateria);
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDocente = new SelectList(db.Docente, "IDDocente", "Nombre", curso.IDDocente);
            ViewBag.IDMateria = new SelectList(db.Materia, "IDMateria", "Nombre", curso.IDMateria);
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCurso,IDMateria,CupoMaximo,IDDocente,FechaInscripcionInicio,FechaInscripcionFin,FechaInicioCursada,FechaFinCursada")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDocente = new SelectList(db.Docente, "IDDocente", "Nombre", curso.IDDocente);
            ViewBag.IDMateria = new SelectList(db.Materia, "IDMateria", "Nombre", curso.IDMateria);
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Curso.Find(id);
            db.Curso.Remove(curso);
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
