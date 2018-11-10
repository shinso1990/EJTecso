using EjTecso.ej3.DataAccess;
using EjTecso.ej3.Models.Filtros;
using EjTecso.ej3.Models.ModeloPagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EjTecso.ej3.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult Index(FiltroAlumno filtro)
        {
            var alumnos = AlumnoDA.GetAlumnos(filtro);
            var model = new MPAlumno(filtro, alumnos);
            
            return View(model);
        }
        public ActionResult Editar(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Alumno alumno = AlumnoDA.GetAlumno(id.Value);
            if (alumno == null)
                return HttpNotFound();
            return View(alumno);
        }
        public ActionResult Alta()
        {
            return View();
        }
        public ActionResult EstadoAcademico(int idAlumno)
        {
            var listado = AlumnoDA.GetAlumnoConInscripciones(idAlumno);
            return View(listado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta([Bind(Include = "Nombre,Legajo,Edad,FechaNacimiento")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                AlumnoDA.Create(alumno);
                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IDAlumno,Nombre,Legajo,Edad,FechaNacimiento")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                AlumnoDA.UpdateAlumno(alumno);
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        

    }
}