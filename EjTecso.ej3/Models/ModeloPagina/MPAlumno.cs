using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EjTecso.ej3.Models.Filtros;

namespace EjTecso.ej3.Models.ModeloPagina
{
    public class MPAlumno
    {

        public MPAlumno(FiltroAlumno filtro, List<Alumno> alumnos)
        {
            this.filtro = filtro;
            this.alumnos = alumnos;
        }

        public Filtros.FiltroAlumno filtro { get; set; } 
        public List<Alumno> alumnos { get; set; }
    }
}