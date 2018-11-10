using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjTecso.ej3.DataAccess
{
    public class InscripcionDA
    {
        internal static List<Inscripcion_Estado> GetEstadosInscripcion()
        {
            using(var r = new DatabaseEntities())
            {
                return r.Inscripcion_Estado.ToList();
            }
        }
    }
}