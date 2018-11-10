using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.Models.ModeloPagina
{
    public class MPAsignatura
    {
        public Filtros.FiltroAsignatura Filtro { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
    }
}