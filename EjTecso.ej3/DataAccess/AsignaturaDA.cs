using EjTecso.ej3.Models;
using EjTecso.ej3.Models.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.DataAccess
{
    public class AsignaturaDA
    {

        public static List<Asignatura> GetAsignaturasCompletas(FiltroAsignatura filtro)
        {
            filtro.Nombre = string.IsNullOrEmpty(filtro.Nombre) ? "" : filtro.Nombre;
            filtro.Docente = string.IsNullOrEmpty(filtro.Docente) ? "" : filtro.Docente;
            filtro.Asignatura = string.IsNullOrEmpty(filtro.Asignatura) ? "" : filtro.Asignatura;
            using (var r = new DatabaseEntities())
            {

                return (from c in r.Curso
                        join i in r.Inscripcion on c.IDCurso equals i.IDCurso into ins
                        from i in ins.DefaultIfEmpty()
                        join a in r.Alumno on i.IDAlumno equals a.IDAlumno into al
                        from a in al.DefaultIfEmpty()
                        join m in r.Materia on c.IDMateria equals m.IDMateria
                        join d in r.Docente on c.IDDocente equals d.IDDocente
                        where
                             (!filtro.IdAlumno.HasValue || a.IDAlumno == filtro.IdAlumno.Value) &&
                             (!filtro.IdCurso.HasValue || c.IDCurso == filtro.IdCurso.Value) &&
                            (!filtro.Legajo.HasValue || a.Legajo == filtro.Legajo.Value) &&
                            (filtro.Asignatura == "" || m.Nombre.Contains(filtro.Asignatura)) &&
                            (filtro.Docente == "" || d.Nombre.Contains(filtro.Docente)) &&
                            ((int)filtro.Estado == 0 || i.IDEstado == (int)filtro.Estado) &&
                            (filtro.Nombre == "" || a.Nombre.Contains(filtro.Nombre))
                        orderby c.IDCurso descending, i.FechaInscripcion descending
                        select new Asignatura() { Alumno = a , Curso = c, Inscripcion = i, Materia = m, Docente = d }
                    ).ToList();
            }
        }

    }
}