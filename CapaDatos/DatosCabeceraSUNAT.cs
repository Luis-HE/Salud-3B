using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


using CapaEntidad;

namespace CapaDatos
{
   public class DatosCabeceraSUNAT
    {
        public static List<EntidadCabeceraSUNAT> ListarCabecera(string numero_documento, string serie, string tipo_documento)
        {
            List<EntidadCabeceraSUNAT> lst = new List<EntidadCabeceraSUNAT>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "spCabeceraDocumentoSUNAT";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@numero_documento", SqlDbType.VarChar,16)).Value = numero_documento;
                    cmd.Parameters.Add(new SqlParameter("@serie", SqlDbType.VarChar,16)).Value = serie;
                    cmd.Parameters.Add(new SqlParameter("@tipo_documento", SqlDbType.Char,2)).Value = tipo_documento;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCabeceraSUNAT ent = new EntidadCabeceraSUNAT()
                            {
                                col1 = dr["VersionDoc"].ToString(),
                                col2 = dr["numero_documento"].ToString(),
                                col3 = dr["tipo_documento"].ToString(),
                                col4 = dr["TipoOperacion"].ToString(),
                                col5 = dr["RucEmisor"].ToString(),
                                col6 = dr["CodSucursal"].ToString(),
                                col7 = dr["FechaEmision"].ToString(),
                                col8 = dr["FechaVence"].ToString(),
                                col9 = dr["tipoMoneda"].ToString(),
                                col10 = dr["subtotal"].ToString(),
                                col11 = dr["descuento_total"].ToString(),
                                col12 = dr["BaseImponible"].ToString(),
                                col13 = dr["Isc"].ToString(),
                                col14 = dr["igv"].ToString(),
                                col15 = dr["total_otro_cargo"].ToString(),
                                col16 = dr["total_otro_tributo"].ToString(),
                                col17 = dr["total"].ToString(),
                                col18 = dr["tiene_doc_referencia"].ToString(),
                                col19 = dr["tipo_doc_referencia"].ToString(),
                                col20 = dr["serie_doc_referencia"].ToString(),
                                col21= dr["numero_doc_referencia"].ToString(),
                                col22 = dr["serie"].ToString(),
                                col23 = dr["numero_documento"].ToString(),
                                col24 = dr["UserId"].ToString(),
                                col25 = dr["observacion"].ToString(),
                                col26 = dr["condicion_pago"].ToString(),
                                col27 = dr["numero_orden_compra"].ToString(),
                                col28 = dr["numero_guia_remision"].ToString(),
                                col29 = dr["MensajeDetrac"].ToString(),
                                col30 = dr["TransferGratuita"].ToString(),
                                col31 = dr["DocRelacionado"].ToString(),
                                col32 = dr["DescuentoGlobal"].ToString(),
                                col33 = dr["Otroscargos"].ToString(),
                                col34 = dr["Anticipo"].ToString(),
                                col35 = dr["col35"].ToString(),
                                col36 = dr["col36"].ToString(),
                                col37 = dr["col37"].ToString(),
                                col38 = dr["col38"].ToString(),
                                col39 = dr["col39"].ToString(),
                                col40 = dr["col40"].ToString(),
                                col41 = dr["col41"].ToString(),
                                col42 = dr["col42"].ToString(),
                                col43 = dr["col43"].ToString(),
                                col44 = dr["col44"].ToString(),
                                col45 = dr["col45"].ToString(),
                                col46 = dr["col46"].ToString(),
                                col47 = dr["col47"].ToString(),
                                col48 = dr["col48"].ToString(),
                                col49 = dr["col49"].ToString()                               

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
