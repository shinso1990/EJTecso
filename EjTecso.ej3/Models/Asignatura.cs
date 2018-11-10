using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.Models
{
    public class Asignatura
    {
        public Curso Curso { get; set; }
        public Inscripcion Inscripcion { get; set; }
        public Alumno Alumno { get; set; }
        public Materia Materia { get; set; }
        public Docente Docente { get; set; }
    }
}