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
   public class DatosModeloBuscaPacAtendido
    {
        public static List<EntidadModeloBuscaPacAtendido> BuscarPacientesAtendidos(string dni_cliente)
        {
            List<EntidadModeloBuscaPacAtendido> lst = new List<EntidadModeloBuscaPacAtendido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"SELECT numero_admision,fecha_receta,TBL_CLIENTE_PERSONA.numero_doc_cliente, apellido_paterno+' '+ apellido_materno+' '+TBL_CLIENTE_PERSONA.nombres AS paciente,direccion, indicaciones,apellidos+' '+TBL_EMPLEADO.nombres as medico,TBL_CLIENTE_PERSONA.fecha_nace FROM TBL_EMPLEADO INNER JOIN(TBL_CLIENTE_PERSONA INNER JOIN TBL_CONSULTORIO_RECETA_MEDICA ON TBL_CLIENTE_PERSONA.numero_doc_cliente = TBL_CONSULTORIO_RECETA_MEDICA.numero_doc_cliente) ON TBL_EMPLEADO.dni_empleado=TBL_CONSULTORIO_RECETA_MEDICA.dni_empleado WHERE TBL_CLIENTE_PERSONA.numero_doc_cliente='" + dni_cliente+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadModeloBuscaPacAtendido antPacaten = new EntidadModeloBuscaPacAtendido()
                            {
                                numero_admision = Convert.ToInt32(dr["numero_admision"]),
                                fecha_atencion = dr["fecha_cobranza"].ToString(),
                                num_doc_cliente = dr["numero_doc_cliente"].ToString(),                                
                                paciente = dr["paciente"].ToString(),                                                             
                                direccion = dr["direccion"].ToString(),
                                anotaciones = dr["indicaciones"].ToString(),
                                medico = dr["medico"].ToString(),
                                fecha_nace = dr["fecha_nace"].ToString()
                            };
                            lst.Add(antPacaten);
                        }
                    }
                }

            }
                return lst;
        }
        public static List<EntidadModeloBuscaPacAtendido> BuscarPacientesAtendidosExternos(string dni_cliente)
        {
            List<EntidadModeloBuscaPacAtendido> lst = new List<EntidadModeloBuscaPacAtendido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"  SELECT ISNULL(numero_admision,0) AS numero_admision,fecha_cobranza,numero_doc_cliente,apellido_paterno+' '+apellido_materno +' '+ nombres AS paciente, direccion,' ' AS indicaciones,'' AS medico, fecha_nace FROM TBL_CLIENTE_PERSONA INNER JOIN  TBL_DOCUMENTO_CONTABLE ON TBL_CLIENTE_PERSONA.numero_doc_cliente= TBL_DOCUMENTO_CONTABLE.numero_documento_cliente WHERE numero_doc_cliente='"+dni_cliente+"'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAtendido antPacaten = new EntidadModeloBuscaPacAtendido()
                            {
                                numero_admision = Convert.ToInt32(dr["numero_admision"]),
                                fecha_atencion = dr["fecha_cobranza"].ToString(),
                                num_doc_cliente = dr["numero_doc_cliente"].ToString(),
                                paciente = dr["paciente"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                anotaciones = dr["indicaciones"].ToString(),
                                medico = dr["medico"].ToString(),
                                fecha_nace = dr["fecha_nace"].ToString()
                            };
                            lst.Add(antPacaten);
                        }
                    }
                }

            }
            return lst;
        }
        public static List<EntidadModeloBuscaPacAtendido> ListDetalleRecetaMedicamentos( string dni_paciente, int numero_admision)
        {
            List<EntidadModeloBuscaPacAtendido> lst = new List<EntidadModeloBuscaPacAtendido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"SELECT TBL_CATALOGO.codigo_item_catalogo,descripcion_item,cantidad_receta,precio as precio_unitario,precio*cantidad_receta as precio_venta,TBL_CATALOGO.id_grupo, TBL_CATALOGO.id_clase FROM TBL_CATALOGO INNER JOIN(TBL_CONSULTORIO_RECETA_MEDICA INNER JOIN TBL_CONSULTORIO_RECETA_MEDICA_DETALLE ON TBL_CONSULTORIO_RECETA_MEDICA.id_receta= TBL_CONSULTORIO_RECETA_MEDICA_DETALLE.id_receta) ON TBL_CATALOGO.codigo_item_catalogo = TBL_CONSULTORIO_RECETA_MEDICA_DETALLE.codigo_item_catalogo WHERE numero_doc_cliente='" + dni_paciente + "' AND numero_admision= '" + numero_admision + "' AND TBL_CATALOGO.id_grupo=5 ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAtendido antPacaten = new EntidadModeloBuscaPacAtendido()
                            {
                                codigo_item_catalogo =  dr["codigo_item_catalogo"].ToString(),
                                descripcion_item = dr["descripcion_item"].ToString(),
                                cantidad = Convert.ToInt32(dr["cantidad_receta"]),
                                precio_unitario = Convert.ToDecimal(dr["precio_unitario"]),
                                precio_venta = Convert.ToDecimal(dr["precio_venta"]),
                                id_grupo = Convert.ToInt32(dr["id_grupo"]),
                                id_clase = Convert.ToInt32(dr["id_clase"])
                                
                            };
                            lst.Add(antPacaten);
                        }
                    }
                }

            }
            return lst;
        }
        public static List<EntidadModeloBuscaPacAtendido> ListDetalleRecetaMedicamentosConfirmados(string dni_paciente, int numero_admision)
        {
            List<EntidadModeloBuscaPacAtendido> lst = new List<EntidadModeloBuscaPacAtendido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"SELECT TBL_CATALOGO.codigo_item_catalogo,descripcion_item,cantidad_receta,precio as precio_unitario,precio*cantidad_receta as precio_venta,TBL_CATALOGO.id_grupo, TBL_CATALOGO.id_clase FROM TBL_CATALOGO INNER JOIN(TBL_CONSULTORIO_RECETA_MEDICA INNER JOIN TBL_CONSULTORIO_RECETA_MEDICA_DETALLE ON TBL_CONSULTORIO_RECETA_MEDICA.id_receta= TBL_CONSULTORIO_RECETA_MEDICA_DETALLE.id_receta) ON TBL_CATALOGO.codigo_item_catalogo = TBL_CONSULTORIO_RECETA_MEDICA_DETALLE.codigo_item_catalogo WHERE numero_doc_cliente='" + dni_paciente + "' AND numero_admision= '" + numero_admision + "' AND TBL_CATALOGO.id_grupo = 5 AND TBL_CONSULTORIO_RECETA_MEDICA_DETALLE.estado = 1 ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAtendido antPacaten = new EntidadModeloBuscaPacAtendido()
                            {
                                codigo_item_catalogo = dr["codigo_item_catalogo"].ToString(),
                                descripcion_item = dr["descripcion_item"].ToString(),
                                cantidad = Convert.ToInt32(dr["cantidad_receta"]),
                                precio_unitario = Convert.ToDecimal(dr["precio_unitario"]),
                                precio_venta = Convert.ToDecimal(dr["precio_venta"]),
                                id_grupo = Convert.ToInt32(dr["id_grupo"]),
                                id_clase = Convert.ToInt32(dr["id_clase"])

                            };
                            lst.Add(antPacaten);
                        }
                    }
                }

            }
            return lst;
        }
        public static List<EntidadModeloBuscaPacAtendido> ListDetalleRecetaLaboratorio(string dni_paciente, int numero_admision)
        {
            List<EntidadModeloBuscaPacAtendido> lst = new List<EntidadModeloBuscaPacAtendido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"SELECT TBL_CATALOGO.codigo_item_catalogo,descripcion_item,cantidad_receta,precio as precio_unitario,precio*cantidad_receta as precio_venta,TBL_CATALOGO.id_grupo, TBL_CATALOGO.id_clase FROM TBL_CATALOGO INNER JOIN(TBL_CONSULTORIO_RECETA_MEDICA INNER JOIN TBL_CONSULTORIO_RECETA_MEDICA_DETALLE ON TBL_CONSULTORIO_RECETA_MEDICA.id_receta= TBL_CONSULTORIO_RECETA_MEDICA_DETALLE.id_receta) ON TBL_CATALOGO.codigo_item_catalogo = TBL_CONSULTORIO_RECETA_MEDICA_DETALLE.codigo_item_catalogo WHERE numero_doc_cliente='" + dni_paciente + "' AND numero_admision= '" + numero_admision + "' AND TBL_CATALOGO.id_grupo=4 ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAtendido antPacaten = new EntidadModeloBuscaPacAtendido()
                            {
                                codigo_item_catalogo = dr["codigo_item_catalogo"].ToString(),
                                descripcion_item = dr["descripcion_item"].ToString(),
                                cantidad = Convert.ToInt32(dr["cantidad_receta"]),
                                precio_unitario = Convert.ToDecimal(dr["precio_unitario"]),
                                precio_venta = Convert.ToDecimal(dr["precio_venta"]),
                                id_grupo = Convert.ToInt32(dr["id_grupo"]),
                                id_clase = Convert.ToInt32(dr["id_clase"])

                            };
                            lst.Add(antPacaten);
                        }
                    }
                }

            }
            return lst;
        }
        public static List<EntidadModeloBuscaPacAtendido> ListDetalleRecetaLaboratorio(string dni_paciente)
        {
            List<EntidadModeloBuscaPacAtendido> lst = new List<EntidadModeloBuscaPacAtendido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"SELECT TBL_CATALOGO.codigo_item_catalogo,descripcion_detalle,cantidad,precio as precio_unitario,precio*cantidad as precio_venta,TBL_CATALOGO.id_grupo, TBL_CATALOGO.id_clase FROM TBL_CATALOGO INNER JOIN( TBL_DOCUMENTO_CONTABLE INNER JOIN TBL_DOCUMENTO_CONTABLE_DETALLE ON TBL_DOCUMENTO_CONTABLE.numero_documento = TBL_DOCUMENTO_CONTABLE_DETALLE.numero_documento) ON TBL_CATALOGO.codigo_item_catalogo = TBL_DOCUMENTO_CONTABLE_DETALLE.codigo_item_catalogo WHERE numero_documento_cliente='"+dni_paciente+"' AND TBL_CATALOGO.id_grupo=4 ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAtendido antPacaten = new EntidadModeloBuscaPacAtendido()
                            {
                                codigo_item_catalogo = dr["codigo_item_catalogo"].ToString(),
                                descripcion_item = dr["descripcion_detalle"].ToString(),
                                cantidad = Convert.ToInt32(dr["cantidad"]),
                                precio_unitario = Convert.ToDecimal(dr["precio_unitario"]),
                                precio_venta = Convert.ToDecimal(dr["precio_venta"]),
                                id_grupo = Convert.ToInt32(dr["id_grupo"]),
                                id_clase = Convert.ToInt32(dr["id_clase"])

                            };
                            lst.Add(antPacaten);
                        }
                    }
                }

            }
            return lst;
        }
    }
}
