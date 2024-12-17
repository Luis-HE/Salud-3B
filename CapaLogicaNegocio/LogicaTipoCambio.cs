using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaTipoCambio
    {
        public static void CreateTipoCambio(EntidadTipoCambio entTipoCamb)
        {
            DatosTipoCambio.CreateTipoCambio(entTipoCamb);
        }
        public static List<EntidadTipoCambio> ReadTipoCambio()
        {
            return DatosTipoCambio.ReadTipoCambio();
        }
        public static void UpdateTipoCambio(EntidadTipoCambio entTipoCamb)
        {
            DatosTipoCambio.UpdateTipoCambio(entTipoCamb);
        }
        public static void DeleteTipoCambio(EntidadTipoCambio entTipoCamb)
        {
            DatosTipoCambio.DeleteTipoCambio(entTipoCamb);
        }
    }
}
