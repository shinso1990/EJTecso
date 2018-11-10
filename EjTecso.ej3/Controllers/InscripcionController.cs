using EjTecso.ej3.DataAccess;
using EjTecso.ej3.Models.ModeloPagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjTecso.ej3.Controllers
{
    public class InscripcionController : Controller
    {
        // GET: Inscripcion
        public ActionResult Index(int IdAlumno)
        {
            var alumno = AlumnoDA.GetAlumno(IdAlumno);
            List<Curso> materiasInscriptas = AlumnoDA.MateriasInscriptasPor(IdAlumno);
            List<Curso> materiasDelAñoDisponibles = AlumnoDA.MateriasDisponibles(IdAlumno);
            List<Inscripcion_Estado> estados = InscripcionDA.GetEstadosInscripcion();
            var mp = new MPInscripcion()
            {
                CursosDiponibles = materiasDelAñoDisponibles,
                CursosExistentes = materiasInscriptas,
                IDAlumno = IdAlumno,
                Estados = estados,
                Alumno = alumno
            };
            return View(mp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AsociarAlumno(int IdAlumno, int IdCurso, int IdEstado)
        {
            try
            {
                var insc = new Inscripcion() { FechaInscripcion = DateTime.Now, IDAlumno = IdAlumno, IDCurso = IdCurso, IDEstado = IdEstado };
                AlumnoDA.Inscribir(insc);
                //return Json(new { respuesta = "Se guardó correctamente", hayError = false, mensajeError = "" });
            }
            catch(Exception e)
            {
                //log e
                //return Json(new { respuesta = "", hayError = true, mensajeError = "Se produjo un error al Asociar" });
            }
            return RedirectToAction("index", new { IdAlumno = IdAlumno });

        }

    }
}