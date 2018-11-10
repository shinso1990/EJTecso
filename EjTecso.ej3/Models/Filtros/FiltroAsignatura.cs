using EjTecso.ej3.Models.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.Models.Filtros
{
    public class FiltroAsignatura
    {
        public string Nombre { get; set; }
        public int? IdAlumno { get; set; }
        public int? IdCurso { get; set; }
        public int? Legajo { get; set; }
        public string Docente { get; set; }
        public string Asignatura { get; set; }
        public EstadoAlumno Estado { get; set; }
    }
}