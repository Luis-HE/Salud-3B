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
  public  class DatosReporteVentas
    {
        public static List<EntidadReporteVentas> ListarVentas()
        {
            List<EntidadReporteVentas> lst = new List<EntidadReporteVentas>();
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            //{
            //    string query = "select Codigo,Nombre,Precio from TBL_ITEMS ";
            //    con.Open();
            //    using (SqlCommand cmd = new SqlCommand(query, con))
            //    {
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            EntidadReporteVentas entReportVenta = new EntidadReporteVentas()
            //            {
            //                column1 = dr["Codigo"].ToString(),
            //                column2 = dr["Nombre"].ToString(),
            //                column3 = Convert.ToDecimal(dr["Precio"])
            //            };
            //            lst.Add(entReportVenta);
            //        }
            //    }
            //}
            return lst;
        }
        public static List<EntidadReporteVentas> ListReporteVentasFarmacia(string fechaIni, string fechaFin)
        {
            List<EntidadReporteVentas> lst = new List<EntidadReporteVentas>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = @"SELECT TBL_CATALOGO.codigo_item_catalogo as codItem,convert(varchar(10),fecha_emision,103) as fecha_emision,descripcion_principal, total,TBL_DOC_CONTABLE.serie +'-'+TBL_DOC_CONTABLE.numero_documento as numDoc,TBL_DOC_CONTABLE.tipo_documento as tipoDoc FROM TBL_CATALOGO inner join(TBL_DOC_CONTABLE inner join TBL_DET_DOC_CONTABLE on TBL_DOC_CONTABLE.numero_documento=TBL_DET_DOC_CONTABLE.numero_documento AND TBL_DOC_CONTABLE.serie=TBL_DET_DOC_CONTABLE.serie) on 
                                  TBL_CATALOGO.codigo_item_catalogo = TBL_DET_DOC_CONTABLE.codigo_item_catalogo WHERE fecha_emision>= '" + fechaIni + " 00:00" + "' and fecha_emision<= '" + fechaFin + " 23:59" + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadReporteVentas entReportVenta = new EntidadReporteVentas()
                            {
                                codigo_item_catalogo = dr["codItem"].ToString(),
                                fecha_emision = dr["fecha_emision"].ToString(),
                                descripcion_principal =  dr["descripcion_principal"].ToString(),
                                monto_total = Convert.ToDecimal(dr["total"]),
                                numero_documento = dr["numDoc"].ToString(),
                                tipo_documento = dr["tipoDoc"].ToString(),
                            };
                            lst.Add(entReportVenta);
                        }
                    }
                }
            }
            return lst;
        }
    }
}
