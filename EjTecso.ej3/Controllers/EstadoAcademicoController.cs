using EjTecso.ej3.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjTecso.ej3.Controllers
{
    public class EstadoAcademicoController : Controller
    {
        // GET: EstadoAcademico
        public ActionResult Index(int idAlumno)
        {
            var listado = AlumnoDA.GetAlumnoConInscripciones(idAlumno);
            return View(listado);
        }
    }
}