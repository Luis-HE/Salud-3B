using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaModeloBuscaPacAdmitido
    {
        public static List<EntidadModeloBuscaPacAdmitido> ListPacientesAdmitidos(string dni_cliente, string fecha_admision)
        {
            return DatosModeloBuscaPacAdmitido.ListPacientesAdmitidos(dni_cliente, fecha_admision);
        }
        public static List<EntidadModeloBuscaPacAdmitido> BuscarPacientesAdmitidosEmergencia(int dia, int mes, int anio)
        {
            return DatosModeloBuscaPacAdmitido.BuscarPacientesAdmitidosEmergencia(dia,mes,anio);
        }
        public static List<EntidadModeloBuscaPacAdmitido> BuscarPacientesAdmitidosConsultorio(int dia, int mes, int anio, int cod_especialidad)
        {
            return DatosModeloBuscaPacAdmitido.BuscarPacientesAdmitidosConsultorio(dia,mes,anio, cod_especialidad);
        }
        public static List<EntidadModeloBuscaPacAdmitido> BuscarPacientesAdmitidosRadiologia(int dia, int mes, int anio)
        {
            return DatosModeloBuscaPacAdmitido.BuscarPacientesAdmitidosRadiologia(dia, mes, anio);
        }
        public static List<EntidadModeloBuscaPacAdmitido> GetListPacienteTriaje(int num_admision)
        {
            return DatosModeloBuscaPacAdmitido.GetListPacienteTriaje(num_admision);
        }
        public static List<EntidadModeloBuscaPacAdmitido> BuscarPacienteAdmitidoLibroEmergencia(int dia, int mes, int anio)
        {
            return DatosModeloBuscaPacAdmitido.BuscarPacienteAdmitidoLibroEmergencia(dia,mes,anio);
        }
        public static void ActualizaEstadoAdmision(int numero_admision)
        {
            DatosModeloBuscaPacAdmitido.ActualizaEstadoAdmision(numero_admision);
        }
    }
}
