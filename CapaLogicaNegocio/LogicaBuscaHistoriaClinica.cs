using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaBuscaHistoriaClinica
    {
        public static List<EntidadBuscaHistoriaClinica> BuscarHistoriaClinica(int numero_admision)
        {
            return DatosBuscaHistoriaClinica.BuscarHistoriaClinica(numero_admision);
        }
    }
}
