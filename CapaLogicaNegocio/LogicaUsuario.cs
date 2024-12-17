using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
  public  class LogicaUsuario
    {
        public static void CreateUsuario(EntidadUsuario entUsuario)
        {
            DatosUsuario.CreateUsuario(entUsuario);
        }
        public static List<EntidadUsuario> ReadUsuario(string NombreUsuario, string Clave)
        {
            return DatosUsuario.ReadUsuario(NombreUsuario,Clave);
        }
        public static void UpdateUsuario(EntidadUsuario entUsuario)
        {
            DatosUsuario.UpdateUsuario(entUsuario);
        }
        public static void DeleteUsuario(EntidadUsuario entUsuario)
        {
            DatosUsuario.DeleteUsuario(entUsuario);
        }
    }
}
