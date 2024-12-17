using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaClienteEmpresa
    {
        public static List<EntidadClienteEmpresa> ListClienteEmpresa(string ruc_cliente)
        {
            return DatosClienteEmpresa.ListClienteEmpresa(ruc_cliente);
        }
        public static void InsertClienteEmpresa(EntidadClienteEmpresa entCliEmp)
        {
            DatosClienteEmpresa.InsertClienteEmpresa(entCliEmp);
        }
        public static void UpdateClienteEmpresa(EntidadClienteEmpresa entCliEmp)
        {
            DatosClienteEmpresa.UpdateClienteEmpresa(entCliEmp);
        }
    }
}
