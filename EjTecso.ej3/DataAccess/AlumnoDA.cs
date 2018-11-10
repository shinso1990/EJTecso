using EjTecso.ej3.Models.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.DataAccess
{
    public class AlumnoDA
    {

        public static List<Alumno> GetAlumnos(FiltroAlumno filtro)
        {
            filtro.Nombre = string.IsNullOrEmpty(filtro.Nombre) ? "" : filtro.Nombre;
            using (var r = new DatabaseEntities())
            {
                return r.Alumno.Where(x =>
                 (!filtro.IdAlumno.HasValue || x.IDAlumno == filtro.IdAlumno.Value) &&
                (!filtro.Legajo.HasValue || x.Legajo == filtro.Legajo.Value) &&
                (!filtro.Edad.HasValue || x.Edad == filtro.Edad.Value) &&
                (filtro.Nombre == "" || x.Nombre.Contains(filtro.Nombre))
                )
                .OrderBy(x=> x.IDAlumno).ToList();
            }
        }

        internal static List<Curso> MateriasDisponibles(int idAlumno)
        {
            using (var r = new DatabaseEntities())
            {
                var qry = r.Curso.Include("Materia").Include("Docente").Where(c =>
                    c.FechaInscripcionInicio <= DateTime.Today && c.FechaInscripcionFin >= DateTime.Today &&                 //Esta dentro de la fecha de inscripción
                        (r.Inscripcion.Where(z => z.IDCurso == c.IDCurso).Sum(x => 1) == null ? 0 : r.Inscripcion.Where(z => z.IDCurso == c.IDCurso).Sum(x => 1)) < c.CupoMaximo &&                       //HAY CUPOS DISPONIBLES
                        !(from i1 in r.Inscripcion where i1.IDAlumno == idAlumno select i1.IDCurso).Contains(c.IDCurso)      //NO ES UN CURSO AL QUE SE ENCUENTRA INSCRIPTO
                       );
                return qry.ToList();

                /*
                return (from c in r.Curso
                        join m in r.Materia on c.IDMateria equals m.IDMateria
                        join d in r.Docente on c.IDDocente equals d.IDDocente
                        join d in i.Inscripcion on c.IDCurso equals i.IDCurso
                        where 
                        c.FechaInscripcionInicio <= DateTime.Today && c.FechaInscripcionFin >= DateTime.Today  &&
                        !(from i1 in r.Inscripcion where i1.IDAlumno == idAlumno select i1.IDCurso  ).Contains(c.IDCurso) 
                        select new { Curso = c, Materia = m }).ToList();*/
            }
        }

        internal static void Inscribir(Inscripcion insc)
        {
            using (var r = new DatabaseEntities())
            {
                r.Inscripcion.Add(insc);
                r.SaveChanges();
            }
        }

        internal static List<Curso> MateriasInscriptasPor(int idAlumno)
        {
            using (var r = new DatabaseEntities())
            {
                return r.Inscripcion.Include("Curso").Include("Curso.Materia").Include("Curso.Docente")
                    .Where(i => i.IDAlumno == idAlumno).Select(i => i.Curso).ToList();

                /*return (from c in r.Curso
                        join i in r.Inscripcion on c.IDCurso equals i.IDCurso
                        where i.IDAlumno == idAlumno
                        select c).ToList();*/
            }
        }

        internal static void Create(Alumno alumno)
        {
            using (var r = new DatabaseEntities())
            {
                r.Alumno.Add(alumno);
                r.SaveChanges();
            }
        }

        internal static Alumno GetAlumno(int id)
        {
            using (var r = new DatabaseEntities())
            {
                return r.Alumno.Where(x=> x.IDAlumno == id).FirstOrDefault();
            }
        }

        internal static void UpdateAlumno(Alumno alumno)
        {
            using (var r = new DatabaseEntities())
            {
                var alu = r.Alumno.SingleOrDefault(x => x.IDAlumno == alumno.IDAlumno);
                if (alu != null)
                {
                    alu.Nombre = alumno.Nombre;
                    alu.Legajo = alumno.Legajo;
                    alu.FechaNacimiento = alumno.FechaNacimiento;
                    alu.Edad = alumno.Edad;
                    r.SaveChanges();
                }
            }
        }

        internal static Alumno GetAlumnoConInscripciones(int idalumno)
        {
            using (var r = new DatabaseEntities())
            {
                return r.Alumno
                    .Include("Inscripcion").Include("Inscripcion.Curso").Include("Inscripcion.Curso.Materia").Include("Inscripcion.Curso.Docente")
                    .Where(a => a.IDAlumno == idalumno)
                    .FirstOrDefault();
            }
        }


    }
}