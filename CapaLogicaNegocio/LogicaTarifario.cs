using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
namespace CapaLogicaNegocio
{
   public class LogicaTarifario
    {
        public static List<EntidadTarifario> ListTarifario(int cod_categoria,int id_cia_seg, int id_grupo)
        {
            return DatosTarifario.ListTarifario(cod_categoria,id_cia_seg, id_grupo);
        }
        public static List<EntidadTarifario> ListTarifario(int cod_categoria, int id_grupo)
        {
            return DatosTarifario.ListTarifario(cod_categoria, id_grupo);
        }
    }
}
