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
  public  class DatosDetalleConvenio
    {
        public static List<EntidadDetalleConvenio> ListDetalleConvenio()
        {
            List<EntidadDetalleConvenio> lst = new List<EntidadDetalleConvenio>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadDetalleConvenio entdetCon = new EntidadDetalleConvenio()
                            {

                            };
                            lst.Add(entdetCon);
                        }
                    }
                    

                }

            }
                return lst;
        }
        public static void InsertDetalleConvenio(EntidadDetalleConvenio ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_CONVENIO_DETALLE(id_reg_det_convenio,id_reg_convenio,id_cia_seguro,porcentaje_cubierto,codigo_item_catalogo,precio_venta,factor_calculo,id_grupo,id_clase) values((SELECT ISNULL(MAX(id_reg_det_convenio),0)+1 FROM TBL_CONVENIO_DETALLE),'" + ent.id_regConvenio+"','"+ent.id_ciaSeg+"','"+ent.porcentaje_cubre+"','"+ent.cod_item_catalogo+"','"+ent.precio_venta+"','"+ent.factor_calculo+ "','" + ent.id_grupo + "' ,'" + ent.id_clase + "'    ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                     cmd.ExecuteNonQuery();                    
                }
            }
        }
        public static void UpdateDetalleConvenio(EntidadDetalleConvenio ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_CONVENIO_DETALLE SET porcentaje_cubierto='" + ent.porcentaje_cubre+"',precio_venta='"+ent.precio_venta+"' WHERE codigo_item_catalogo='"+ent.cod_item_catalogo+ "' AND id_cia_seguro='"+ent.id_ciaSeg+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateDetalleConvenio(decimal precio, string cod_item_catalogo, int id_cia_seguro)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_CONVENIO_DETALLE set precio_venta='"+precio+"' WHERE codigo_item_catalogo='"+cod_item_catalogo+"' and id_cia_seguro='"+id_cia_seguro+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteDetalleConvenio(EntidadDetalleConvenio ent)
        {

        }
    }
}
