using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.Models.ModeloPagina
{
    public class MPInscripcion
    {
        public List<Curso> CursosDiponibles { get; set; }
        public List<Curso> CursosExistentes { get; set; }

        public int IDAlumno { get; set; }

        public List<Inscripcion_Estado> Estados { get; set; }
        public Alumno Alumno { get; set; }
    }
}