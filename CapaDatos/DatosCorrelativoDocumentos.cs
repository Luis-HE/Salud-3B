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
   public class DatosCorrelativoDocumentos
    {
        public static List<EntidadCorrelativoDocumentos> ListCorrelativoDocumentosSeries(int id_unidad_negocio)
        {
            List<EntidadCorrelativoDocumentos> lst = new List<EntidadCorrelativoDocumentos>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT tipo_documento,serie+' '+descripcion as descripcion FROM TBL_CORRELATIVO_DOC_CONTABLE WHERE id_unidad_negocio='" + id_unidad_negocio+"' ORDER BY descripcion  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCorrelativoDocumentos entCorrel = new EntidadCorrelativoDocumentos()
                            {
                                tipo_documento = dr["tipo_documento"].ToString(),
                                descripcion = dr["descripcion"].ToString()
                            };
                            lst.Add(entCorrel);
                        }
                    }

                }
            }
            return lst;
        }
        public static List<EntidadCorrelativoDocumentos> ListCorrelativoDocumento( string tipo_doc, string serie, int id_unidad_negocio)
        {
            List<EntidadCorrelativoDocumentos> lst = new List<EntidadCorrelativoDocumentos>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select correlativo+1 as numero from TBL_CORRELATIVO_DOC_CONTABLE WHERE tipo_documento='" + tipo_doc + "' and serie='"+ serie + "' AND id_unidad_negocio='"+id_unidad_negocio+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCorrelativoDocumentos entCorrel = new EntidadCorrelativoDocumentos()
                            {
                                correlativo = Convert.ToInt32(dr["numero"])
                            };
                            lst.Add(entCorrel);
                        }
                    }

                }
            }
            return lst;
        }
        public static void  UpdateCorrelativoDocumento(string tipo_doc, string serie, int id_unidad_negocio)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "UPDATE TBL_CORRELATIVO_DOC_CONTABLE SET correlativo=correlativo+1 WHERE tipo_documento='" + tipo_doc + "' and serie='" + serie + "' and id_unidad_negocio='" + id_unidad_negocio + "'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
