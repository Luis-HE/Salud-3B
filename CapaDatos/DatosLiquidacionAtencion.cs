using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;

namespace CapaDatos
{
   public class DatosLiquidacionAtencion
    {
        public static List<EntidadLiquidacionAtencion> ListLiquidacionAtencion(string dni_cliente)
        {
            List<EntidadLiquidacionAtencion> lst = new List<EntidadLiquidacionAtencion>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = @"SELECT TBL_DOC_CONTABLE.numero_documento as numDoc,TBL_DOC_CONTABLE.tipo_documento as tipoDoc,CONVERT(char(11), fecha_emision,113) as fechaEmision,TBL_DET_DOC_CONTABLE.codigo_item_catalogo as codItem, descripcion_detalle, valor_venta,cantidad, tipo_item_catalogo,TBL_DET_DOC_CONTABLE.estado as estadoPago
                                FROM TBL_ADMISION inner join(TBL_CATALOGO inner join (TBL_DOC_CONTABLE INNER JOIN TBL_DET_DOC_CONTABLE ON TBL_DOC_CONTABLE.numero_documento = TBL_DET_DOC_CONTABLE.numero_documento and TBL_DOC_CONTABLE.tipo_documento = TBL_DET_DOC_CONTABLE.tipo_documento)
                                ON TBL_CATALOGO.codigo_item_catalogo = TBL_DET_DOC_CONTABLE.codigo_item_catalogo) on TBL_ADMISION.numero_admision=TBL_DOC_CONTABLE.numero_admision
                                 WHERE dni_cliente = '"+ dni_cliente + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadLiquidacionAtencion entLisAten = new EntidadLiquidacionAtencion()
                            {
                                numero_documento = dr["numDoc"].ToString(),
                                tipo_documento = dr["tipoDoc"].ToString(),
                                fecha_emision = dr["fechaEmision"].ToString(),
                                codigo_item_catalogo = dr["codItem"].ToString(),
                                descrip_item = dr["descripcion_detalle"].ToString(),
                                valor_venta = Convert.ToDecimal(dr["valor_venta"]),
                                cantidad = Convert.ToInt32(dr["cantidad"]),
                                tipo_item_catlogo = dr["tipo_item_catalogo"].ToString(),
                                estado_pago = dr["estadoPago"].ToString()
                            };
                            lst.Add(entLisAten);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
