using EjTecso.ej3.Models.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.Models.Filtros
{
    public class FiltroAlumno
    {
        public string Nombre { get; set; }
        public int? IdAlumno { get; set; }
        public int? Legajo { get; set; }
        public int? Edad { get; set; }
    }
}