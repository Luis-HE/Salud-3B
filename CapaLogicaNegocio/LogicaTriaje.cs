using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaLogicaNegocio
{
   public class LogicaTriaje
    {
        public static List<EntidadTriaje> ListarTriaje()
        {
            return DatosTriaje.ListarTriaje();
        }
        public static void InsertarTriaje(EntidadTriaje entTriaje)
        {
            DatosTriaje.InsertarTriaje(entTriaje);
        }
        public static List<EntidadTriaje> ColaTriaje(int day, int month, int year)
        {
            return DatosTriaje.ColaTriaje(day, month, year);
        }
    }
}
