using EjTecso.ej3.DataAccess;
using EjTecso.ej3.Models.Filtros;
using EjTecso.ej3.Models.ModeloPagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjTecso.ej3.Controllers
{
    public class AsignaturaController : Controller
    {
        public ActionResult Index(FiltroAsignatura filtro)
        {
            var asignaturas = AsignaturaDA.GetAsignaturasCompletas(filtro);
            MPAsignatura asig = new MPAsignatura() { Filtro = filtro, Asignaturas = asignaturas };
            return View(asig);
        }
    }
}