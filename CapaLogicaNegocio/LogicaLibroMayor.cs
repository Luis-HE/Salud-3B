using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaLibroMayor
    {
        public static List<EntidadLibroMayor> ListLibroMayor(int periodo_anio, string periodo_mes, string num_doc_cliente)
        {
            return DatosLibroMayor.ListLibroMayor(periodo_anio, periodo_mes, num_doc_cliente);
        }
        public static void InsertLibroMayor(string tipo_doc, string numero_doc)
        {
            DatosLibroMayor.InsertLibroMayor(tipo_doc, numero_doc);
        }
    }
}
