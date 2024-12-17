using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaModeloBuscaPacAtendido
    {
        public static List<EntidadModeloBuscaPacAtendido> BuscarPacientesAtendidos(string dni_cliente)
        {
            return DatosModeloBuscaPacAtendido.BuscarPacientesAtendidos(dni_cliente);
        }
        public static List<EntidadModeloBuscaPacAtendido> BuscarPacientesAtendidosExternos(string dni_cliente)
        {
            return DatosModeloBuscaPacAtendido.BuscarPacientesAtendidosExternos(dni_cliente);
        }
        public static List<EntidadModeloBuscaPacAtendido> ListDetalleRecetaMedicamentos(string dni_paciente, int numero_admision)
        {
            return DatosModeloBuscaPacAtendido.ListDetalleRecetaMedicamentos(dni_paciente, numero_admision);
        }
        public static List<EntidadModeloBuscaPacAtendido> ListDetalleRecetaMedicamentosConfirmados(string dni_paciente, int numero_admision)
        {
            return DatosModeloBuscaPacAtendido.ListDetalleRecetaMedicamentosConfirmados(dni_paciente, numero_admision);
        }
        public static List<EntidadModeloBuscaPacAtendido> ListDetalleRecetaLaboratorio(string dni_paciente, int numero_admision)
        {
            return DatosModeloBuscaPacAtendido.ListDetalleRecetaLaboratorio(dni_paciente, numero_admision);
        }
        public static List<EntidadModeloBuscaPacAtendido> ListDetalleRecetaLaboratorio(string dni_paciente)
        {
            return DatosModeloBuscaPacAtendido.ListDetalleRecetaLaboratorio(dni_paciente);
        }
    }
}
