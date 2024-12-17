using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;

namespace CapaDatos
{
  public   class DatosDetalleSUNAT
    {
        public static List<EntidadDetalleSUNAT> listarDetalle(string numero_documento, string serie, string tipo_documento)
        {
            List<EntidadDetalleSUNAT> lst = new List<EntidadDetalleSUNAT>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "spDetalleDocumentoSUNAT";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@numero_documento", SqlDbType.VarChar, 16)).Value = numero_documento;
                    cmd.Parameters.Add(new SqlParameter("@serie", SqlDbType.VarChar, 16)).Value = serie;
                    cmd.Parameters.Add(new SqlParameter("@tipo_documento", SqlDbType.Char, 2)).Value = tipo_documento;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadDetalleSUNAT ent = new EntidadDetalleSUNAT()
                            {
                                col1 = dr["id_detalle_doc"].ToString(),
                                col2 = dr["TipoItem"].ToString(),
                                col3 = dr["TipoAfectacion"].ToString(),
                                col4 = dr["UnidadMedida"].ToString(),
                                col5 = dr["codigo_item_catalogo"].ToString(),
                                col6 = dr["CodProductoSunat"].ToString(),
                                col7 = dr["descripcion_detalle"].ToString(),
                                col8 = dr["cantidad"].ToString(),
                                col9 = dr["valor_unitario"].ToString(),
                                col10 = dr["descuento"].ToString(),
                                col11 = dr["porcentajedescuento"].ToString(),
                                col12 = dr["valor_venta"].ToString(),
                                col13 = dr["Igv"].ToString(),
                                col14 = dr["Isc"].ToString(),
                                col15 = dr["PorcentajeIsc"].ToString(),
                                col16 = dr["OtrosCargos"].ToString(),
                                col17 = dr["PorcentOtroCargo"].ToString(),
                                col18 = dr["Otrotributo"].ToString(),
                                col19 = dr["PorcenOtroTributo"].ToString(),
                                col20 = dr["ImpporteTotal"].ToString()

                            };
                            lst.Add(ent);
                        }
                    }

                }

            }
            return lst;
        }
    }
}
