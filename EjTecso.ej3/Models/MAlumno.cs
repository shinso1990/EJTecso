using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.Models
{
    public class MAlumno
    {
        public int IDAlumno { get; set; }
        public string Nombre { get; set; }
        public int Legajo { get; set; }
        public int Edad { get; set; }
        public System.DateTime FechaNacimiento { get; set; }

        public MAlumno(Alumno a)
        {
            this.IDAlumno = a.IDAlumno;
            this.Nombre = a.Nombre;
            this.Legajo = a.Legajo;
            this.Edad = a.Edad;
        }

    }
}